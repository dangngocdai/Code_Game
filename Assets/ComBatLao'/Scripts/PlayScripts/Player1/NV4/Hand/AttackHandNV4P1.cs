﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandNV4P1 : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;

    public Animator anim;

    public Collider2D trigger;
    //public int player;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool checkgrounded = anim.GetBool("grounded");
        bool checksitdown = anim.GetBool("sitdown");
        bool checkdefense = anim.GetBool("defense");
        bool checkAttackFoot = anim.GetBool("attackfoot");
        bool checkSkillFoot = anim.GetBool("skillfoot");
        if (Input.GetKeyDown(KeyCode.J) && !attacking && checkgrounded && !checksitdown && !checkdefense && !checkAttackFoot && !checkSkillFoot)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.4f;
        }
        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
        anim.SetBool("attackhand", attacking);
    }
}
