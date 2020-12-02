using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class REMcontroller : MonoBehaviour
{
    Rigidbody rig;
    Animation ani;
    Animator anim;
    hpCtrlREM hpCtrl;
    

    public GameObject bult;
    public Transform gun;
    public float firerate;
    float nextfire1;
    
    public Text scoreText, highestScoreText;
    public static int monsterScore = 0;

    public float coolDownTime = 3;
    [SerializeField] Image coolDownImage;
    bool isStartCD = false;
    float cdTime;
    int highestScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animation>();
        anim = GetComponent<Animator>();
        hpCtrl = GetComponent<hpCtrlREM>();

        if (PlayerPrefs.HasKey("Highest Score"))
        {
            highestScore = PlayerPrefs.GetInt("Highest Score");
            highestScoreText.text = "最高得分:" + highestScore;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) && Time.time > nextfire1)
        {
            nextfire1 = Time.time + firerate;
            Instantiate(bult, gun.position, gun.rotation);
        }

        float x = ButtonMove.buttonMove.x;
        float y = ButtonMove.buttonMove.y;
        Vector3 dir = new Vector3(x, 0, y);
        if (dir != Vector3.zero)
        {
            anim.SetTrigger("run");
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime*10);
            rig.velocity = dir * 30;
             
            
            rig.isKinematic = false;
        }
        else
        {
           
            rig.isKinematic = true;
        }

        if (coolDownImage.fillAmount > 0)//CD時間
        {
            if (!isStartCD)
            {
                cdTime = coolDownTime;
                isStartCD = true;
            }
        }

        if (isStartCD)
        {
            cdTime -= Time.deltaTime;
            if (cdTime < 0)
            {
                cdTime = 0;
                isStartCD = false;
            }
            coolDownImage.fillAmount = cdTime / coolDownTime;
        }

        scoreText.text = "目前得分:" + monsterScore;//計算分數
        if (monsterScore > highestScore)
        {
            highestScore = monsterScore;
            highestScoreText.text = "最高得分:" + highestScore;
        }

        if (monsterScore > 500)
        {
            GameObject.Find("MonsterCave1").SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)//呼叫自己扣血
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("FireLayer"))
        {
            hpCtrl.Damage(100);
            
        }

        
    }

    public void fire()//3發散射
    {
        if (Time.time > nextfire1)
        {
            anim.SetTrigger("attack");
            
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    switch (j)
                    {
                        case 0:
                            Instantiate(bult, gun.position, gun.rotation);
                            break;
                        case 1:
                            Instantiate(bult, gun.position, gun.rotation * Quaternion.Euler(0, 30, 0));
                            break;
                        case 2:
                            Instantiate(bult, gun.position, gun.rotation * Quaternion.Euler(0, -30, 0));
                            break;
                    }
                }
            }
            nextfire1 = Time.time + firerate;
            
        }
    }
    int bultEuler = 0;
    public void fire2()//環狀發射
    {
        
        if (!isStartCD)
        {
            anim.SetTrigger("attack");
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 36; j++)
                {
                    Instantiate(bult, gun.position, gun.rotation*Quaternion.Euler(0,bultEuler,0));
                    bultEuler += 10;
                }
            }
            coolDownImage.fillAmount = 1;
            
        }
    }


    public void SvaeData()
    {
        PlayerPrefs.SetInt("Highest Score", highestScore);
    }

    
    
}
