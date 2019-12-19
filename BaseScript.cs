using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public static int score1 = 0;
    public static int score2 = 0;
    bool BaseFlug; //拠点が占拠されているかを確認
    bool TeamFlug; //占拠しているチーム true:自チームが占拠 false:敵チームが占拠
    float time;
    private void Start()
    {
        //初期状態:どちらのチームにも占拠されていない
        BaseFlug = false;
        this.gameObject.GetComponent<Renderer>().
            material.color = Color.green;
    }

    private void OnTriggerEnter(Collider c)
    {
        //time = 3f;
        //while (time >= 0f)
        //{
        //   time -= Time.time;
        //   Debug.Log(time);
        //}

        //StartCoroutine(Count());

        //自チームが拠点を占拠
        if ((BaseFlug == false && c.gameObject.CompareTag("Player")) ||
            (TeamFlug == false && c.gameObject.CompareTag("Player")))
        {
            BaseFlug = true;
            TeamFlug = true;
            this.gameObject.GetComponent<Renderer>().
                material.color = Color.blue;
            Debug.Log("Player's Base");
            score1 = 100;
        }
        //敵チームが拠点を占拠
        else if ((BaseFlug == true && c.gameObject.CompareTag("Enemy")) ||
                (TeamFlug == true && c.gameObject.CompareTag("Enemy")))
        {
            BaseFlug = true;
            TeamFlug = false;
            this.gameObject.GetComponent<Renderer>().
                material.color = Color.red;
            Debug.Log("Enemy's Base");
            score2 = 100;
        }
    } 

    //IEnumerator Count()
    //{
    //    yield return new WaitForSeconds(3);
    //}
}
