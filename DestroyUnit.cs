using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUnit : MonoBehaviour
{

    private string Name;
    public static int HP;
    public static int DP;

    public GameObject effectPrefab;
    public GameObject effectPrefab2;
    public AudioClip sound;
    private AudioSource audio;
    ScoreScript s = new ScoreScript();
    public static float addTime1 = 30;
    public static float addTime2 = 30;

    // Start is called before the first frame update
    void Start()
    {
        //各ユニットの体力、防御力を取得
        if (this.gameObject.name.Equals("PS-P01"))
        {
            Name = BattleUnitData.unitName[0];
            HP = BattleUnitData.unitData[0, 0];
            DP = BattleUnitData.unitData[0, 1];
        }
        else if (this.gameObject.name.Equals("PS-W01"))
        {
            Name = BattleUnitData.unitName[1];
            HP = BattleUnitData.unitData[1, 0];
            DP = BattleUnitData.unitData[1, 1];
        }
        else if (this.gameObject.name.Equals("PS-G01"))
        {
            Name = BattleUnitData.unitName[2];
            HP = BattleUnitData.unitData[2, 0];
            DP = BattleUnitData.unitData[2, 1];
        }
    }

    public void OnTriggerEnter(Collider c)
    {
        //弾が当たった場合の処理
        if (c.gameObject.tag == "Bullet")
        {
            HP = HP - HitBullet.bullet_PP;     //体力減少
            Debug.Log(Name + ":" + HP);
            Vector3 hitPos = c.ClosestPointOnBounds(this.transform.position);
            GameObject effect2 = Instantiate(effectPrefab2, hitPos,
                  Quaternion.identity);
            Destroy(effect2, 0.5f);



            if (HP <= 0)
            {
                audio = GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(sound, transform.position);
                Destroy(this.gameObject);       //体力0で撃破
                Debug.Log("Destroy:" + Name);
                GameObject effect = Instantiate(effectPrefab, transform.position,
                    Quaternion.identity);
                Destroy(effect, 2.0f);
                s.addScore(); //自分・本人がHPを持っている、スコアは相手に渡る


                
            }
        }
        //剣が当たった場合
        else if (c.gameObject.CompareTag("Sword"))
        {
            HP = HP - AttackSword.Sword_PP;
            Debug.Log(Name + ":" + HP);
            Vector3 hitPos = c.ClosestPointOnBounds(this.transform.position);
            GameObject effect2 = Instantiate(effectPrefab2, hitPos,
                Quaternion.identity);
            Destroy(effect2, 2.0f);

            if (HP <= 0)
            {
                audio = GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(sound, transform.position);
                Destroy(this.gameObject);       //体力0で撃破
                Debug.Log("Destroy:" + Name);
                GameObject effect = Instantiate(effectPrefab, transform.position,
                    Quaternion.identity);
                Destroy(effect, 2.0f);
                s.addScore();
            }
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        //輝け！！デーモンコア君
        if (other.CompareTag("DemonCore"))
        {
            HP = HP - HitDemon.Core_PP;
            Debug.Log(Name + ":" + HP);

            if (HP <= 0)
            {
                audio = GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(sound, transform.position);
                GameObject effect = Instantiate(effectPrefab, transform.position,
                    Quaternion.identity);
                Destroy(this.gameObject);       //体力0で撃破
                Debug.Log("Destroy:" + Name);
                Destroy(effect, 1.0f);
                s.addScore();
            }
        }
    }
    void Update()
    {
        addTime1 += Time.deltaTime;
    }
}
