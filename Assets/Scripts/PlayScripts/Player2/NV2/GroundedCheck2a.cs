using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck2a : MonoBehaviour
{
    // Start is called before the first frame update
    public NhanVat2a player;
    void Start()
    {
        player = gameObject.GetComponentInParent<NhanVat2a>();
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
