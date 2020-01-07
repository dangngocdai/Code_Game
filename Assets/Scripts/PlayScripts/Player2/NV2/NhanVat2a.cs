using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVat2a : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f, maxspeed = 4, jumpPow = 300f;
    public bool grounded = true, faceright = true, doublejump = false, sitdown = false, defense = false, luot = false;
    public int Health = 100;
    public static int Mana = 100;
    public Rigidbody2D r2;
    public Animator anim;
    public BoxCollider2D col2;
    public GameObject HealthBarP2;
    public GameObject ManaBarP2;
    private Object ChemSkill;
    private readonly string selectedCharaterPlayer1 = "selectedCharaterPlayer1";
    private float TimeDelayMana = 1;
    public float attackdelay = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        ChemSkill = Resources.Load("ChemGio");
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        col2 = gameObject.GetComponent<BoxCollider2D>();
        if(PlayerPrefs.GetInt(selectedCharaterPlayer1) == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color= new Color(255, 148, 148);
        }
        Mana = 100;
        Health = 100;
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Player2DiChuyen");// lấy thuộc tính Horizontal trong Input
        if (!sitdown && !defense) r2.AddForce((Vector2.right) * speed * h);
        float up = Input.GetAxis("Player2Ngoi");
        if (up < 0 && !defense && !luot)
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

        if (h > 0 && faceright && !luot)
        {
            Flip();
        }

        if (h < 0 && !faceright && !luot)
        {
            Flip();
        }
        if (grounded == true)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y); // tạo ma sát
        }
        //Player2PhongThu
        //Debug.Log(Input.GetAxis("Player3PhongThu"));
        if (Input.GetAxis("Player2PhongThu") < 0)
        {
            defense = true;
        }
        else defense = false;

        Transform bar = ManaBarP2.transform.Find("Bar");
        float c = (float)Mana / (float)100;
        if (c > 0)
            bar.localScale = new Vector3(-c, 1f);
        else bar.localScale = new Vector3(0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));
        anim.SetBool("grounded", grounded);
        anim.SetBool("sitdown", sitdown);
        anim.SetBool("defense", defense);
        anim.SetBool("luot", luot);
        if (Input.GetKeyDown(KeyCode.UpArrow) && !defense && !luot)
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

        // Luot
        bool checkAttackFoot = anim.GetBool("attackfoot");
        bool checkAttackHand = anim.GetBool("attackhand");
        bool checkSkillFoot = anim.GetBool("skillfoot");
        if (!sitdown && !defense && Input.GetKeyDown(KeyCode.Keypad6) && !luot && grounded && !checkAttackFoot && !checkAttackHand && !checkSkillFoot && Mana > 5)
        {
            luot = true;
            Mana = Mana - 5;
            attackdelay = 0.4f;
        }
        if (luot)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
                //Transform ViTri = gameObject.GetComponent<Transform>();
                //ViTri.position = new Vector2(ViTri.position.x + 1.5f, ViTri.position.y);
                if (transform.localScale.x < 0)
                {
                    GameObject a = GameObject.FindGameObjectWithTag("Player");
                    Physics2D.IgnoreCollision(col2, a.GetComponent<Collider2D>(), true);
                    r2.AddForce((Vector2.right) * 500f);
                }
                if (transform.localScale.x > 0)
                {
                    GameObject a = GameObject.FindGameObjectWithTag("Player");
                    Physics2D.IgnoreCollision(col2, a.GetComponent<Collider2D>(), true);
                    r2.AddForce((Vector2.right) * (-500f));
                }
                Physics2D.IgnoreLayerCollision(8, 9);
            }
            else
            {
                luot = false;
                GameObject a = GameObject.FindGameObjectWithTag("Player");
                Physics2D.IgnoreCollision(col2, a.GetComponent<Collider2D>(), false);
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

        if (Input.GetKeyDown(KeyCode.Keypad4) && !luot && grounded && !checkAttackFoot && !checkAttackHand && !checkSkillFoot && Mana > 20)
        {
            Mana -= 20;
            gameObject.GetComponent<Animator>().Play("NV2SkillTay");
            GameObject Chem = (GameObject)Instantiate(ChemSkill);
            ChemGio.checkPlayer1 = false;
            if (transform.localScale.x < 0)
            {
                ChemGio.checkPhai = true;
                Chem.transform.position = new Vector3(transform.position.x + 2f, transform.position.y + 1.5f, -1);
            }
            if (transform.localScale.x > 0)
            {
                ChemGio.checkPhai = false;
                Chem.transform.position = new Vector3(transform.position.x - 2f, transform.position.y + 1.5f, -1);
                Vector3 Scale;
                Scale = Chem.transform.localScale;
                Scale.x *= -1;
                Chem.transform.localScale = Scale;
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
    void Damage(int dmg)
    {
        bool checkdefense = anim.GetBool("defense");
        if (checkdefense)
        {
            Health -= 1;
        }
        else
        {
            Health -= dmg;
            gameObject.GetComponent<Animator>().Play("NV2BiDanh");
        }
        Transform bar = HealthBarP2.transform.Find("Bar");
        float c = (float)Health / (float)100;
        if (c > 0)
            bar.localScale = new Vector3(-c, 1f);
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
        {
            Health -= dmg;
            gameObject.GetComponent<Animator>().Play("NV2BiDanh");
        }
        Transform bar = HealthBarP2.transform.Find("Bar");
        float c = (float)Health / (float)100;
        if (c > 0)
            bar.localScale = new Vector3(-c, 1f);
        else bar.localScale = new Vector3(0, 1f);
    }
}
