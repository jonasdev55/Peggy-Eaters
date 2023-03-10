using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject Player;
    public float Distance;

    public Animation a;

    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, this.transform.position) < Distance)
        {
            GameData.Instance.Subs = "Press [E] to open the doors";

            if (Input.GetKeyDown(KeyCode.E))
            {
                a.Play();
                Destroy(this);
            }
        }
    }
}
