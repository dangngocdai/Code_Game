using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandNV4P1 : MonoBehaviour
{
    public int dmg = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player2"))
        {
            collision.SendMessageUpwards("Damage", dmg);
        }
    }
}
