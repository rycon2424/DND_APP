using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DND_Button : MonoBehaviour, IAnimatable, IPointerClickHandler, IButton
{
    [ReadOnly] [SerializeField] bool clickable = true;
    public UnityEvent OnButtonPressed;
    [Space]
    public AnimationObject animationType;

    // Animate the Button
    public void Animate()
    {
        GlobalAnimator.animator.Animate(gameObject, animationType);
    }

    IEnumerator ClickAbleAgain()
    {
        clickable = false;
        if (animationType.typeAnimation == AnimationType.none)
        {
            yield return new WaitForSeconds(1);
        }
        else
        {
            yield return new WaitForSeconds(animationType.duration * 2);
        }
        clickable = true;
    }

    public virtual void ButtonPressed()
    {
        if (clickable == false)
            return;

        StartCoroutine(ClickAbleAgain());
        Animate();
        OnButtonPressed.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonPressed();
    }
}
