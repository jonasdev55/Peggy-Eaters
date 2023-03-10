using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmallSwitch : MonoBehaviour
{
    public string SceneName;
    public bool EnableSubs = false;
    public string RequiredObject;
    public string CantTriggerText;
    public string TriggerText;
    GameObject Player;
    public float Distance;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < Distance)
        {
            if(CheckIfHasRequiredObject())
            {
                if (EnableSubs)
                {
                    GameData.Instance.Subs = TriggerText + " [E]";

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneManager.LoadScene(SceneName);
                    }
                }

                else
                {
                    SceneManager.LoadScene(SceneName);
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
}
