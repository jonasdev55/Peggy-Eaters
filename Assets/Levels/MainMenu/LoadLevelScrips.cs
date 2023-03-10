using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class LoadLevelScrips : MonoBehaviour
{
    public GameObject T1;
    public GameObject T2;
    public Listie rTab;
    public MainMenu m;

    public void setLevel(string b)
    {
        GameData.Instance.SceneName = b;
        m.RetrieveLoadImage();
        m.LoadScene();
    }

    private void Start()
    {
        rTab = Listie.Tab1;
        switchtab();
    }

    public void Leftie()
    {
        if(rTab == Listie.Tab1)
        {
            return;
        }

        rTab--;

        switchtab();
    }

    public void Rightie()
    {
        if (rTab == Listie.Tab2)
        {
            return;
        }

        rTab++;

        switchtab();
    }

    public void switchtab()
    {
        if(rTab == Listie.Tab1)
        {
            T1.SetActive(true);
            T2.SetActive(false);
        }

        else if(rTab == Listie.Tab2)
        {
            T1.SetActive(false);
            T2.SetActive(true);
        }
    }

    public enum Listie
    {
        Tab1,
        Tab2
    }
}
