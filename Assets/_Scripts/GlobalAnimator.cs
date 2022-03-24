using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAnimator : MonoBehaviour
{
    public static GlobalAnimator animator;

    private void Awake()
    {
        if (animator != null)
            Destroy(animator);

        animator = this;
    }

    public void Animate(GameObject objectToAnimate, AnimationObject animationType)
    {
        Vector3 localScale = objectToAnimate.transform.localScale;
        Vector3 endScale = new Vector3(animationType.endScale, animationType.endScale, animationType.endScale);
        switch (animationType.typeAnimation)
        {
            case AnimationType.none:
                return;
            case AnimationType.inOutOutIn:
                StartCoroutine(AnimateInOut(objectToAnimate,localScale, endScale, animationType.duration));
                break;
            case AnimationType.appearIn:
                StartCoroutine(LerpToPos(objectToAnimate, Vector3.zero, endScale, animationType.duration));
                break;
            case AnimationType.appearOut:
                StartCoroutine(LerpToPos(objectToAnimate, localScale, Vector3.zero, animationType.duration));
                break;
            default:
                break;
        }
    }

    IEnumerator AnimateInOut(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float lerpTime)
    {
        yield return StartCoroutine(LerpToPos(objectToScale, startScale, endScale, lerpTime));
        yield return StartCoroutine(LerpToPos(objectToScale, endScale, startScale, lerpTime));
    }

    IEnumerator LerpToPos(GameObject objectToScale ,Vector3 startScale, Vector3 endScale, float lerpTime)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / lerpTime)
        {
            objectToScale.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return new WaitForEndOfFrame();
        }
    }
}
