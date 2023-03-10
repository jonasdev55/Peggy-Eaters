using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseboxScript : MonoBehaviour
{
    int HowManyFuses;
    GameObject Player;

    public GameObject Fuse1;
    public GameObject Fuse2;

    public GameObject GlassDoor;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < 1)
        {
            if (GameData.Instance.Objects.Contains("Fuse 1"))
            {
                GameData.Instance.Subs = "Press [E] to place fuse";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Fuse1.SetActive(true);
                    GameData.Instance.Objects.Remove("Fuse 1");
                    HowManyFuses++;
                }
            }

            else if (GameData.Instance.Objects.Contains("Fuse 2"))
            {
                GameData.Instance.Subs = "Press [E] to place fuse";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Fuse2.SetActive(true);
                    GameData.Instance.Objects.Remove("Fuse 2");
                    HowManyFuses++;
                }
            }

            else if (HowManyFuses <= 1)
            {
                GameData.Instance.Subs = "I need a fuse to place here";
            }

            else
            {
                GlassDoor.SetActive(false);
            }
        }
    }
}
