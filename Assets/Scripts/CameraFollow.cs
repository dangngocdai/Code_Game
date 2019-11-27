using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float smoothtimeX, smoothtimeY; // time trì hoãn khi thay đổi vị trí
    public Vector2 velocity;

    public Player2 player2;

    public Player3 player3;

    public Vector2 minpos, maxpos; // giới hạn camara

    public bool bound;
    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        player3 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player3>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //float trungbinhX = (player2.transform.position.x + player3.transform.position.x) / 2;
        //Debug.Log(trungbinhX);
        float posX = Mathf.SmoothDamp(transform.position.x, player2.transform.position.x, ref velocity.x, smoothtimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player2.transform.position.y, ref velocity.y, smoothtimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bound)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x),
            Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
            Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}