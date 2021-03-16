using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class game : MonoBehaviour
{
    public GameObject zero;//наччальное положение яйца
    public GameObject StartPosition;//наччальное положение волка

    public GameObject wolf1;// объекты волка
    public GameObject wolf2;
    public GameObject wolf3;
    public GameObject wolf4;


    public GameObject hp;
    public GameObject hp1;
    public GameObject hp2;

    [HideInInspector]
    public int WolfPos;// место, где находится волк
    [HideInInspector]
    public int points;// количество очков игрока, набранных за 1 игру
    public int lives;// количество жизней
    public float timer;

    [HideInInspector]
    public Transform egg;// временная переменная, позволяющая следить за положением яиц
    [HideInInspector]
    public GameObject[] egg1;// объекты яиц
    [HideInInspector]
    public GameObject[] egg2;
    [HideInInspector]
    public GameObject[] egg3;
    [HideInInspector]
    public GameObject[] egg4;
    IEnumerator Timer()
    {
        GameObject ob = Instantiate(zero);
        Egg comp = ob.AddComponent<Egg>();
        comp.game = this.GetComponent<game>();
        comp.spawn = Random.Range(1, 5);
        if (points > 20) timer = 1.5F;
        if (points > 60) timer = 1;
        if (points > 100) timer = 0.5F;
        if (comp.spawn == 1) comp.mas = egg1;
        if (comp.spawn == 2) comp.mas = egg2;
        if (comp.spawn == 3) comp.mas = egg3;
        if (comp.spawn == 4) comp.mas = egg4;
        
        yield return new WaitForSeconds(timer);
        StartCoroutine(Timer());
            
    }
    private int style = 0;
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100),"Points: " + points, style.ToString());
    }



    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        lives = 3;
        timer = 2F;
        hp = GameObject.Find("hp");
        hp.SetActive(false);
        hp1 = GameObject.Find("hp1");
        hp1.SetActive(false);
        hp2 = GameObject.Find("hp2");
        hp2.SetActive(false);
        egg = GameObject.Find("Eggs1").transform;
        egg1 = new GameObject[6];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg1[i] = egg.Find((i+1).ToString()).gameObject;
        }
        egg = GameObject.Find("Eggs2").transform;
        egg2 = new GameObject[6];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg2[i] = egg.Find((i + 1).ToString()).gameObject;
        }
        egg = GameObject.Find("Eggs3").transform;
        egg3 = new GameObject[6];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg3[i] = egg.Find((i + 1).ToString()).gameObject;
        }
        egg = GameObject.Find("Eggs4").transform;
        egg4 = new GameObject[6];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg4[i] = egg.Find((i + 1).ToString()).gameObject;
        }
        StartPosition = GameObject.Find("wolf_left_up");
        wolf1 = GameObject.Find("wolf_left_up");
        wolf2 = GameObject.Find("wolf_left_down");
        wolf3 = GameObject.Find("wolf_right_up");
        wolf4 = GameObject.Find("wolf_right_down");
        wolf1.SetActive(false);
        wolf2.SetActive(false);
        wolf3.SetActive(false);
        wolf4.SetActive(false);
        StartPosition.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            egg1[i].SetActive(false);
            egg2[i].SetActive(false);
            egg3[i].SetActive(false);
            egg4[i].SetActive(false);
        }
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))//если нажать клавишу Q то волк в станет в положение 1
        {
            StartPosition.SetActive(false);
            StartPosition = wolf1;
            StartPosition.SetActive(true);
            WolfPos = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))//если нажать клавишу A то волк в станет в положение 2
        {
            StartPosition.SetActive(false);
            StartPosition = wolf2;
            StartPosition.SetActive(true);
            WolfPos = 2;
        }
        if (Input.GetKeyDown(KeyCode.E))//если нажать клавишу E то волк в станет в положение 3
        {
            StartPosition.SetActive(false);
            StartPosition = wolf3;
            StartPosition.SetActive(true);
            WolfPos = 3;
        }
        if (Input.GetKeyDown(KeyCode.D))//если нажать клавишу D то волк в станет в положение 4
        {
            StartPosition.SetActive(false);
            StartPosition = wolf4;
            StartPosition.SetActive(true);
            WolfPos = 4;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
            if (lives < 0) SceneManager.LoadScene("Died");
        if (points == 140) SceneManager.LoadScene("Win");
        
    }
}
