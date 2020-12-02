using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDamage : MonoBehaviour
{
    [SerializeField] float headdamage = 50;
    hpCtrlREM hpCtrl;
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
        IDamage damage = other.transform.root.GetComponent<IDamage>();
        if (damage != null)
        {
            damage.Damage(headdamage);
        }
    }
}
