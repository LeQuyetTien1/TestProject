using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitSurfacetype
{
    Dirt=0,
    Blood=1,
}
[System.Serializable]
public class HitEffectMapper
{
    public HitSurfacetype surface;
    public GameObject effectPrefab;
}

public class HitEffectManager : MonoBehaviour
{
    public HitEffectMapper[] effectMap;
}
