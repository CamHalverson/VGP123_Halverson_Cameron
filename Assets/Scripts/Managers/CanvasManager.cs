using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;

    public Button settingsButton;

    public Button backButton;

    public Button quitButton;

    public Button returnToMenuButton;

    public Button resumeGameButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject gameOverMenu;

    [Header("Text")]
    public Text livesText;
    public Text volSliderText;

    [Header("Slider")]
    public Slider volSlider;




    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(StartGame);

        if (settingsButton)
            settingsButton.onClick.AddListener(ShowSettingsMenu);

        if (backButton)
            backButton.onClick.AddListener(ShowMainMenu);

        if (quitButton)
            quitButton.onClick.AddListener(Quit);

        if (volSlider)
        {
            volSlider.onValueChanged.AddListener((value) => OnSliderValueChanged(value));
            if (volSliderText)
                volSliderText.text = volSlider.value.ToString();
        }

        if (livesText)
            GameManager.Instance.OnLifeValueChanged.AddListener((value) => UpdateLifeText(value));
            livesText.text = "Lives: " + GameManager.Instance.Lives.ToString();

        if (resumeGameButton)
            resumeGameButton.onClick.AddListener(unpauseGame);

        if (returnToMenuButton)
            returnToMenuButton.onClick.AddListener(LoadTitle);

        
           
        
    }

    void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    void unpauseGame()
    {
        pauseMenu.SetActive(false);
    }

    void UpdateLifeText(int value)
    {
       
        livesText.text = "Lives: " + value.ToString();
    }
  
    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }
    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
  

    public void StartGame()
    {
        SceneManager.LoadScene("Level");

    }

    void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }

    void OnSliderValueChanged(float value)
    {
        volSliderText.text = value.ToString();
    }

    void Update()
    {
        if (!pauseMenu) return;

        if (Input.GetKeyUp(KeyCode.Escape))
            pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            Pause();
        }

        else
        {
            Resume();
        }
    }

    void Pause()
    {
        Time.timeScale = 0.0f;
        
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
