using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeanUI : MonoBehaviour
{
    public GameObject Crosshair;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            AimDown();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            AimUp();
        }
    }
    public void AimDown()
    {
        Camera.main.fieldOfView = Mathf.Lerp(50, 60, 5 * Time.deltaTime);
        Crosshair.SetActive(true);
        GameData.Instance.IsAiming = true;
    }

    public void AimUp()
    {
        Camera.main.fieldOfView = 60;
        Crosshair.SetActive(false);
        GameData.Instance.IsAiming = false;
    }
}
