﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttackFootP1 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.I) && !attacking && checkgrounded && !checksitdown&& !checkdefense&& Player2.Mana > 20 && !checkAttackFoot && !checkAttackHand)
        {
            Player2.Mana = Player2.Mana - 20;
            Debug.Log(Player2.Mana);
            attacking = true;
            StartCoroutine(DelayDa(0.3f, false));
            StartCoroutine(DelayDa(0.7f,true));

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

    /*private bool CheckKeyDown()
    {
        bool Key = false;
        if(player == 1)
        {
            Key = Input.GetKeyDown(KeyCode.K);
        }
        if (player == 2)
        {
            
            Key = Input.GetKeyDown(KeyCode.Keypad2);
        }
        return Key;
    }*/
}
