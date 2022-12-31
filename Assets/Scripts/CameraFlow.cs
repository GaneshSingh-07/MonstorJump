using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform PlayerPosition;
    private Vector3 TemPosition;
    private float MinPosition = -2.2f;
    private float MaxPostion = 2.2f;
    void Start()
    {
        PlayerPosition = GameObject.FindWithTag("Player").transform;
    }

   private void LateUpdate() {
    if(PlayerPosition == null){
        return;
    }

    TemPosition = transform.position;
    TemPosition.x = PlayerPosition.position.x;
    
    if(TemPosition.x < MinPosition){
        TemPosition.x = MinPosition;
    }
    else if(TemPosition.x > MaxPostion){
        TemPosition.x = MaxPostion;
    }
    transform.position = TemPosition;

   }
}
