using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behavor : MonoBehaviour
{
    public Transform PlayerPosition;
        
    public float distance = 50f;
    
    
    private void FixedUpdate()
    {
        var position = PlayerPosition.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

}
