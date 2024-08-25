using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SaveScore : MonoBehaviour
{

    [SerializeField] Button LoadGameButton;

    private bool buttonGame;
    private int boolButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boolButton = PlayerPrefs.GetInt("button");
        Debug.Log(boolButton);
        if (boolButton == 1)
        {
            buttonGame = true;
            LoadGameButton.interactable = buttonGame;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("SaveScore");
        PlayerPrefs.DeleteKey("playerPositionX");
        PlayerPrefs.DeleteKey("playerPositionY");
        PlayerPrefs.DeleteKey("playerPositionZ");
        PlayerPrefs.DeleteKey("healthamount");

        PlayerPrefs.SetFloat("playerPositionX", 0.5f);
        PlayerPrefs.SetFloat("playerPositionY", -0.46f);
        PlayerPrefs.SetFloat("playerPositionZ", 0);

        PlayerPrefs.SetInt("liveTree", 18);

        SceneManager.LoadScene(1);

        PlayerPrefs.SetInt("button", 1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

}
