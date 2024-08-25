using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnFire : MonoBehaviour
{
    [SerializeField] float timeDelay;
    [SerializeField] float time;

    void Start()
    {
        InvokeRepeating("Spawn", timeDelay, time);
    }

    void Spawn()
    {
        
        float randomPosY = Random.Range(-1.129f, 0.626f);
        Vector2 pos1 = new Vector2(-0.876f, randomPosY);
        Vector2 pos2 = new Vector2(1.874f, randomPosY);

        float randomPosX = Random.Range(-0.617f, 1.633f);
        Vector2 pos3 = new Vector2(randomPosX, -1.123f);
        Vector2 pos4 = new Vector2(randomPosX, 0.627f);

        Vector2[] vector2Pos = {pos1, pos2, pos3, pos4};
        int randomVector2Pos = Random.Range(0, vector2Pos.Length);
        //Instantiate(Fire[randomFire], vector2Pos[randomVector2Pos], Quaternion.identity);
        GameObject Fire = ObjectPool.instance.GetgameObjectsList();
        if (Fire != null)
        {
            Fire.transform.position = vector2Pos[randomVector2Pos];
            Fire.transform.rotation = Quaternion.identity;
            Fire.SetActive(true);
        }
    }

}
