using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    bool pausescreen;
    public GameObject PauseScreen;
    public GameObject QuitScreen;
    PlayerLook Playerlook;
    GameObject Player;
    public GameObject BossUI;
    public bool IsBossUI;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Playerlook = Player.GetComponent<PlayerLook>();
        PauseScreen.SetActive(false);
        QuitScreen.SetActive(false);

        if (IsBossUI) BossUI.SetActive(true);
        else BossUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausescreen) pausescreen = false;
            else pausescreen = true;
        }

        if (pausescreen) { PauseScreen.SetActive(true); if (IsBossUI) { BossUI.SetActive(false); } Time.timeScale = 0f; GameData.Instance.Pause(true); Playerlook.enabled = false; }
        else { PauseScreen.SetActive(false); if (IsBossUI) { BossUI.SetActive(true); } Time.timeScale = 1f; GameData.Instance.Pause(false); Playerlook.enabled = true; QuitScreen.SetActive(false); }
    }

    public void RestartButton(string Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void QuitButton()
    {
        QuitScreen.SetActive(true);
    }

    public void DesktopButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void CancelButton()
    {
        QuitScreen.SetActive(false);
    }
}
