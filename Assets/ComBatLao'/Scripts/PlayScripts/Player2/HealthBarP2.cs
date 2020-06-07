using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarP2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
