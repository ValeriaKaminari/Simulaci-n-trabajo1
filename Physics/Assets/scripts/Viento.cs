using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class Viento : MonoBehaviour
{
    [SerializeField] float mass = 1;
    [SerializeField] MyVector wind;
    [SerializeField] MyVector gravity;
    [SerializeField] [Range(0, 1)] float damping = 1;
    private MyVector position;
    private MyVector velocity;
    private MyVector acceleration;

    private void Start()
    {
        position = transform.position;
    }
    public void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
            velocity *= damping;
        }

        transform.position = position;
        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            velocity *= damping;
        }
    }
    private void FixedUpdate()
    {
        acceleration *= 0f;
        ApplyForce(wind);
        ApplyForce(gravity);
        Move();
    }
    private void Update()
    {
        position.Draw(Color.red);
        velocity.Draw2(position, Color.green);
        acceleration.Draw2(position, Color.blue);
    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
