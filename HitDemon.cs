using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDemon : MonoBehaviour
{
    public static int Core_PP;
    public GameObject effectPrefab;
    public AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Core_PP = 9999;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position,
                Quaternion.identity);
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            Destroy(effect, 9.0f);
            Destroy(this.gameObject, 8.0f);
            Destroy(audioSource, 8.0f);
        }
    }
}
