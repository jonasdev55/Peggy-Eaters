using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintsMenu : MonoBehaviour
{
    public string Hint;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.Hints = Hint;
        if (Hint == "") return;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<PlayerLook>().enabled = false;
    }
}
