using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dean : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float TurnSpeed;
    private Vector3 velocity = Vector3.zero;

    public bool BOSS2;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        Quaternion Lookat = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Lookat, TurnSpeed * Time.deltaTime);

        if (!BOSS2) transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, player.transform.position.y, 0), ref velocity, speed);
        else
        {
            transform.localPosition = Vector3.SmoothDamp(transform.position, new Vector3(0, player.transform.position.y, 0), ref velocity, speed);
        }
    }
}
