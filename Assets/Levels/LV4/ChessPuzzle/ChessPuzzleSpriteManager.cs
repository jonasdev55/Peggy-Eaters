using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessPuzzleSpriteManager : MonoBehaviour
{
    public Sprite Rook;
    public Sprite Knight;
    public Sprite Bishop;
    public Sprite Pawn;
    public Sprite King;
    public Sprite Queen;

    GameObject Player;
    public Animation CompleteAnim;
    public GameObject UI;

    public bool[] Corrects = new bool[6] { false, false, false, false, false, false };

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void CheckIfCompleted()
    {
        if (Corrects.Contains<bool>(false))
        {
            return;
        }

        Compl();
    }

    public void Compl()
    {
        CompleteAnim.Play();
        Player.SetActive(false);
        UI.SetActive(false);
        Invoke("SetPlActive", 3);
    }

    public void SetPlActive()
    {
        Player.SetActive(true);
        UI.SetActive(true);
    }
}
