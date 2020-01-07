using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f, maxspeed = 4, jumpPow = 320f;
    public bool grounded = true, faceright = true, sitdown = false, smile = false;

    public float timedelay = 1;

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

        float h = Input.GetAxis("Player3DiChuyen");
        if (!sitdown)
            r2.AddForce((Vector2.right) * speed * h);
        float up = Input.GetAxis("Player3Ngoi");
        if (up < 0)
        {
            sitdown = true;
            r2.velocity = new Vector2(0, r2.velocity.y);
            col2.size = new Vector2(col2.size.x, 2.5f);
            col2.offset = new Vector2(col2.offset.x, -1.4f);
            r2.position = new Vector2(r2.position.x, -3);
            //transform.position = new Vector3(transform.position.x, -3, transform.position.z);
            //r2.velocity = new Vector2(transform.localPosition.x, transform.localPosition.y);
        }
        else
        {
            sitdown = false;
            col2.size = new Vector2(col2.size.x, 5.43333f);
            col2.offset = new Vector2(col2.offset.x, 0);
        }
        //sitdown = false;
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);

        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (h > 0 && !faceright)
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
        anim.SetBool("smile", smile);

        if (Input.GetKeyDown(KeyCode.T))
        {
            gameObject.GetComponent<Animator>().Play("NV3Cuoi");
            ////yield return new WaitForSeconds(timedelay);
            //smile = false;

        }
        //anim.SetBool("sitdown", sitdown);
        if (Input.GetKeyDown(KeyCode.W))
        {
            //r2.AddForce(Vector2.up * jumpPow);
            //Debug.Log(grounded);
            if (grounded == true)
            {
                //Debug.Log("vao nhay");
                grounded = false;
                //doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);

                /// Debug.Log(Vector2.up);
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
