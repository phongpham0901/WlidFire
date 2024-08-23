using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShuriken : MonoBehaviour
{

    [SerializeField] GameObject shuriken;
    [SerializeField] GameObject firePoint;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Debug.Log("shoot");
            Instantiate(shuriken, firePoint.transform.position, transform.rotation);
        }
    }
}
