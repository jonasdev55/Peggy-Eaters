using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSimonSays : MonoBehaviour
{
    public int ButtonLevel;
    public int ButtonNumber;

    public Material shining;
    public Material off;

    MeshRenderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void Shine()
    {
        StartCoroutine(Flash());
    }
    IEnumerator Flash()
    {
        renderer.material = shining;
        yield return new WaitForSeconds(1f);
        renderer.material = off;

        yield return null;
    }

}
