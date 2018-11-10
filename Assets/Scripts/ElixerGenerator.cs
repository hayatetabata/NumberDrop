using System.Collections.Generic;
using UnityEngine;

public class ElixerGenerator : BaseObjectGenerator {

    public float __emittion_span;
    public float __fixed_y_coodinate;
    float __elasped_time;

    // Update is called once per frame
    void Update () {
        __elasped_time += Time.deltaTime;
        if (__generatable && __elasped_time > __emittion_span) {
            List<Vector2> map = CreateEmittionMap();
            map.ForEach(pos => Generate(pos));
            ResetTime();
        }
	}

    /* TODO
     * Not set fixed values but get x coodinate min and max by screen width
     */
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
        Instantiate(prefab, position, Quaternion.identity);
    }

    protected override string LoadPrefabPath()
    {
        return "Prefabs/Elixer";
    }

    protected override void ResetTime()
    {
        __elasped_time = 0f;
    }
}
