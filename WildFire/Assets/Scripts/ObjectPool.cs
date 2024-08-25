using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;
    [SerializeField] private GameObject[] objectSpawn;
    [SerializeField] private List<GameObject> gameObjectsList;
    [SerializeField] private int amountObject;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        gameObjectsList = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountObject; i++)
        {
            for (int j = 0; j < objectSpawn.Length; j++)
            {
                tmp = Instantiate(objectSpawn[j]);
                tmp.SetActive(false);
                gameObjectsList.Add(tmp);
            }
        }


    }

    public GameObject GetgameObjectsList()
    {
        for (int i = 0; i < gameObjectsList.Count; i++)
        {
            if (!gameObjectsList[i].activeInHierarchy)
            {
                return gameObjectsList[i];
            }
        }

        return null;
    }
    
}
