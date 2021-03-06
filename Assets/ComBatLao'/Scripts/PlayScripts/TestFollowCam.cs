﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TestFollowCam : MonoBehaviour
{
    public List<Transform> targets;



    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;
    private Vector3 velocity;
    private Camera cam;
    private void Start()
    {
        
        cam = gameObject.GetComponent<Camera>();
        //targets.Add
    }

    /*GameObject selectPlayer(int getCharacter,bool player1)
    {
        GameObject a;
        switch (getCharacter)
        {
            case 1:
                {
                    if (player1)
                    {
                        a = GameObject.Find("Player1/Player2.cs");
                    }
                    break;
                }
            case 2:
                {
                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    break;
                }
        }

        return a;
    }*/
    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;
        Move();
        //Zoom();
        if(cam.fieldOfView >= 25)
        {
            float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
            //Debug.Log(newZoom);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        }
        else
        {
            cam.fieldOfView = 25;
        }
        
        //SetCameraSize();
    }

    //void SetCameraSize()
    //{
    //    //horizontal size is based on actual screen ratio
    //    float minSizeX = maxZoom * Screen.width / Screen.height;
    //    //multiplying by 0.5, because the ortographicSize is actually half the height
    //    float width = Mathf.Abs(targets[0].position.x - targets[1].position.x) * 0.5f;
    //    float height = Mathf.Abs(targets[0].position.y - targets[1].position.y) * 0.5f;
    //    //computing the size
    //    float camSizeX = Mathf.Max(width, minSizeX);
    //    cam.orthographicSize = Mathf.Max(height,
    //        camSizeX * Screen.height / Screen.width, maxZoom);
    //}
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        //Debug.Log(GetGreatestDistance());
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(GetTargets(), Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null)
                bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return GetTargets();
        }

        var bounds = new Bounds(GetTargets(), Vector3.zero);
        for(int i = 0; i< targets.Count; i++)
        {
            if(targets[i] != null)
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }

    Vector3 GetTargets()
    {
        if (targets[0])
            return targets[0].position;
        if (targets[1])
            return targets[1].position;
        if (targets[2])
            return targets[2].position;
        if (targets[3])
            return targets[3].position;
        return targets[4].position;
    }
}