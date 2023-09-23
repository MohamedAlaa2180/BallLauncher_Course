using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidBody;
    [SerializeField] SpringJoint2D ballSpringJoint;
    [SerializeField] float deAttachTime;
    [SerializeField] float ballMass;
    bool isDragging;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody.mass = ballMass;
    }

    // Update is called once per frame
    void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            isDragging = true;
            ballRigidBody.isKinematic = true;
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            ballRigidBody.position = worldPosition;
        }
        else
        {
            if(isDragging == true)
            {
                LaunchBall();
            }
            isDragging = false;
            
        }
    }

    public void LaunchBall()
    {
        ballRigidBody.isKinematic = false;
        Invoke("DeAttachBall", deAttachTime);
    }

    public void DeAttachBall()
    {
        ballSpringJoint.enabled = false;
    }
}
