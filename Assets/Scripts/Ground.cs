﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update

    public Player2 player;
    void Start()
    {
        player = gameObject.GetComponentInParent<Player2>();
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
