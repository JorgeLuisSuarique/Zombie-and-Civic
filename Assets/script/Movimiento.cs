using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float Speed;//a float variable for the speed of movement.
    public const float VLC = 25f;//a constancy is made to limit the speed of the characters.
    void Start()
    {
        Speed = Random.Range(new Velocid().vel , VLC);//the vileness is random.
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))//the W key is pressed.
        {
            transform.position += transform.forward * (Speed * Time.deltaTime);//it moves forward.
        }
        if (Input.GetKey(KeyCode.S))//the S key is pressed.
        {
            transform.position -= transform.forward * (Speed * Time.deltaTime);//it moves backwards.
        }
        if (Input.GetKey(KeyCode.A))//the A key is pressed.
        {
            transform.position -= transform.right * (Speed * Time.deltaTime);//moves to the left.
        }
        if (Input.GetKey(KeyCode.D))//the D key is pressed.
        {
            transform.position += transform.right * (Speed * Time.deltaTime);//moves to the right.
        }
    }
}
public class Velocid
{
    public readonly float vel;//a readony for the minimum number of objects to be intented.

    public Velocid()//you become a builder to call it in the Movimiento class.
    {
        vel = Random.Range(1f, 10f);//he puts on the readony at random.
    }
}
