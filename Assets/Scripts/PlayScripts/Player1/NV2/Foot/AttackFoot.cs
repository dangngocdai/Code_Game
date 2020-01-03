using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFoot : MonoBehaviour
{
    public bool attacking = false;

    public Animator anim;

    public Collider2D trigger;

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
        
        if (Input.GetKeyDown(KeyCode.K) && !attacking && checkgrounded && checksitdown)
        {
            attacking = true;
            trigger.enabled = true;
            StartCoroutine(DelayDa(0.3f));
            //attackdelay = 0.3f;

        }
        anim.SetBool("attackfoot", attacking);
    }

    IEnumerator DelayDa(float time)
    {
        yield return new WaitForSeconds(time);
        trigger.enabled = false;
        attacking = false;
    }
}
