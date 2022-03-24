using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DND_Page : MonoBehaviour, IPage
{
    public static DND_Page lastPage;

    public bool closeLastPage;
    public AnimationObject openPageAnimation;
    public AnimationObject closePageAnimation;

    public virtual void LoadPage()
    {
        if (lastPage == this)
            return;

        if (lastPage && closeLastPage) // Close last active page if there was any
            lastPage.ClosePage();

        lastPage = this;

        if (gameObject.activeSelf == false) // If inactive set page active
            gameObject.SetActive(true);

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
