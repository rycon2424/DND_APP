using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public interface IAnimatable
{
    void Animate();
}

public enum AnimationType
{
    none,
    inOutOutIn,
    appearIn,
    appearOut
}

[System.Serializable]
public class AnimationObject
{
    [EnumToggleButtons]
    public AnimationType typeAnimation = AnimationType.none;

    [ShowIf("@this.typeAnimation != AnimationType.none")]
    [EnableIf("@this.typeAnimation != AnimationType.appearOut")]
    [Range(0, 2)] public float endScale = 1.05f;

    [ShowIf("@this.typeAnimation != AnimationType.none")]
    public float duration = 0.25f;
}
