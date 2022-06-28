using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void Update()
    {
        // カメラの方に向かせる
        transform.LookAt(Camera.main.transform);
    }
}
