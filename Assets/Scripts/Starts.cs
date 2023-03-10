using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
    public string LevelName;
    Scene Currentscene;

    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.Pause(false);

        GameData.Instance.Helth = 100;

        Currentscene = SceneManager.GetActiveScene();

        if (GameData.Instance.Objects == null) GameData.Instance.Objects = new List<string> { };
        GameData.Instance.SceneName = LevelName;
        PlayerPrefs.SetString("LastLevel", GameData.Instance.SceneName);

        if(Currentscene.name != "Level 1-1")
        {
            GameData.Instance.Info = "[Saving...]";

            Invoke("Saved", 3);
        }
    }

    public void Saved()
    {
        GameData.Instance.Info = "[Game Saved Succesfully]";
    }
}
