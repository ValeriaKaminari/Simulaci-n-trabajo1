using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gargantua : MonoBehaviour
{
    [SerializeField] Transform target;
    private MyVector position;
    private MyVector displacement;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;
    MyVector[] accelerations =
    {
        new MyVector(0,-9.8f),
        new MyVector(9.8f,0f),
        new MyVector(0,9.8f),
        new MyVector(-9.8f,0f),
    };
    private void Start()
    {
        position = transform.position;
    }
    public void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        transform.position = position;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        position.Draw(Color.red);
        displacement.Draw2(position, Color.green);
        velocity.Draw2(position, Color.blue);
        acceleration = target.position - transform.position;
    }
}

