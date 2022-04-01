using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMoveCamera : MonoBehaviour
{

#if UNITY_EDITOR
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.up * 1.8f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
#endif
}
