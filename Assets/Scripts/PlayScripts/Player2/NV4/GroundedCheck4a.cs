using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck4a : MonoBehaviour
{
    // Start is called before the first frame update
    public NhanVat4a player;
    void Start()
    {
        player = gameObject.GetComponentInParent<NhanVat4a>();
    }


    void OnTriggerEnter2D(Collider2D conlision)
    {
        player.grounded = true;
    }

    void OnTriggerStay2D(Collider2D conllision)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;
    }
}
