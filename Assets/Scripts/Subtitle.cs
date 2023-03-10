using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public TMPro.TMP_Text Text;
    public TypeOfText Type;

    float timer;
    string textext;

    public GameObject Player;
    GameObject HintChild;

    private void Start()
    {
        HintChild = GameObject.Find("HintChild");
    }

    // Update is called once per frame
    void Update()
    {
        switch (Type)
        {
            case TypeOfText.Subtitle:
                Text.text = GameData.Instance.Subs;
                GameData.Instance.Subs = "";
                break;
            case TypeOfText.Info:
                if (GameData.Instance.Info != "")
                {
                    timer = 3;
                    textext = GameData.Instance.Info;
                    GameData.Instance.Info = "";
                }
                if (timer > 0)
                {
                    Text.text = textext;
                    timer -= Time.deltaTime;
                }
                else
                {
                    Text.text = "";
                }
                break;
            case TypeOfText.Hints:
                if(GameData.Instance.Hints == "")
                {
                    Text.text = "";
                }

                if(GameData.Instance.Hints != "")
                {
                    HintChild.SetActive(true);
                    Text.text = GameData.Instance.Hints + " [Left Click to Close]";

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        HintChild.SetActive(false);
                        Player.GetComponent<PlayerLook>().enabled = true;
                        Player.GetComponent<PlayerMovement>().enabled = true;
                        GameData.Instance.Hints = "";
                        Text.text = "";
                    }
                }
                else
                {
                    HintChild.SetActive(false);
                }
                break;
        }
    }
}


public enum TypeOfText
{
    Subtitle,
    Info,
    Hints
}