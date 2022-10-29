using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUiController : MonoBehaviour
{
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _levelsScreen;

    //Menu Buttons
    [SerializeField] private Button _chooseLevel;
    [SerializeField] private Button _quitButton;

    //ChooseLevelButtons
    [SerializeField] private Button _infinityLevel;
    [SerializeField] private Button _premadeLevel;
    [SerializeField] private Button _backButton;
    

    // Start is called before the first frame update
    void Start()
    {
        _chooseLevel.onClick.AddListener(SwapScreen);
        _quitButton.onClick.AddListener(QuitGame);

        _infinityLevel.onClick.AddListener(LoadInfinityLevel);
        _premadeLevel.onClick.AddListener(LoadPremadeLevel);

        _backButton.onClick.AddListener(SwapScreen);
    }

    private void OnDestroy()
    {
        _chooseLevel.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();

        _infinityLevel.onClick.RemoveAllListeners();
        _premadeLevel.onClick.RemoveAllListeners();

        _backButton.onClick.RemoveAllListeners();
    }

    private void SwapScreen()
    {
        _menuScreen.SetActive(!_menuScreen.activeSelf);
        _levelsScreen.SetActive(!_levelsScreen.activeSelf);
    }

    private void LoadInfinityLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadPremadeLevel()
    {
        SceneManager.LoadScene(2);
    }

   private void QuitGame()
    {
        Application.Quit();
    }
}
