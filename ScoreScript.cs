using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreScript : MonoBehaviour
{
    public static int score1;
    public static int score2;
    static int count = 0;



    // Update is called once per frame
    public void addScore()
    {
           if (DestroyUnit.addTime1 > 0 && DestroyUnit.addTime1 <= 30 && count < 5)
            {
            count++;
            score1 = 60;
            DestroyUnit.addTime1 = 0;
            }
            else
            {
            count = 1;
            score1 = 50;
            DestroyUnit.addTime1 = 0;
            }


    }
}
