using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBoss1 : MonoBehaviour
{
    GameObject Player;

    public GameObject Boss;
    AImovement BossMovement;
    Rigidbody Rigidbody;

    public bool StartCutScene;

    float timer;

    void Start()
    {
        GameData.Instance.Objects.Add("Military Grade Dumbell Launcher");
        Player = GameObject.FindGameObjectWithTag("Player");
        BossMovement = Boss.GetComponent<AImovement>();
        Rigidbody = Boss.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCutScene && timer < 6)
        {
            timer += Time.deltaTime;
            GameData.Instance.CanMove = false;
            BossMovement.CanMove = false;
            Rigidbody.useGravity = false;
            Player.transform.LookAt(Boss.transform.position);
            Boss.transform.position = Vector3.MoveTowards(Boss.transform.position, new Vector3(0, 1, 0), 3f * Time.deltaTime);
            Quaternion Lookat = Quaternion.LookRotation(new Vector3(Player.transform.position.x, 1, Player.transform.position.z) - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Lookat, 0.3f * Time.deltaTime);
        }
        else
        {
            GameData.Instance.CanMove = true;
            BossMovement.CanMove = true;
            Rigidbody.useGravity = true;
        }
    }
}
