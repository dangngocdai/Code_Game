using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCanvas : MonoBehaviour
{
    public Text NamePlay1;
    public Text NamePlay2;
    public Text TextTime;
    public Text NamePlayWin;
    public GameObject Win;

    public GameObject HealthBarP1;
    public GameObject HealthBarP2;

    private float Times;
    private float TimeDelay = 1f;

    private readonly string NamePlayer1 = "NamePlayer1";
    private readonly string NamePlayer2 = "NamePlayer2";
    private readonly string TimePlay = "TimePlay";
    void Start()
    {
        Win.SetActive(false);
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

        string StringTime = PlayerPrefs.GetString(TimePlay);
        if(StringTime == "60s")
        {
            Times = 60;
        }
        if(StringTime == "90s")
        {
            Times = 90;
        }
        if(StringTime == "88")
        {
            Times = 88;
        }
        TextTime.text = Times.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        float HealthP1 = Mathf.Abs(HealthBarP1.transform.Find("Bar").localScale.x);
        float HealthP2 =Mathf.Abs( HealthBarP2.transform.Find("Bar").localScale.x);
        if(Times == 0 || HealthP1 == 0 || HealthP2 == 0)
        {
            if(HealthP1 < HealthP2)
            {
                NamePlayWin.text = NamePlay2.text;
            }
            if (HealthP1 > HealthP2)
                NamePlayWin.text = NamePlay1.text;
            Win.SetActive(true);
            Time.timeScale = 0;
        }
        if(Times != 88)
        {
            if(Times > 0) {
                Times -= Time.deltaTime;
                int T = (int)Times;
                TextTime.text = T.ToString();
            }
            else
            {
                Times = 0;
                TextTime.text = Times.ToString();
            }
        }
    }
}
