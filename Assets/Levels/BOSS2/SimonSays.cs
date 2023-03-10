using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public int CurrentLevel;
    public List<int> Numbers;
    public ButtonSimonSays[] Buttons;
    public int progress = 0;

    public GameObject[] Swords;
    public GameObject[] Platforms;

    public Dean dean;

    bool DOTHESUBTITLESREEEEEEEE = false;
    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.BossHealth = 100;
        GameData.Instance.Helth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (DOTHESUBTITLESREEEEEEEE)
        {
            GameData.Instance.Subs = "Dean: You failed, Peggy!";
        }
        else
        {
            GameData.Instance.Subs = "";
        }
    }

    void Restart()
    {
        progress = 0;
        StopAllCoroutines();
        GenerateNewList();
        StartCoroutine(Flash());
    }

    public bool Check(int level, int number)
    {
        if (level == CurrentLevel)
        {
            if (number == Numbers[progress])
            {
                progress++;
                if (progress >= Numbers.Count)
                {
                    StartCoroutine(DropSword());
                    StartCoroutine(DropPlatform());
                    progress = 0;
                    CurrentLevel++;
                    GameData.Instance.BossHealth -= 25;
                    if (GameData.Instance.BossHealth <= 0)
                    {
                        dean.rb.constraints = RigidbodyConstraints.None;
                        Destroy(dean);
                    }
                }
                return true;
            }
            else
            {
                Debug.Log("sadge");
                StartCoroutine(DeanLaughsAtYouFuckingFailingLoser());
                Restart();
                GameData.Instance.Helth -= 10;
            }
        }
        return false;
    }

    IEnumerator DeanLaughsAtYouFuckingFailingLoser()
    {
        float timer = 0;
        bool JONASISGAY = true;
        while (JONASISGAY)
        {
            timer++;
            Debug.Log(timer);
            DOTHESUBTITLESREEEEEEEE = true;
            if (timer >= 3)
            {
                DOTHESUBTITLESREEEEEEEE = false;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    void GenerateNewList()
    {
        Numbers.Clear();

        int lenght = 3;
        if (CurrentLevel >= 2) lenght += 2;
        if (CurrentLevel >= 3) lenght += 1;
        if (CurrentLevel >= 4) lenght += 1;
        for (int i = 0; i < lenght; i++)
        {
            Numbers.Add(Random.Range(0, 5) + 1);
        }
    }

    IEnumerator Flash()
    {
        foreach (int number in Numbers)
        {
            foreach (ButtonSimonSays button in Buttons)
            {
                if (button.ButtonLevel == CurrentLevel && button.ButtonNumber == number)
                {
                    button.Shine();
                    yield return new WaitForSeconds(1.5f);
                }
            }
        }
        yield return null;
    }

    IEnumerator DropSword()
    {
        int sword = CurrentLevel - 1;
        Quaternion TargetRot = Quaternion.Euler(new Vector3(90, 0, 0));
        if (sword == 1) TargetRot = Quaternion.Euler(new Vector3(0, 0, 90));
        if (sword == 2) TargetRot = Quaternion.Euler(new Vector3(-90, 0, 0));
        if (sword == 3) TargetRot = Quaternion.Euler(new Vector3(0, 0, -90));
        while (true)
        {
            Swords[sword].transform.rotation = Quaternion.Slerp(Swords[sword].transform.rotation, TargetRot, Time.deltaTime);
            yield return new WaitForEndOfFrame();
            if (Swords[sword].transform.rotation == TargetRot) break;
        }
        yield return null;
    }
    IEnumerator DropPlatform()
    {
        int platform = CurrentLevel - 1;
        Quaternion TargetRot = Quaternion.Euler(new Vector3(0, 0, 45));
        if (platform == 1) TargetRot = Quaternion.Euler(new Vector3(0, -90, 45));
        if (platform == 2) TargetRot = Quaternion.Euler(new Vector3(0, 180, 45));
        if (platform == 3) TargetRot = Quaternion.Euler(new Vector3(0, 180, 0)); ;
        while (true)
        {
            Platforms[platform].transform.rotation = Quaternion.Slerp(Platforms[platform].transform.rotation, TargetRot, Time.deltaTime);
            yield return new WaitForEndOfFrame();
            if (Platforms[platform].transform.rotation == TargetRot) break;
        }
        yield return null;
    }
}
