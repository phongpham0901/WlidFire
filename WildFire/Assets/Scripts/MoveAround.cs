using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float speedRotate;

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(target.position, Vector3.forward, speedRotate * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(target.position, -Vector3.forward, speedRotate * Time.deltaTime);
        }
    }
}
