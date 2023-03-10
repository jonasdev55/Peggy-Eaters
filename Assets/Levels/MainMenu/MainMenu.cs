using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public Animator menuAnimator;
    public Slider LoadBar;
    public GameObject LoadScreen;
    public Button LoadButton;
    public TMP_Text ProgressCount;
    public Image LoadImage;

    public Sprite L11;
    public Sprite L21;
    public Sprite L41;
    public Sprite L61;
    public Sprite B1;
    public Sprite B2;

    private void Start()
    {
        GameData.Instance.Pause(true);
        Time.timeScale = 1f;
        GameData.Instance.SceneName = PlayerPrefs.GetString("LastLevel");
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (GameData.Instance.SceneName == null || GameData.Instance.SceneName == "Level 1-1")
        {
            LoadButton.interactable = false;
            PlayerPrefs.SetString("LastLevel", "Level 1-1");
        }

        else
        {
            LoadButton.interactable = true;
        }
    }

    public void NewGame()
    {
        GameData.Instance.SceneName = "Level 1-1";
        RetrieveLoadImage();
        GameData.Instance.Pause(false);
        menuAnimator.SetBool("Start", true);
        Invoke("LoadScene", 3);
    }

    public void LoadGame()
    {
        GameData.Instance.Pause(false);
        menuAnimator.SetBool("Start", true);
        RetrieveLoadImage();
        Invoke("LoadScene", 3);
    }

    public void SelectButton()
    {
        menuAnimator.SetBool("Select", true);
    }

    public void SelectBackButton()
    {
        menuAnimator.SetBool("Select", false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        menuAnimator.SetBool("Settings", true);
    }

    public void SettingsBackButton()
    {
        menuAnimator.SetBool("Settings", false);
    }

    public void Quit()
    {
        Application.Quit(); 
    }

    public void LoadScene()
    {
        LoadScreen.SetActive(true);
        StartCoroutine(LoadAsyncr());
        menuAnimator.SetBool("Start", false);
    }

    public void RetrieveLoadImage()
    {
        if(GameData.Instance.SceneName == "Level 1-1")
        {
            LoadImage.sprite = L11;
        }

        else if(GameData.Instance.SceneName == "Level 2-1")
        {
            LoadImage.sprite = L21;
        }

        else if (GameData.Instance.SceneName == "BOSS1")
        {
            LoadImage.sprite = B1;
        }

        else if (GameData.Instance.SceneName == "Level 4-1")
        {
            LoadImage.sprite = L41;
        }

        else if (GameData.Instance.SceneName == "BOSS2")
        {
            LoadImage.sprite = B2;
        }
        
        else if (GameData.Instance.SceneName == "TOWN1")
        {
            LoadImage.sprite = L61;
        }
    }

    IEnumerator LoadAsyncr()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameData.Instance.SceneName);

        while(!operation.isDone)
        {
            ProgressCount.text = "Loading " + (operation.progress * 100).ToString() + "%";
            LoadBar.value = operation.progress;

            yield return null;
        }
    }
}
