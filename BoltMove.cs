using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoltMove : MonoBehaviour
{
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
