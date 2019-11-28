using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectModeCotroller : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("SampleScene");
    }
    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
