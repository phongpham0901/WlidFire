using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, time);
    }

}
