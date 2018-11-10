using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : BaseObjectGenerator {

    public float __emittion_span;
    public float __fixed_y_coodinate;

    float __elasped_time;

    void Update()
    {
        __elasped_time += Time.deltaTime;
        if (__generatable && __elasped_time > __emittion_span) {
            List<Vector2> map = CreateEmittionMap();
            map.ForEach((pos) => {
                //Generate a long type block
                Generate(pos);
            });
            ResetTime();
        }
    }

    protected override List<Vector2> CreateEmittionMap()
    {
        List<Vector2> map = new List<Vector2>();

        Vector2 pos = new Vector2(Random.Range(-3f, 3f), __fixed_y_coodinate);
        map.Add(pos);

        return map;
    }

    protected void Generate(Vector2 position)
    {
        GameObject prefab = GetPrefab();
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
    }

    protected override string LoadPrefabPath()
    {
        return "Prefabs/Block";
    }

    protected override void ResetTime()
    {
        __elasped_time = 0f;
    }
}
