using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementCommand : MonoBehaviour, ICommand
{
    private float inputX;
    private float inputY;
    private Rigidbody2D rb;
    private float maxSpeed;
    private float maxAcceleration;
    private Transform transform;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    public MovementCommand(float _inputX, float _inputY, Rigidbody2D _rb, float _maxSpeed, float _maxAcceleration, Transform _transform)
    {   
        inputX = _inputX;
        inputY = _inputY;
        rb = _rb;
        maxSpeed = _maxSpeed;
        maxAcceleration = _maxAcceleration;
        transform = _transform;

    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object parameter)
    {
        throw new NotImplementedException();
    }

    public void Move()
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
}
