using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemGio : MonoBehaviour
{
    public static bool checkPhai;
    public static bool checkPlayer1;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (checkPhai)
            rb2d.velocity = new Vector2(10, 0);
        else rb2d.velocity = new Vector2(-10, 0);
        Invoke("DestroySeft", 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (getTag(collision))
        {
            DestroySeft();
            collision.gameObject.SendMessageUpwards("Damage", 7);
        }
    }

    private void DestroySeft()
    {
        Destroy(gameObject);
    }

    bool getTag(Collision2D collision)
    {
        if (checkPlayer1)
            return collision.gameObject.CompareTag("Player2");
        return collision.gameObject.CompareTag("Player");


    }
}
