using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbellThrowing : MonoBehaviour
{
    public GameObject Dumbell;
    public float Power;
    public DBLHolder LookForDBL;
    public AudioSource DumbellSound;

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.IsAiming && LookForDBL.ThingType == Things.DumbellLauncher)
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                if (CountDumbells() <= 0) { }
                else
                {
                    GameData.Instance.isCBossInv = false;
                    GameData.Instance.Objects.Remove("Dumbell");

                    Quaternion rotation = transform.rotation;
                    GameObject shot = Instantiate(Dumbell, transform.position, rotation);
                    shot.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left * Power);
                    if (DumbellSound != null) DumbellSound.Play();

                    Destroy(shot, 10.0f);
                }
            }
        }
    }

    public int CountDumbells()
    {
        int count = 0;
        foreach(string obj in GameData.Instance.Objects)
        {
            if (obj == "Dumbell")
            {
                count++;
            }
        }
        return count;
    }

}
