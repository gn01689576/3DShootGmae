using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpCtrl : MonoBehaviour
{
    [SerializeField] float maxHp = 1000;
    [SerializeField] Image hpImage;
    
    public float hp;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = Mathf.Lerp(hpImage.fillAmount, hp / maxHp, 0.1f);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            
        }
    }
}
