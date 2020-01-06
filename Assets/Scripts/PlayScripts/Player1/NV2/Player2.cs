using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 100f, maxspeed = 4, jumpPow = 300f;
    public bool grounded = true, faceright = true, doublejump = false, sitdown = false, defense = false;
    public int Health = 100;
    public static int Mana = 100;
    public Rigidbody2D r2;
    public Animator anim;
    public BoxCollider2D col2;
    public GameObject HealthBarP1;
    public GameObject ManaBarP1;

    private float TimeDelayMana = 1;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        col2 = gameObject.GetComponent<BoxCollider2D>();
        Mana = 100;
        Health = 100;
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Player3DiChuyen");// lấy thuộc tính Horizontal trong Input
        if (!sitdown && !defense) r2.AddForce((Vector2.right) * speed * h);
        float up = Input.GetAxis("Player3Ngoi");
        if (up < 0 && !defense)
        {
            sitdown = true;
            r2.velocity = new Vector2(0, r2.velocity.y);
            col2.size = new Vector2(col2.size.x, 2);
            col2.offset = new Vector2(col2.offset.x,-1.65f);
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
        //Player3PhongThu
        if (Input.GetAxis("Player3PhongThu") < 0)
        {
            defense = true;
        }
        else defense = false;
        

        Transform bar = ManaBarP1.transform.Find("Bar");
        float c = (float)Mana / (float)100;
        if (c > 0)
            bar.localScale = new Vector3(c, 1f);
        else bar.localScale = new Vector3(0, 1f);

    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));
        anim.SetBool("grounded", grounded);
        anim.SetBool("sitdown", sitdown);
        anim.SetBool("defense", defense);
        if (Input.GetKeyDown(KeyCode.W) && !defense)
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
                    r2.AddForce(Vector2.up * jumpPow*0.7f);
                }
            }
        }

        //Hoi mana
        if (Mana < 100)
        {
            Debug.Log(1);
            if (TimeDelayMana > 0)
            {
                TimeDelayMana -= Time.deltaTime;
            }
            else
            {
                Mana = Mana + 2;
                TimeDelayMana = 1f;
            }
            //HoiMana();
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
    void Damage(int dmg)
    {
        bool checkdefense = anim.GetBool("defense");
        if (checkdefense)
        {
            Health -= 1;
        }
        else
        Health -= dmg;
        Transform bar = HealthBarP1.transform.Find("Bar");
        float c = (float)Health / (float)100;
        if (c > 0)
            bar.localScale = new Vector3(c, 1f);
        else bar.localScale = new Vector3(0, 1f);
    }

    void DamageSkill(int dmg)
    {
        bool checkdefense = anim.GetBool("defense");
        if (checkdefense)
        {
            Health -= 5;
        }
        else
            Health -= dmg;
        Transform bar = HealthBarP1.transform.Find("Bar");
        float c = (float)Health / (float)100;
        if (c > 0)
            bar.localScale = new Vector3(c, 1f);
        else bar.localScale = new Vector3(0, 1f);
    }

    //IEnumerator HoiMana()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Mana = Mana + 2;
    //}
}
