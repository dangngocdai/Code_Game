﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttackFootNV4P1 : MonoBehaviour
{
    public bool attacking = false;

    public Animator anim;

    public Collider2D triggerDung;
    //public int player;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        triggerDung.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool checkgrounded = anim.GetBool("grounded");
        bool checksitdown = anim.GetBool("sitdown");
        bool checkdefense = anim.GetBool("defense");
        bool checkAttackFoot = anim.GetBool("attackfoot");
        bool checkAttackHand = anim.GetBool("attackhand");
        if (Input.GetKeyDown(KeyCode.I) && !attacking && checkgrounded && !checksitdown && !checkdefense && Player4.Mana > 20 && !checkAttackFoot && !checkAttackHand)
        {
            Player4.Mana = Player4.Mana - 20;
            Debug.Log(Player4.Mana);
            attacking = true;
            StartCoroutine(DelayDa(0.3f, false));
            StartCoroutine(DelayDa(0.7f, true));

        }
        anim.SetBool("skillfoot", attacking);
    }

    IEnumerator DelayDa(float time, bool endAnim)
    {
        yield return new WaitForSeconds(time);
        if (endAnim)
        {
            triggerDung.enabled = false;
            attacking = false;
        }
        else triggerDung.enabled = true;
    }
}
