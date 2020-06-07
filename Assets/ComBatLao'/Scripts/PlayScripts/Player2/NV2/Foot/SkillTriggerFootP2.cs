using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTriggerFootP2 : MonoBehaviour
{
    public int dmg = 20;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("DamageSkill", dmg);
        }
    }
}
