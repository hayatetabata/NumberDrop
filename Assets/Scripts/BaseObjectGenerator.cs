﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseObjectGenerator : MonoBehaviour {
    public bool __generatable = true;

    protected abstract string LoadPrefabPath();
    protected abstract List<Vector2> CreateEmittionMap();
    protected abstract void ResetTime();

    protected GameObject GetPrefab()
    {
        return Resources.Load<GameObject>(LoadPrefabPath());
    }
}
