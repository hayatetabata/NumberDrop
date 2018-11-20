using System.Collections.Generic;
using UnityEngine;
using Constants;

public class WaveGenerator : MonoBehaviour {

    public float __emittion_span;
    public bool __generatable = true;
    public GameObject __player;
    float __y_coordinate;
    float __elasped_time;

    // Update is called once per frame
    void Start() {
        __y_coordinate = __player.transform.position.y + 10f;

        List<int> choicedMap = ChoiceMap();
        List<ObjectMeta> metaMap = ToMetaMap(choicedMap);
        metaMap.ForEach(Generate);
    }

    void Update () {
        __elasped_time += Time.deltaTime;
        if (__generatable && __elasped_time > __emittion_span) {
            __y_coordinate = __player.transform.position.y + 10f;

            List<int> choicedMap = ChoiceMap(Random.Range(2, 5));
            List<ObjectMeta> metaMap = ToMetaMap(choicedMap);
            metaMap.ForEach(Generate);

            ResetTime();
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
    }

    //Create emittion map
    //0: empty, 1: block, 2: elixir
    List<int> ChoiceMap(int mapType = 1)
    {
        List<int> map = new List<int>();
        for (int i = 1; i <= 5; i++) { map.Add(ObjectsKey.empty); }
        switch(mapType) {
            case 1:
                map = new List<int> {0, 2, 0, 0, 0};
                break;
            case 2:
                map = new List<int> { 1, 1, 1, 1, 1 };
                break;
            case 3:
                map = new List<int> { 0, 1, 0, 2, 1 };
                break;
            case 4:
                map = new List<int> { 0, 2, 0, 1, 1 };
                break;
            case 5:
                map = new List<int> { 0, 2, 0, 2, 1 };
                break;
            case 6:
                map = new List<int> { 0, 2, 0, 0, 2 };
                break;
            default:
                throw new System.Exception("Invalid map type: " + mapType.ToString());
        }
        return map;
    }

    List<ObjectMeta> ToMetaMap(List<int> map)
    {
        List<ObjectMeta> metaMap = new List<ObjectMeta>();
        int index = 0;
        foreach (int type in map) {
            ObjectMeta meta = new ObjectMeta();
            meta.type = type;
            meta.pos = IndexToPos(index);
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

    void ResetTime()
    {
        __elasped_time = 0f;
        Debug.Log("Wave's elasped time has been reset.");
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
    }
}