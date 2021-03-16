using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public game game;
    public GameObject[] mas;
    public int spawn;
    public int step = 0;
    IEnumerator Step()
    {
        if (step == 0) mas[step].SetActive(true);
        else if (step == 6)
        {
            game.lives -= 1;
            if(game.lives==2) game.hp2.SetActive(true);
            if (game.lives == 1) game.hp.SetActive(true);
            if (game.lives == 0) game.hp1.SetActive(true);
            Destroy(this.gameObject);
        }
        else
        {
            mas[step].SetActive(true);
            mas[step - 1].SetActive(false);
        }
        step++;
        yield return new WaitForSeconds(game.timer);
        StartCoroutine(Step());
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Step());
    }

    // Update is called once per frame
    void Update()
    {
       if ((step == 5) && (game.WolfPos == spawn))
        {
            mas[4].SetActive(false);
            Destroy(this.gameObject);
            game.points++;
        }
    }
}
