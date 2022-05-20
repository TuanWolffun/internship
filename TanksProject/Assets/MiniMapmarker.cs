using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class MiniMapmarker : MonoBehaviour
{
    [SerializeField]
    private Transform ownerTargetTransform;
    [SerializeField]
    private RectTransform myTransform;
    [SerializeField]
    private float scalefactor = 300;
    [ExecuteInEditMode]
    private void Update()
    {
        if (!ownerTargetTransform || !myTransform)
            return;
        var newPos = new Vector2(ownerTargetTransform.position.x, ownerTargetTransform.position.z) / scalefactor;
        myTransform.localPosition = newPos;
    }
}
