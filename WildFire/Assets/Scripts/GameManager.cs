using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject medal1;
    [SerializeField] GameObject medal2;
    [SerializeField] GameObject medal3;

    [SerializeField] Transform player;
    private Vector3 playerPosition;

    public static GameManager instance;

    int point = 0;
    int pointHigh = 0;
    public Text pointText;
    public Text highPoint;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pointHigh = PlayerPrefs.GetInt("hightPoint");
        point = PlayerPrefs.GetInt("SaveScore");
        pointText.text = point.ToString();
        Debug.Log(point);

        if (PlayerPrefs.HasKey("playerStarted"))
        {
            player.gameObject.SetActive(false);
            player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
            player.gameObject.SetActive(true);
        }
        if (!PlayerPrefs.HasKey("playerStarted"))
        {
            PlayerPrefs.SetInt("playerStarted", 1);
            PlayerPrefs.Save();
        }

    }

    // Update is called once per frame
    void Update()
    {
        highPoint.text = pointHigh.ToString();
        SaveScoreGame();
        if (point > pointHigh)
        {
            PlayerPrefs.SetInt("hightPoint", point);
        }

        if(point > 0 && point <= 60)
        {
            medal3.SetActive(true);
            medal2.SetActive(false);
            medal1.SetActive(false);
        }
        else if(point > 60 && point <= 80)
        {
            medal2.SetActive(true);
            medal3.SetActive(false);
            medal1.SetActive(false);
        }
        else if (point > 80)
        {
            medal1.SetActive(true);
            medal2.SetActive(false);
            medal3.SetActive(false);
        }

        playerPosition = player.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
        PlayerPrefs.Save();
        Debug.Log("X:" + PlayerPrefs.GetFloat("playerPositionX") + "Y:" + PlayerPrefs.GetFloat("playerPositionY") + "Z:" + PlayerPrefs.GetFloat("playerPositionZ"));

        BackToMenu();
    }

    private void BackToMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    public void increasePoint()
    {
        point++;
        pointText.text = point.ToString();
        print(point);
    }

    public void PlayAgain()
    {
        point = 0;
        pointText.text = point.ToString();
        //PlayerPrefs.DeleteKey("liveTree");
        tree.instance.live = 18;
        PlayerPrefs.SetInt("liveTree", tree.instance.live);
        PlayerPrefs.SetFloat("playerPositionX", 0.5f);
        PlayerPrefs.SetFloat("playerPositionY", -0.46f);
        PlayerPrefs.SetFloat("playerPositionZ", 0);
        player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
        SceneManager.LoadScene("Game");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuGame");
    }

    public void SaveScoreGame()
    {
        PlayerPrefs.SetInt("SaveScore", point);
    }
    
}
