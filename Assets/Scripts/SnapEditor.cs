using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapEditor : MonoBehaviour
{
    void Update()
    {
        float sizeX = transform.localScale.x;
        float posX = transform.localPosition.x;

        
        float sizeZ = transform.localScale.z;
        float posZ = transform.localPosition.z;

        float positionXSnap = Mathf.RoundToInt(posX / sizeX);
        float positionZSnap = Mathf.RoundToInt(posZ / sizeZ);

        transform.localPosition = new Vector3(positionXSnap, transform.localPosition.y, positionZSnap);
    }
}
