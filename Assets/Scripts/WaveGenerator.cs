﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Constants;

public class WaveGenerator : MonoBehaviour {

    public bool __generatable = true;
    public GameObject __player;
    float __y_coordinate = 7f;
    float __y_coodinate_span = 2.3f;
    int __offset = 2;
    int __max_wave_offset = 5;
    float __player_last_exist;

    // Update is called once per frame
    void Start() {
        List<int> choicedMap = ChoiceMap();
        List<ObjectMeta> metaMap = ToMetaMap(choicedMap, __player.GetComponent<Player>().__power);
        metaMap.ForEach(Generate);
        StartCoroutine("GenerateWave");
        __player_last_exist = __player.transform.position.y;
    }

    IEnumerator GenerateWave() {
        while (__generatable) {
            if (__player_last_exist + 2f < __player.transform.position.y) {
                __player_last_exist = __player.transform.position.y;
                __y_coordinate += __y_coodinate_span;

                List<int> choicedMap = ChoiceMap(__offset);
                List<ObjectMeta> metaMap = ToMetaMap(choicedMap, __player.GetComponent<Player>().__power);
                metaMap.ForEach(Generate);
                __offset = __offset >= __max_wave_offset ? 2 : __offset + 1;
            }
            yield return null;
        }
    }

    void Generate(ObjectMeta meta)
    {
        string prefabPath;
        switch(meta.type) {
            case ObjectsKey.block:
                prefabPath = "Prefabs/Block";
                break;
            case ObjectsKey.elixir:
                prefabPath = "Prefabs/Elixer";
                break;
            case ObjectsKey.empty:
                return;
            default:
                throw new System.Exception("Invalid object type: " + meta.type.ToString());
        }
        GameObject prefab = Resources.Load<GameObject>(prefabPath);
        GameObject obj = Instantiate(prefab, meta.pos, Quaternion.identity);
        if (meta.type == ObjectsKey.block) {
            obj.GetComponent<Block>().__power = meta.power;
        }
    }

    //Create emittion map
    //0: empty, 1: block, 2: elixir
    List<int> ChoiceMap(int mapType = 1)
    {
        List<int> map = new List<int>{ 0, 0, 0, 0, 0 };
        switch(mapType) {
            case 1:
                map = new List<int> { 0, 0, 0, 0, 0 };
                break;
            case 2:
                for (int i = 0; i < 2; i++) {
                    int index = Random.Range(0, 4);
                    map[index] = 2;
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++) {
                    int index = Random.Range(0, 4);
                    map[index] = Random.Range(1, 2);
                }
                break;
            case 4:
                for (int i = 0; i < 2; i++) {
                    int index = Random.Range(0, 4);
                    map[index] = 1;
                }
                break;
            case 5:
                map = new List<int> { 1, 1, 1, 1, 1 };
                break;
            default:
                throw new System.Exception("Invalid map type: " + mapType.ToString());
        }
        return map;
    }

    List<ObjectMeta> ToMetaMap(List<int> map, int power)
    {
        List<ObjectMeta> metaMap = new List<ObjectMeta>();
        int index = 0;
        foreach (int type in map) {
            ObjectMeta meta = new ObjectMeta();
            meta.type = type;
            meta.pos = IndexToPos(index);

            int randPower = Random.Range(power - 5, power + 3);
            meta.power = Mathf.Clamp(randPower, 1, power + 5);

            metaMap.Add(meta);
            index++;
        }
        return metaMap;
    }

    Vector3 IndexToPos(int index)
    {
        float x;
        switch(index) {
            case 0:
                x = -2.4f;
                break;
            case 1:
                x = -1.2f;
                break;
            case 2:
                x = 0f;
                break;
            case 3:
                x = 1.2f;
                break;
            case 4:
                x = 2.4f;
                break;
            default:
                throw new System.Exception("Invalid index: " + index);
        }
        return new Vector3(x, __y_coordinate, 0);
    }
}

namespace Constants {
    public class ObjectsKey {
        public const int empty = 0;
        public const int block = 1;
        public const int elixir = 2;
    }

    public class ObjectMeta {
        public int type = 0;
        public Vector3 pos;
        public int power = 1;
    }
}