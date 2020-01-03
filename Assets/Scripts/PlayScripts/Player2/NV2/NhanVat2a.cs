using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVat2a : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f, maxspeed = 4, jumpPow = 300f;
    public bool grounded = true, faceright = true, doublejump = false, sitdown = false;

    public Rigidbody2D r2;
    public Animator anim;
    public BoxCollider2D col2;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        col2 = gameObject.GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Player2DiChuyen");// lấy thuộc tính Horizontal trong Input
        if (!sitdown) r2.AddForce((Vector2.right) * speed * h);
        float up = Input.GetAxis("Player2Ngoi");
        if (up < 0)
        {
            sitdown = true;
            r2.velocity = new Vector2(0, r2.velocity.y);
            col2.size = new Vector2(col2.size.x, 2);
            col2.offset = new Vector2(col2.offset.x, -1.65f);
            r2.position = new Vector2(r2.position.x, -3);
            //transform.position = new Vector3(transform.position.x, -3, transform.position.z);
            //r2.velocity = new Vector2(transform.localPosition.x, transform.localPosition.y);
        }
        else
        {
            sitdown = false;
            col2.size = new Vector2(col2.size.x, 5.33333f);
            col2.offset = new Vector2(col2.offset.x, 0);
        }
        //sitdown = false;
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);// giới hạn tốc độ khi về phía bên phải

        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);// giới hạn tốc độ khi về phía bên trái

        if (h > 0 && faceright)
        {
            Flip();
        }

        if (h < 0 && !faceright)
        {
            Flip();
        }
        if (grounded == true)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y); // tạo ma sát
        }

    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));
        anim.SetBool("grounded", grounded);
        anim.SetBool("sitdown", sitdown);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //r2.AddForce(Vector2.up * jumpPow);
            //Debug.Log(grounded);
            if (grounded == true)
            {
                //Debug.Log("vao nhay");
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);

                /// Debug.Log(Vector2.up);
            }
            else
            {
                if (doublejump == true)
                {
                    doublejump = false;
                    grounded = false;
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
