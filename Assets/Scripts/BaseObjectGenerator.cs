using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseObjectGenerator : MonoBehaviour {
    protected abstract void Generate(Vector2 position);
    protected abstract string LoadPrefabPath();
    protected abstract List<Vector2> CreateEmittionMap();
    protected abstract void ResetTime();

    protected GameObject GetPrefab()
    {
        return Resources.Load<GameObject>(LoadPrefabPath());
    }
}
