using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSynthesisScript : MonoBehaviour
{
    GameObject Player;
    public GameObject AcidUI;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < 1)
        {
            GameData.Instance.Subs = "Press [E] To synthesise the metal burning accid. luckely back in the army i was a medic and had to synthesise these all the time.";

            if (Input.GetKeyDown(KeyCode.E))
            {
                AcidUI.SetActive(true);
            }
        }
    }
}
