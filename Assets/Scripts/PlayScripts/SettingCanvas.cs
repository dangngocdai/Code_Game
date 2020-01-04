using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCanvas : MonoBehaviour
{
    public Text NamePlay1;
    public Text NamePlay2;

    private readonly string NamePlayer1 = "NamePlayer1";
    private readonly string NamePlayer2 = "NamePlayer2";
    
    void Start()
    {
        string NameP1 = PlayerPrefs.GetString(NamePlayer1);
        if(NameP1 == "")
        {
            NamePlay1.text = "Player 1";
        }
        else
        {
            NamePlay1.text = NameP1;
        }

        string NameP2 = PlayerPrefs.GetString(NamePlayer2);
        if (NameP2 == "")
        {
            NamePlay2.text = "Player 2";
        }
        else
        {
            NamePlay2.text = NameP2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
