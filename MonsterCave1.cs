using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCave1: MonoBehaviour
{
    public GameObject monster;
    public Transform REM;
    

    public float hardrate;
    public float firerate;
    float nextfire;
    float ratee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ratee = 1 + Time.time + hardrate;
        if (Time.time > nextfire)
        {
            monster.GetComponent<monsterAICtrl1>().player = REM;
            nextfire = Time.time + firerate;
            GameObject monsterclone = Instantiate(monster, transform.position, transform.rotation) as GameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("GameController").GetComponent<GameController>().dead = true;
            return;
        }
    }
}
