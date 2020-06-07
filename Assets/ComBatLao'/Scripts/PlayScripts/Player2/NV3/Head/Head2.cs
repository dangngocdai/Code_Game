using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head2 : MonoBehaviour
{
    public float attackdelay = 0.6f;
    public bool attackinghead = false;

    public Animator anim;

    public Collider2D trigger;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    void Update()
    {
        bool checkSitDown = anim.GetBool("sitdown");
        bool checkGrounded = anim.GetBool("grounded");
        if (Input.GetKeyDown(KeyCode.U) && !attackinghead && !checkSitDown && checkGrounded)
        {
            attackinghead = true;
            trigger.enabled = true;
            attackdelay = 0.7f;
        }

        if (attackinghead)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attackinghead = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("AttackingHead", attackinghead);
    }
}
