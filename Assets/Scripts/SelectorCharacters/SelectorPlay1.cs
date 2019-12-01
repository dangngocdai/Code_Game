using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorPlay1 : MonoBehaviour
{
    public GameObject NhanVat2;
    public GameObject NhanVat3;
    public GameObject NhanVat4;
    public GameObject NhanVat5;

    private Vector3 CharacterPosition;
    private Vector3 OffScreen;
    private int CharacterInt = 1;
    private SpriteRenderer NhanVat2Render, NhanVat3Render, NhanVat4Render, NhanVat5Render;
    private readonly string selectedCharaterPlayer1 = "selectedCharaterPlayer1";
    private void Awake()
    {
        CharacterPosition = NhanVat2.transform.position;
        OffScreen = NhanVat5.transform.position;
        NhanVat2Render = NhanVat2.GetComponent<SpriteRenderer>();
        NhanVat3Render = NhanVat3.GetComponent<SpriteRenderer>();
        NhanVat4Render = NhanVat4.GetComponent<SpriteRenderer>();
        NhanVat5Render = NhanVat5.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        PlayerPrefs.SetInt(selectedCharaterPlayer1, 2);
    }
    public void NextCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 3);
                NhanVat2Render.enabled = false;
                NhanVat2.transform.position = OffScreen;
                NhanVat3.transform.position = CharacterPosition;
                NhanVat3Render.enabled = true;
                CharacterInt++;
                Debug.Log(CharacterInt);
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 4);
                NhanVat3Render.enabled = false;
                NhanVat3.transform.position = OffScreen;
                NhanVat4.transform.position = CharacterPosition;
                NhanVat4Render.enabled = true;
                CharacterInt++;
                Debug.Log(CharacterInt);
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 5);
                NhanVat4Render.enabled = false;
                NhanVat4.transform.position = OffScreen;
                NhanVat5.transform.position = CharacterPosition;
                NhanVat5Render.enabled = true;
                CharacterInt++;
                Debug.Log(CharacterInt);
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 2);
                NhanVat5Render.enabled = false;
                NhanVat5.transform.position = OffScreen;
                NhanVat2.transform.position = CharacterPosition;
                NhanVat2Render.enabled = true;
                CharacterInt++;
                RersetCharacterInt();
                Debug.Log(CharacterInt);
                break;
            default:
                RersetCharacterInt();
                break;
        }

    }
    public void PreviousCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 5);
                NhanVat2Render.enabled = false;
                NhanVat2.transform.position = OffScreen;
                NhanVat5.transform.position = CharacterPosition;
                NhanVat5Render.enabled = true;
                CharacterInt--;
                RersetCharacterInt1();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 2);
                NhanVat3Render.enabled = false;
                NhanVat3.transform.position = OffScreen;
                NhanVat2.transform.position = CharacterPosition;
                NhanVat2Render.enabled = true;
                CharacterInt--;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 3);
                NhanVat4Render.enabled = false;
                NhanVat4.transform.position = OffScreen;
                NhanVat3.transform.position = CharacterPosition;
                NhanVat3Render.enabled = true;
                CharacterInt--;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharaterPlayer1, 4);
                NhanVat5Render.enabled = false;
                NhanVat5.transform.position = OffScreen;
                NhanVat4.transform.position = CharacterPosition;
                NhanVat4Render.enabled = true;
                CharacterInt--;
                break;
            default:
                RersetCharacterInt1();
                break;
        }

    }

    private void RersetCharacterInt()
    {
        if (CharacterInt >= 4)
            CharacterInt = 1;
    }

    private void RersetCharacterInt1()
    {
        if (CharacterInt <= 1)
            CharacterInt = 4;
    }
}
