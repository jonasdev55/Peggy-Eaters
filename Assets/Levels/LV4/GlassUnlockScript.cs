using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassUnlockScript : MonoBehaviour
{
    GameObject Player;
    public GameObject KeyUI;
    public MeshRenderer Glass;
    public AcidSynthesisScript ASS;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < 1)
        {
            if(GameData.Instance.inputWasCorrect != true)
            {
                GameData.Instance.Subs = "Seems like this is locked, i could try entering a passcode [E]";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    KeyUI.SetActive(true);
                }
            }

            else
            {
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Pause(false);
                Glass.enabled = false;
                ASS.enabled = true;
            }
        }
    }
}
