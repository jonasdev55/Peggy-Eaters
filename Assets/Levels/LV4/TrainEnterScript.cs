using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainEnterScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject UI;
    public Animator A;
    public string LevelName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UI.SetActive(false);
            Destroy(Player);
            A.SetBool("IsLEft", true);
            this.gameObject.GetComponent<AudioSource>().Play();
        }

        Tussen();
    }

    public void Tussen()
    {
        Invoke("Loadsc", 5f);
    }

    public void Loadsc()
    {
        SceneManager.LoadScene(LevelName);
    }
}
