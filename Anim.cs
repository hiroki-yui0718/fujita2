using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Anim : MonoBehaviourPunCallbacks
{
    public static bool Look;
    private Vector3 LookEnemy;
    private Vector3 Target; 
    private Animator anim;
    public LayerMask Layer;
    float speed = 1f;
    private RaycastHit hit;
    public GameObject T;   
    public int Ts;


    // Start is called before the first frame update
    void Start()
    {
        Look = false;
        anim = GetComponent<Animator>(); 
        Debug.Log(anim);
    }

    public static float x;
    public static float z;
    

    // Update is called once per frame
    public void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;
        anim.SetFloat("move X",Input.GetAxis("Horizontal"));
        anim.SetFloat("move Z", Input.GetAxis("Vertical"));;


        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("RSkillAttack");
        }

        transform.position += new Vector3(x, 0, z);

        if (T != null)
        {
             Target = T.transform.position - this.transform.position;
             if (!Physics.Raycast(this.transform.position, Target, 10f, Layer))
             {
                 Debug.Log("LookOn");
                 Look = true;
             }
             else
             {
                 Look = false;
             }
        }
        if (Look)
        {
            if (x == 0 && z == 0)
            {
                if (!Physics.Raycast(this.transform.position, Target, 10f, Layer))
                {
                    Vector3 trunSpeed = Vector3.RotateTowards(transform.forward, Target, 5 * Time.deltaTime, 0f);
                    this.transform.rotation = Quaternion.LookRotation(trunSpeed);
                    anim.SetBool("Attack", true);
                }
            }
        }




    }
    private void OnTriggerStay(Collider other)
    {
 
        if (other.tag == "Enemy")
        {

            if (T == null)
            {
                T = other.gameObject;
                anim.SetBool("Attack", true);

            }

            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                || (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Look == true)
            {
                Debug.Log("LookOut");
                Look = false;
                anim.SetBool("Attack", false);
            }
        }
    }

    private void Update()
    {
        if (!(photonView.IsMine)) return;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("LookOut");
        anim.SetBool("Attack", false);
        Look = false;
        if(T == other.gameObject)
        {
            T = null;
        }
    }

    void SkillEnd()
    {
        anim.SetTrigger("SkillEnd");
    }

}
