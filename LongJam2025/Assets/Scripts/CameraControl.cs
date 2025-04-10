using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private int larguraMax;
    [SerializeField] private int alturaMax;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeed;

    private int largura;
    private int altura;
    private Vector2 mouse;
    private float scroll;

    void Start()
    {
        largura = Screen.width;
        altura = Screen.height;
    }

    void FixedUpdate()
    {
        cameraMovement();
        cameraZoom();
    }

    void cameraZoom()
    {
        scroll = Mathf.Clamp(Input.mouseScrollDelta.y, -1, 1);
        float zoom = Camera.main.orthographicSize + scroll * zoomSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(zoom, 1, 7);
    }

    void cameraMovement()
    {
        float deltaX = Mathf.Clamp(mouse.x - (largura / 2), -1, 1) * (moveSpeed - 0.01f * (1 /Camera.main.orthographicSize));
        float deltaY = Mathf.Clamp((altura / 2) - mouse.y, -1, 1) * (moveSpeed - 0.01f * (1 / Camera.main.orthographicSize));
        if (-400 < mouse.x - (largura / 2) && mouse.x - (largura / 2) < 400)
        {
            deltaX = 0;
        }
        if (-200 < mouse.y - (altura / 2) && mouse.y - (altura / 2) < 200)
        {
            deltaY = 0;
        }
        float newX = Mathf.Clamp(deltaX + gameObject.transform.position.x, -5, 5);
        float newY = Mathf.Clamp(deltaY + gameObject.transform.position.y, -3, 3);
        gameObject.transform.position = new Vector3(newX, newY, gameObject.transform.position.z);
    }

    void OnGUI()
    {
        mouse = Event.current.mousePosition;
    }
}
