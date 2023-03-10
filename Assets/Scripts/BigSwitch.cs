using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BigSwitch : MonoBehaviour
{

    public string SceneName;
    public bool EnableSubs = false;
    public string RequiredObject;
    public string CantTriggerText;
    public string TriggerText;
    GameObject Player;
    public float Distance;
    public Slider LoadBar;
    public GameObject LoadScreen;
    public TMP_Text ProgressCount;
    public Image LoadImage;
    public Sprite LIMG;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < Distance)
        {
            if (CheckIfHasRequiredObject())
            {
                if (EnableSubs)
                {
                    GameData.Instance.Subs = TriggerText + " [E]";

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        LoadScene();
                    }
                }

                else
                {
                    LoadScene();
                }
            }

            else
            {
                GameData.Instance.Subs = CantTriggerText;
            }
        }
    }

    bool CheckIfHasRequiredObject()
    {
        bool end = false;
        if (RequiredObject == "") return true;
        foreach (string obj in GameData.Instance.Objects)
        {
            if (obj == RequiredObject)
            {
                end = true;
            }
        }
        return end;
    }

    public void LoadScene()
    {
        GameData.Instance.SceneName = SceneName;
        LoadImage.sprite = LIMG;
        LoadScreen.SetActive(true);
        StartCoroutine(LoadAsyncr());
    }

    IEnumerator LoadAsyncr()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameData.Instance.SceneName);

        while (!operation.isDone)
        {
            ProgressCount.text = "Loading " + (operation.progress * 100).ToString() + "%";
            LoadBar.value = operation.progress;

            yield return null;
        }
    }
}
