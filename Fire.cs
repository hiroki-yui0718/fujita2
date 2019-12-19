using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject effectPrefab;
    public static int Fire_PP;
    // Start is called before the first frame update
    void Start()
    {
        Fire_PP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject effect = Instantiate(effectPrefab, transform.position,
            Quaternion.identity);
        Destroy(effect, 5.0f);
    }
}
