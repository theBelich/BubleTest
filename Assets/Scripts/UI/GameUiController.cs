using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiController : MonoBehaviour
{
    [SerializeField] private IsGameOver _isGameOver;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _gameWindow;
    [SerializeField] protected GameObject _infoWindow;
    [SerializeField] protected GameObject _infoWindow2;

    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;


    [SerializeField] private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _menuButton.onClick.AddListener(OpenMenu);
        _continueButton.onClick.AddListener(OpenMenu);
        _restartButton.onClick.AddListener(RestartLevel);
        _quitButton.onClick.AddListener(Quit);

        _isGameOver.OnGameOver += GameOver;
    }

    private void OnDestroy()
    {
        _menuButton.onClick.RemoveAllListeners();
        _restartButton.onClick.RemoveAllListeners();
        _continueButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();

        _isGameOver.OnGameOver -= GameOver;
    }

    private void OpenMenu()
    {
        _menu.SetActive(!_menu.activeSelf);
        _gameWindow.SetActive(!_gameWindow.activeSelf);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Quit()
    {
        SceneManager.LoadScene(0);
    }

    private void GameOver()
    {
        _continueButton.gameObject.SetActive(false);
        _infoWindow.gameObject.SetActive(true);
    }
}
