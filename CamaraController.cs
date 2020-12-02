using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class CamaraController : MonoBehaviour
{
    public float speed;
    public GameObject REM;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - REM.transform.position;
    }

    private void Update()
    {
        transform.position = REM.transform.position + offset;
    }
}
