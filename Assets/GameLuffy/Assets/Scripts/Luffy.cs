using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luffy : MonoBehaviour
{
    [SerializeField]
    float speed = 100f, maxspeed = 4;
    [SerializeField]
    bool faceright = true, grounded = true;
    Rigidbody2D r2;
    Animator anim;
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Player3DiChuyen");// lấy thuộc tính Horizontal trong Input
        if (h != 0)
            r2.AddForce((Vector2.right) * speed * h);

        if (grounded == true)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y); // tạo ma sát
        }

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);// giới hạn tốc độ khi về phía bên phải

        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);// giới hạn tốc độ khi về phía bên trái

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (h > 0 && !faceright)
        {
            Flip();
        }
    }

    private void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        anim.SetBool("grounded", grounded);
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
