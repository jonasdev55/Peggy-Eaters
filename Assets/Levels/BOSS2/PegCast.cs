using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegCast : MonoBehaviour
{
    public Camera cam;
    public SimonSays system;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                ButtonSimonSays target = hit.transform.GetComponent<ButtonSimonSays>();
                if (target != null)
                {
                    if (system.Check(target.ButtonLevel, target.ButtonNumber))
                    {
                        target.Shine();
                    }
                }
            }
        }
    }
}
