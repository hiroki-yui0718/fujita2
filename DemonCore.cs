using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCore : MonoBehaviour
{

    public GameObject D_Core;
    private float speed;
    private float forceMagnitude;
    Vector3 forceDirection;
    Vector3 force;
    private GameObject D_C;
    private float timeBetweenShot;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        speed = 100f;
        forceDirection = new Vector3(0.0f, 1.0f, 1.0f);
        forceMagnitude = 10.0f;
        force = forceMagnitude * forceDirection;
        timeBetweenShot = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > timeBetweenShot)
        {
            timer = 0.0f;
            D_C = Instantiate(D_Core, transform.position, Quaternion.identity) as GameObject;
            D_C.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}

