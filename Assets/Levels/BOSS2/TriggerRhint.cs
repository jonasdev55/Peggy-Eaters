using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRhint : MonoBehaviour
{
    public GameObject Player;
    bool Istriggered;

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<PlayerLook>().enabled = false;
        GameData.Instance.Hints = "Simeon Says: Mr. Dean wants to play a game with u, Simeon Says. To trigger a prompt press [R] and press the buttons in the same order as shown, if u have messed up or want a restart just press [R] again.";
        Istriggered = true;
    }

    private void Update()
    {
        if(Istriggered == true)
        {
            if(GameData.Instance.Hints == "") 
            {
                Destroy(this.gameObject);
            }
        }
    }
}
