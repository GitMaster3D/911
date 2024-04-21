using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioHandler : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(Camera.main.aspect);
        Camera.main.aspect = 1.77f;
    }
}
