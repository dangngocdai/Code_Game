using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Text NamePlay1;
    public Text NamePlay2;
    public Text Time;

    private readonly string NamePlayer1 = "NamePlayer1";
    private readonly string NamePlayer2 = "NamePlayer2";
    private readonly string TimePlay = "TimePlay";

    public void ChangeScene()
    {
        //Debug.Log(NamePlay1.text.ToString());
        //Debug.Log(NamePlay2.text.ToString());
        //Debug.Log(Time.text.ToString());
        PlayerPrefs.SetString(NamePlayer1, NamePlay1.text.ToString());
        PlayerPrefs.SetString(NamePlayer2, NamePlay2.text.ToString());
        PlayerPrefs.SetString(TimePlay, Time.text.ToString());
        SceneManager.LoadScene(3);
    }
}
