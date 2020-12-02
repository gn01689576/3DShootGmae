using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterAICtrl2 : MonoBehaviour
{
    [SerializeField] GameObject fireballOnHand;
    public LayerMask whatIsPlayer;
    
    public float seeRange = 150;
    public float attackRange = 50;
    public float safeRange = 5;
    public float seeAngle = 120;
    public Transform player;
    public float speed;
    public float rotspeed;

    [HideInInspector] public Vector3 destPosition;
    [HideInInspector] public Transform attackTarget;
    public GameObject explosion;

    TPCtrl tPCtrl;
    Animator animator;
    hpCtrl hpCtrl;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hpCtrl = GetComponent<hpCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        float aiToPlyerDistance = Vector3.Distance(transform.position, player.position);

        if (aiToPlyerDistance > attackRange)//距離外朝玩家移動
        {
            Vector3 targetdir = player.position - transform.position;
            float step = rotspeed * Time.deltaTime;
            Vector3 newdir = Vector3.RotateTowards(transform.forward, targetdir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newdir);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            animator.SetBool("Attack", false);
        }
        else//攻擊距離內攻擊
        {
            Vector3 direction = player.position - transform.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, 0);
            animator.SetBool("Attack", true);
        }
        
    }

    

    void CreatFireBall()//發射火球
    {
        fireballOnHand.SetActive(true);
    }

    void Shoot(GameObject fireballPrefab)
    {
        fireballOnHand.SetActive(false);
        Instantiate(fireballPrefab, fireballOnHand.transform.position,
            Quaternion.LookRotation(player.position + Vector3.up * 7 - fireballOnHand.transform.position));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            hpCtrl.Damage(25);
            if (hpCtrl.hp <= 0)
            {
                hpCtrl.hp = 0;
                REMcontroller.monsterScore += 100;
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
            }
        }
    }
}
