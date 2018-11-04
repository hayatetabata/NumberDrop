using System.Collections.Generic;
using UnityEngine;

public class ElixerGenerator : BaseObjectGenerator {

    public float __emittion_span;
    public float __fixed_y_coodinate;
    public bool __generatable = true;
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
     * Create Emittion map including vector2 positions.
     * Correct X coodinate getting value between 0 and 1 on viewport.
     */
    protected override List<Vector2> CreateEmittionMap()
    {
        List<Vector2> map = new List<Vector2>();

        Vector2 pos = Camera.main.ViewportToWorldPoint(
            new Vector2(
                Random.Range(0f, 1f), 0f
            )
        );
        pos.y = __fixed_y_coodinate;

        map.Add(pos);
        return map;
    }

    protected override void Generate(Vector2 position)
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
