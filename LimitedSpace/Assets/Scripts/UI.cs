using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void Play()
    {
        CreateGame();
        _scoreText.gameObject.SetActive(true);
        GlobalData.score = 0;
        GlobalEvents.UpdateScoreText();

        _mainMenu.SetActive(false);
        GlobalEvents.Start();
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Start()
    {
        CreateGame();
        GlobalEvents.OnUpdateScoreText += OnUpdateScore;
        GlobalEvents.OnGameOver += OnGameOver;
    }

    private void CreateGame()
    {
        if (_gameInstance)
        {
            Destroy(_gameInstance);
        }

        _gameInstance = Instantiate(_gamePrefab);
    }

    private void OnUpdateScore()
    {
        _scoreText.text = "Score: " + GlobalData.score;
    }

    private void OnGameOver()
    {
        _mainMenu.SetActive(true);
    }

    [SerializeField] private GameObject _gamePrefab;
    [SerializeField] private GameObject _mainMenu;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private GameObject _gameInstance;
}
