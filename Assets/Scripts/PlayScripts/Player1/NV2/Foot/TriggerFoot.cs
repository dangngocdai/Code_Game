using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFoot : MonoBehaviour
{
    public int dmg = 5;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player2"))
        {
            collision.SendMessageUpwards("Damage", dmg);
        }
    }
}
