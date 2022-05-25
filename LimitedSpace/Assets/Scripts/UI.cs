using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void Play()
    {
        CreateGame();
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
    }

    private void CreateGame()
    {
        if (_gameInstance)
        {
            Destroy(_gameInstance);
        }

        _gameInstance = Instantiate(_gamePrefab);
    }

    [SerializeField] private GameObject _gamePrefab;

    [SerializeField] private GameObject _mainMenu;
    
    private GameObject _gameInstance;
}
