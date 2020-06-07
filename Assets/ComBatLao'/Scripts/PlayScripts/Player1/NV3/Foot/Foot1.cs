using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot1 : MonoBehaviour
{
    public float attackdelay = 0.7f;
    public bool attackingfoot = false;

    public Animator anim;

    public Collider2D trigger;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    void Update() {
        bool checkSitDown = anim.GetBool("sitdown");
        bool checkGrounded = anim.GetBool("grounded");
        if (Input.GetKeyDown(KeyCode.K) && !attackingfoot && !checkSitDown && checkGrounded)
        {
            attackingfoot = true;
            trigger.enabled = true;
            attackdelay = 0.7f;
        }

        if (attackingfoot)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attackingfoot = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("AttackingFoot", attackingfoot);
    }
}
