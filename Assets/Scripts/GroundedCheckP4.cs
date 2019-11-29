using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheckP4 : MonoBehaviour
{
    // Start is called before the first frame update
    public Player4 player;
    void Start()
    {
        player = gameObject.GetComponentInParent<Player4>();
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
