using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 7f)
        {
            SceneManager.LoadScene("Game");
            timer = 0f;  // Đặt lại bộ đếm về 0
        }

        Debug.Log(timer);
    }
}