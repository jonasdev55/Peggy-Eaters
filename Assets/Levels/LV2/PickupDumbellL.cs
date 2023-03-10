using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupDumbellL : MonoBehaviour
{
    public Animator L2Anim;
    public GameObject Player;

    private void Awake()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<PlayerLook>().enabled = false;
        pickedUpDumbell();
    }

    public void pickedUpDumbell()
    {
        L2Anim.SetBool("DoorIsOpened", true);
        Invoke("SetHint", 3);
    }

    public void SetHint()
    {
        GameData.Instance.Hints = "Press [C] To equip or holster your picked up weapons, the Launcher is a verry difficult weapon to handle. Luckily peg has had her training and knows that u can hold [Right Mouse Button] to aim and [Middle Mouse Button] to shoot.";
    }
}
