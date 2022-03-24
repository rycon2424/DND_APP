using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DND_Page : MonoBehaviour, IPage
{
    public AnimationObject openPageAnimation;
    public AnimationObject closePageAnimation;

    public virtual void LoadPage()
    {
        transform.SetSiblingIndex(transform.parent.childCount);
        GlobalAnimator.animator.Animate(gameObject, openPageAnimation);
    }

    public virtual void ResetPage()
    {

    }

    public virtual void ClosePage()
    {
        GlobalAnimator.animator.Animate(gameObject, closePageAnimation);
    }
}
