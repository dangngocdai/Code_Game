using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer2 : MonoBehaviour
{
    public GameObject NhanVat2;
    //public GameObject NhanVat3;
    public GameObject NhanVat4;
    //public GameObject NhanVat5;

    private SpriteRenderer NhanVat2Render, NhanVat3Render, NhanVat4Render, NhanVat5Render;
    private readonly string selectedCharaterPlayer2 = "selectedCharaterPlayer2";

    private void Awake()
    {
        NhanVat2Render = NhanVat2.GetComponent<SpriteRenderer>();
        //NhanVat3Render = NhanVat3.GetComponent<SpriteRenderer>();
        NhanVat4Render = NhanVat4.GetComponent<SpriteRenderer>();
        //NhanVat5Render = NhanVat5.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharaterPlayer2);
        Debug.Log("Player2" + getCharacter);
        switch (getCharacter)
        {
            case 2:
                NhanVat2Render.enabled = true;
                NhanVat3Render.enabled = false;
                NhanVat4Render.enabled = false;
                NhanVat5Render.enabled = false;
                break;
            //case 3:
            //    NhanVat3Render.enabled = false;
            //    NhanVat2Render.enabled = true;
            //    NhanVat4Render.enabled = true;
            //    NhanVat5Render.enabled = true;
            //    break;
            case 4:
                NhanVat4Render.enabled = true;
                NhanVat2Render.enabled = false;
                NhanVat3Render.enabled = false;
                //NhanVat5Render.enabled = true;
                break;
            //case 5:
            //    NhanVat5Render.enabled = false;
            //    NhanVat4Render.enabled = true;
            //    NhanVat2Render.enabled = true;
            //    NhanVat3Render.enabled = true;
            //    break;
        }
    }
}
