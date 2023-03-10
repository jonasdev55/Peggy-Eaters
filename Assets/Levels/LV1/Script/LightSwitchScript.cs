using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    public float Distance;
    public GameObject Player;
    public GameObject Bar1;
    public GameObject Bar2;
    public GameObject Bar3;

    private void Start()
    {
        Bar1.SetActive(false);
        Bar2.SetActive(false);
        Bar3.SetActive(false);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < Distance)
        {
            GameData.Instance.Subs = "Press [E] to flip switch";

            if (Input.GetKeyDown(KeyCode.E))
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);

                Destroy(this);
            }
        }
    }
}
