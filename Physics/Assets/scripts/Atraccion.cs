using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class Atraccion : MonoBehaviour
{
    private MyVector position;
    private MyVector acceleration;
    [SerializeField] float mass = 1;
    [SerializeField] float targetmass = 1;
    [SerializeField] private MyVector velocity;
    [SerializeField] Transform Target;
    [SerializeField] [Range(0, 1)] float gravity = -9.8f;

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
        MyVector r = Target.position - transform.position;
        float weightScalar = mass * gravity;
        MyVector weight = new MyVector(0, weightScalar);
        acceleration *= 0f;
        float Magnituder = r.magnitude;
        MyVector F = r.normalized * (1 / targetmass * mass / Magnituder * Magnituder);

        ApplyForce(F);
        Move();
        F.Draw2(position, Color.red);
    }
    private void Update()
    {
        velocity.Draw2(position, Color.green);
    }

    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
