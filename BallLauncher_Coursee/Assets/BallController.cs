using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            ballRigidBody.isKinematic = true;
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            ballRigidBody.position = worldPosition;
        }
        else
        {
            ballRigidBody.isKinematic = false;
        }
    }
}
