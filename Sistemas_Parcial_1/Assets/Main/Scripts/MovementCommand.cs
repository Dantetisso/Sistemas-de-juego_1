using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementCommand : ICommand
{
    private readonly float inputX;
    private readonly float inputY;
    private readonly Rigidbody2D rb;
    private readonly float maxSpeed;
    private readonly float maxAcceleration;
    private Transform transform;

    public MovementCommand(float _inputX, float _inputY, Rigidbody2D _rb, float _maxSpeed, float _maxAcceleration, Transform _transform)
    {   
        inputX = _inputX;
        inputY = _inputY;
        rb = _rb;
        maxSpeed = _maxSpeed;
        maxAcceleration = _maxAcceleration;
        transform = _transform;
    }
   
    public void Execute()
    {
       float desiredSpeed = inputX * maxSpeed;

       float diffSpeed = desiredSpeed - rb.velocity.x;

       diffSpeed = Mathf.Clamp(diffSpeed, -maxAcceleration, maxAcceleration);

       float Xforce = rb.mass * diffSpeed;

        if (inputX > 0.1f)
        {
            rb.AddForce(new Vector2(Xforce, 0f), ForceMode2D.Impulse);
            transform.rotation = (Quaternion.Euler(0, 0, 0));
        }     
        else if (inputX < -0.1f) 
        {
            rb.AddForce(new Vector2(Xforce, 0f), ForceMode2D.Impulse);
            transform.rotation = (Quaternion.Euler(0, 180, 0));
        }
    }   

    private void ProcessCommand(ICommand command)
    {
        command.Execute();
    }

}
