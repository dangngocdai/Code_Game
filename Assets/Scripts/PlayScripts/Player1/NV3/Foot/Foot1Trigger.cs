using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot1Trigger : MonoBehaviour
{
    public int dmg = 5;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player2"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}

