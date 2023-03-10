using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePieceScript : MonoBehaviour
{
    public ChessPuzzleSpriteManager cpzlsprtmngr;
    string CurrentPiece;
    public SpriteRenderer CurrentSprite;
    public int distance = 1;
    GameObject Player;
    bool UIIsActive;
    bool Correct = false;

    public string KeyPiece;
    [Range(0, 5)]
    public int PieceIndex;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) <= distance)
        {
            GameData.Instance.Subs = "Press [E] to select piece";

            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<PlayerLook>().enabled = false;
                Player.GetComponent<PlayerMovement>().enabled = false;
                GameData.Instance.Hints = "[1] Rook | [2] Knight | [3] Bishop | [4] Pawn | [5] Queen | [6] King | ";
                UIIsActive = true;
            }
        }

        if(UIIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                UpdateFilled("Rook", cpzlsprtmngr.Rook);
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Hints = "";
                UIIsActive = false;
            }

            else  if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                UpdateFilled("Knight", cpzlsprtmngr.Knight);
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Hints = "";
                UIIsActive = false;
            }

            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                UpdateFilled("Bishop", cpzlsprtmngr.Bishop);
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Hints = "";
                UIIsActive = false;
            }

            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                UpdateFilled("Pawn", cpzlsprtmngr.Pawn);
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Hints = "";
                UIIsActive = false;
            }

            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                UpdateFilled("Queen", cpzlsprtmngr.Queen);
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Hints = "";
                UIIsActive = false;
            }

            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                UpdateFilled("King", cpzlsprtmngr.King);
                Player.GetComponent<PlayerLook>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
                GameData.Instance.Hints = "";
                UIIsActive = false;
            }
        }
    }

    public void UpdateFilled(string t, Sprite sp)
    {
        CurrentPiece = t;
        CurrentSprite.sprite = sp;
        CheckIfRight(t);
    }

    public void CheckIfRight(string t)
    {
        if(t == KeyPiece)
        {
            cpzlsprtmngr.Corrects[PieceIndex] = true;
        }

        else
        {
            cpzlsprtmngr.Corrects[PieceIndex] = false;
        }

        cpzlsprtmngr.CheckIfCompleted();
    }
}
