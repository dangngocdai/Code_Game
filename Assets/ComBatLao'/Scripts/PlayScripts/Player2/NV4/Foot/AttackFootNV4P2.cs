using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFootNV4P2 : MonoBehaviour
{
    public bool attacking = false;

    public Animator anim;

    public Collider2D triggerNgoi;
    public Collider2D triggerDung;
    //public int player;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        triggerNgoi.enabled = false;
        triggerDung.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool checkgrounded = anim.GetBool("grounded");
        bool checksitdown = anim.GetBool("sitdown");
        bool checkdefense = anim.GetBool("defense");
        bool checkAttackHand = anim.GetBool("attackhand");
        bool checkSkillFoot = anim.GetBool("skillfoot");
        if (Input.GetKeyDown(KeyCode.Keypad2) && !attacking && checkgrounded && !checkdefense && !checkAttackHand && !checkSkillFoot)
        {
            attacking = true;
            if (checksitdown)
            {
                triggerNgoi.enabled = true;
                StartCoroutine(DelayDa(0.3f, checksitdown));
            }
            else
            {
                triggerDung.enabled = true;
                StartCoroutine(DelayDa(0.5f, checksitdown));
            }

        }
        anim.SetBool("attackfoot", attacking);
    }

    IEnumerator DelayDa(float time, bool checksitdown)
    {
        yield return new WaitForSeconds(time);
        if (checksitdown)
        {
            triggerNgoi.enabled = false;
        }
        else
        {
            triggerDung.enabled = false;
        }
        attacking = false;
    }
}
