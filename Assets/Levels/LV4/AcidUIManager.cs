using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcidUIManager : MonoBehaviour
{
    public Slider Sl1;
    public Slider Sl2;

    GameObject Player;
    public GameObject AcidStation;

    public Animation Finish;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Player.GetComponent<PlayerLook>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
        GameData.Instance.Pause(true);
    }

    public void SL1Bttn(string What)
    {
        if (What[0] == '1')
        {
            if (What[1] == '+')
            {
                Sl1.value += 1;
            }

            else
            {
                Sl1.value -= 1;
            }
        }

        else
        {
            if (What[1] == '+')
            {
                Sl2.value += 1;
            }

            else
            {
                Sl2.value -= 1;
            }
        }
    }

    public void SynthesisBttn()
    {
        if(Sl1.value == 2 && Sl2.value == 3)
        {
            Player.GetComponent<PlayerLook>().enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = true;
            GameData.Instance.Pause(false);
            Destroy(AcidStation);
            Finish.Play();
            Destroy(this.gameObject);
        }

        else
        {
            Player.GetComponent<PlayerLook>().enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = true;
            GameData.Instance.Pause(false);
            this.gameObject.SetActive(false);
        }
    }
}
