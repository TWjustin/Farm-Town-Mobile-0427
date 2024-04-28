using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{

    #region Events

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    #endregion
    
    private TouchControlls touchControlls;
    private Camera mainCamera;
    
    public static InputManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        touchControlls = new TouchControlls();
        mainCamera = Camera.main;
    }
    
    private void OnEnable()
    {
        touchControlls.Enable();
    }
    
    private void OnDisable()
    {
        touchControlls.Disable();
    }

    void Start()
    {
        touchControlls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        touchControlls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
            OnStartTouch(
                ScreenToWorld(mainCamera, touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>()),
                (float)context.startTime);
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(
                ScreenToWorld(mainCamera, touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>()),
                (float)context.time);
    }
    
    public Vector2 PrimaryPosition()
    {
        return ScreenToWorld(mainCamera, touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
    
    private Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }

}
