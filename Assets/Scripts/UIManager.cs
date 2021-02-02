using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score = 0;
    public Text txtScore;
    public GameObject menu;
    public GameObject game;
    public GameObject death;
    private static UIManager _instance;
    public Button Button;
    public Text txtHighScore;
    public int Highscore { get; private set; } 
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("The UIManger is NULL.");
            }

            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
        _instance.Highscore = 1;
    }

    public void UpdateScore()
    {
        _instance.score++;
        txtScore.text = "" + score;
        if (score > Highscore)
        {
            Highscore = score;
        }
        txtHighScore.text = "High Score : " + Highscore;
    }

    public void Menu()
    {
        menu.gameObject.SetActive(false);
    }

    public void Death()
    {
        death.gameObject.SetActive(true);
        game.gameObject.SetActive(false);
    }

    public void Game()
    {
        game.gameObject.SetActive(true);
    }

    void Start()
    {
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}