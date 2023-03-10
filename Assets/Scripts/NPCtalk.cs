using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtalk : MonoBehaviour
{
    GameObject Player;
    public string[] Dialogue;
    int count = 0;
    public float distance = 5;
    public bool Restartable = false;
    public bool Automatic = false;
    public float Interval = 1;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < distance)
        {
            timer += Time.deltaTime;
            if (count != Dialogue.Length) GameData.Instance.Subs = Dialogue[count];
            if (!Automatic && Input.GetMouseButtonDown(0) && count < Dialogue.Length && timer > 0.5f)
            {
                count++;
                timer = 0;
            }
            else if (Automatic && count < Dialogue.Length && timer > Interval)
            {
                count++;
                timer = 0;
            }

            if (count >= Dialogue.Length && Restartable)
            {
                count = 0;
            }
        }
    }
}
