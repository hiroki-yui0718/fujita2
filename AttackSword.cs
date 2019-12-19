using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    public static int Sword_PP;
    // Start is called before the first frame update
    void Start()
    {
        Sword_PP = 100;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("当たったお");
        }

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
