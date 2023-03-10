using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBoss2 : MonoBehaviour
{
    GameObject Player;

    public GameObject Boss;

    public bool StartCutScene;

    float timer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCutScene && timer < 6)
        {
            timer += Time.deltaTime;
            GameData.Instance.CanMove = false;
            Player.transform.LookAt(Boss.transform.position);
        }
        else
        {
            GameData.Instance.CanMove = true;
        }
    }
}

