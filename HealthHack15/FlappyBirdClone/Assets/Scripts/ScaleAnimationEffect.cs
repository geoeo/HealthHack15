using UnityEngine;
using System.Collections;

public class ScaleAnimationEffect : MonoBehaviour
{
    public AnimationCurve ScaleAnimationCurve;
    public float Duration;
    public bool ScaleParent;

    float mTimer;

    void Start()
    {
        mTimer = Time.time;
    }

    void Update()
    {
        var scaleTransform = ScaleParent ? transform.parent : transform;
        var curvePos = (Time.time - mTimer) / Duration;
        var scale = ScaleAnimationCurve.Evaluate(curvePos % 1);
        scaleTransform.localScale = Vector3.one * scale;
    }
}
