using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrainHint : MonoBehaviour
{
    public TrainEnterScript t;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameData.Instance.Hints = "Railing: Peg is fast but sometimes she just needs a little transport help.";
            t.enabled = true;
            Player.GetComponent<PlayerLook>().enabled = false;
            Player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
