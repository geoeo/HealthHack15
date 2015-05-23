using UnityEngine;
using System.Collections;

public class ScaleLock : MonoBehaviour
{
    public bool EnableScaleLock;
    public bool EnableRotationLock;

    Vector3 mStartScale;
    Quaternion mStartRotation;

    void Start()
    {
        var parent = transform.parent;
        transform.parent = null;
        mStartScale = transform.localScale;
        mStartRotation = transform.rotation;
        transform.parent = parent;
    }

    void Update()
    {
        var parent = transform.parent;
        transform.parent = null;
        if (EnableScaleLock) transform.localScale = mStartScale;
        if (EnableRotationLock) transform.rotation = mStartRotation;
        transform.parent = parent;
    }
}
