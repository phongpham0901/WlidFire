using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tree : MonoBehaviour
{

    [SerializeField] Text liveText;
    [SerializeField] GameObject panelGameOver;

    public int live = 100;

    public static tree instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        liveText.text = "TREE:" + live;
        live = PlayerPrefs.GetInt("liveTree");
    }

    // Update is called once per frame
    void Update()
    {
        liveText.text = "TREE:" + live;
        Over();
        Debug.Log(live);
    }

    public void Die()
    {
        live--;
        PlayerPrefs.SetInt("liveTree", live);
    }

    public void Over()
    {
        if (live <= 0)
        {
            live = 0;
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
        }
    } 
}
