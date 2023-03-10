using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene1Script : MonoBehaviour
{
    public ParticleSystem Explosion;
    public AudioSource ExplosionSound;
    public string NextLevel;

    private void Start()
    {
        this.gameObject.GetComponent<Animation>().Play();
        Invoke("Explode", 4);
    }

    public void Explode()
    {
        Explosion.Play();
        ExplosionSound.Play();
        Invoke("Laad", 2);
    }

    public void Laad()
    {
        SceneManager.LoadScene(NextLevel);
    }
}
