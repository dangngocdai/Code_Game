using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 50f, maxspeed = 3, maxjump = 10, jumpPow = 300f;
    public bool grounded = true, faceright = true, doublejump = false;

    public Rigidbody2D r2;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");// lấy thuộc tính Horizontal trong Input
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);// giới hạn tốc độ khi về phía bên phải

        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);// giới hạn tốc độ khi về phía bên trái
        //if (r2.velocity.y > maxjump)
        //    r2.velocity = new Vector2(r2.velocity.x, maxjump);// giới hạn tốc độ khi về phía bên phải

        //if (r2.velocity.y < -maxjump)
        //    r2.velocity = new Vector2(r2.velocity.x, -maxjump);// giới hạn tốc độ khi về phía bên trái

        if (h > 0 && faceright)
        {
            Flip();
        }

        if (h < 0 && !faceright)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));
        anim.SetBool("ground", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                doublejump = true;
                grounded = false;
                r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
                }
            }
        }
    }

    void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }
}
