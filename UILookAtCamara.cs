using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCamara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.main.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, 0);
    }
}
