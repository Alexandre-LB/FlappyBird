using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Game,
        Pause,
        Death
    }
    private GameState _gameState;
    private int highscore;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The GameManger is NULL.");
            }

            return _instance;
        }
    }

    public bool Alive { get; private set; }

    public void Awake()
    {
        _instance = this;
        _instance.Alive = true;
    }

    public void Menu()
    {
        if (Input.GetKeyDown("space"))
        {
            UIManager.Instance.Menu();
        }

        if (GameManager.Instance.Alive)
        {
            UIManager.Instance.Game();
        }

        if (GameManager.Instance.Alive == false)
        {
            UIManager.Instance.Death();
        }
    }

    public void Pause()
    {
    }

    public void Game()
    {
        SpawnManager.Instance.StartSpawning();
    }

    public void Death()
    {
        highscore = UIManager.Instance.Highscore;
        _instance.Alive = false;
    }

    public void ChangeState(GameState state)
    {
        _gameState = state;
        switch (_gameState)
        {
            case GameState.Menu:
                this.Menu();
                Debug.Log("Menu");
                break;
            case GameState.Game:
                this.Game();
                Debug.Log("Game");
                break;
            case GameState.Pause:
                this.Pause();
                Debug.Log("Pause");
                break;
            case GameState.Death:
                this.Death();
                Debug.Log("Death");
                break;
        }
    }
}