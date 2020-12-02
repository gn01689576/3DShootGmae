using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadByBult : MonoBehaviour
{
    public GameObject explosion;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
            return;
        }

        if (other.tag == "quad")
        {
            return;
        }

        if (other.tag == "cave")
        {
            return;
        }

        if (other.tag == "MonsterCave")
        {
            return;
        }
               
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject.Find("REM").GetComponent<hpCtrlREM>().Damage(500);
            return;
        }

        if (other.tag == "tree")
        {
            REMcontroller.monsterScore += 10;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            return;

        }
        

        REMcontroller.monsterScore += 1;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
