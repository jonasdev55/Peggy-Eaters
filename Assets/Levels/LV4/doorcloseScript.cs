using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcloseScript : MonoBehaviour
{
    public Animation CloseDoor;

    private void Start()
    {
        CloseDoor.Play("OpenDoors2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CloseDoor.Play("DoorClose");
            Destroy(this.gameObject);
        }
    }
}
