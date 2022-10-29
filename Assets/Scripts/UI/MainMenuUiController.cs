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
    

    // Start is called before the first frame update
    void Start()
    {
        _chooseLevel.onClick.AddListener(SwapScreen);
        _quitButton.onClick.AddListener(QuitGame);
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
