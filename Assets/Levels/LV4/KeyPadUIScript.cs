using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Sources;
using TMPro;
using UnityEngine;

public class KeyPadUIScript : MonoBehaviour
{
    string Input;
    public string CorrectInput;
    public int maxInput;
    public GameObject KeyUI;
    GameObject Player;
    public TMP_Text InputText;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Player.GetComponent<PlayerLook>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
        GameData.Instance.Pause(true);

        InputText.text = Input;

        if (Input == CorrectInput)
        {
            Player.GetComponent<PlayerLook>().enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = true;
            GameData.Instance.Pause(false);
            GameData.Instance.inputWasCorrect = true;
            Debug.Log("Correct!");
            KeyUI.SetActive(false);
            return;
        }

        if (Input != null)
        {
            if (Input.Count<char>() >= maxInput)
            {
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Pause(false);
                Input = null;
                KeyUI.SetActive(false);
            }
        }
    }

    public void button1(string Value)
    {
        Input += Value;
    }
}
