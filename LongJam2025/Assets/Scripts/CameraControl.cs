using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private int larguraMax;
    [SerializeField] private int alturaMax;
    [SerializeField] private float speed;

    private int largura;
    private int altura;
    private Vector2 mouse;

    void Start()
    {
        largura = Screen.width;
        altura = Screen.height;
    }

    void FixedUpdate()
    {
        float deltaX = Mathf.Clamp(mouse.x - (largura / 2), -1, 1) * speed;
        float deltaY = Mathf.Clamp((altura / 2) - mouse.y, -1, 1) * speed;
        if (-400 < mouse.x - (largura /2 ) && mouse.x - (largura / 2) < 400)
        {
            deltaX = 0;
        }
        if (-200 < mouse.y - (altura / 2) && mouse.y - (altura / 2) < 200)
        {
            deltaY = 0;
        }
        cameraMovement(deltaX, deltaY);
    }

    void cameraMovement(float deltaX, float deltaY)
    {
        float newX = Mathf.Clamp(deltaX + gameObject.transform.position.x, -10, 10);
        float newY = Mathf.Clamp(deltaY + gameObject.transform.position.y, -5, 5);
        gameObject.transform.position = new Vector3(newX, newY, gameObject.transform.position.z);
    }

    private void OnGUI()
    {
        mouse = Event.current.mousePosition;
        Debug.Log(mouse);
    }
}
