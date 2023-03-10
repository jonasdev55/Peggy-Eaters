using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DieScript : MonoBehaviour
{
    public Animator UiAnim;
    public Animator Playeranimation;
    public PlayerMovement Pl1;
    public PlayerLook Pl2;
    public DBLHolder Pl3;
    public GameObject HealthPeg;
    public GameObject HealthBoss;
    public AudioSource audio;
    public GameUI gui;

    private void Start()
    {
        GameData.Instance.Ded = false;
        audio.volume = 1;
        Pl1.enabled = true;
        Pl2.enabled = true;
        Pl3.enabled = true;
        gui.enabled = true;
        HealthPeg.SetActive(true);
        HealthBoss.SetActive(true);
        Playeranimation.SetBool("Died", false);
        UiAnim.SetBool("PeggyDie", false);
        GameData.Instance.Pause(false);
    }

    void Update()
    {
        if (GameData.Instance.Helth <= 0)
        {
            GameData.Instance.Ded = true;
        }

        if (GameData.Instance.Ded)
        {
            audio.volume = 0;
            Pl1.enabled = false;
            Pl2.enabled = false;
            Pl3.enabled = false;
            gui.enabled = false;
            HealthPeg.SetActive(false);
            HealthBoss.SetActive(false);
            Playeranimation.SetBool("Died", true);
            Invoke("Next1", 2);
        }
    }

    public void Next1()
    {
        UiAnim.SetBool("PeggyDie", true);
        GameData.Instance.Pause(true);
    }
}
