using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandP1 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.J) && !attacking && checkgrounded && !checksitdown)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
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

    //private bool CheckKeyDown()
    //{
    //    bool Key = false;
    //    if (player == 1)
    //    {
    //        Key = Input.GetKeyDown(KeyCode.J);
    //    }
    //    if (player == 2)
    //    {
    //        Key = Input.GetKeyDown(KeyCode.Keypad1);
    //    }
    //    return Key;
    //}
}
