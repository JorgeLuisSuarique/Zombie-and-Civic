using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;
[RequireComponent(typeof (Rigidbody))]
public class ClaseNPC : MonoBehaviour
{
    public ZombieData zombinfon;
    GameObject target;
    Color colint;
    public Data dat;
    protected int Speed = 1;
    protected float Rot;
    protected int cas;
    bool StatActive = false;
    public Data NewData()
    {
        return dat;
    }
    

    virtual public void Herent()
    {
        Rot = Random.Range(1, 10);
        Move();
        dat.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
    }
    public void DisplayOrawline(GameObject ob, Color col)
    {
        target = ob;
        colint = col;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = colint;
        Gizmos.DrawLine(transform.position, target.transform.position);

    }
    public virtual void Update()
    {
        switch (cas)//the switch is used for different positions where the zombie is directed.
        {
            case 1:
                transform.position += transform.forward * (Speed * Time.deltaTime);
                break;
            case 2:
                transform.position -= transform.forward * (Speed * Time.deltaTime);
                break;
            case 3:
                transform.position -= transform.right * (Speed * Time.deltaTime);
                break;
            case 4:
                transform.position += transform.right * (Speed * Time.deltaTime);
                break;
            case 5:
                transform.Rotate(Vector3.up * Rot);
                break;
            case 6:
                transform.Rotate(-Vector3.up * Rot);
                break;
            case 7:
                transform.position += new Vector3(0, 0, 0);
                break;
            case 8:
                //foreach (GameObject go in Manager.zomcivnpc)
                //{
                //    if (go.name == "Hero")
                //    {
                //        if (Vector3.Distance(go.transform.position, GameObject.FindGameObjectWithTag("Hero").transform.position) < distantate)
                //        {
                //            direc = Vector3.Normalize(go.transform.position - transform.position);
                //            transform.position += direc * distantate;
                //            Debug.Log("ya entro");
                //        }
                //    }
                //}
                StateReation();
                break;
        } 
    }
    public void Move()//a function is created for the movement.
    {
        if (dat.keep == state.idle)//if the state is at idle.
        {
            cas = 7;//stays in place since it's case 5.
            StartCoroutine(Movement());//it's called coroutine.
        }
        else if (dat.keep == state.move)//if not, if the state this move.
        {
            if (dat.age > 15 && dat.age < 30)
            {
                Speed = 10;
            }
            else if (dat.age > 31 && dat.age < 46)
            {
                Speed = 9;
            }
            else if (dat.age > 47 && dat.age < 62)
            {
                Speed = 7;
            }
            else if (dat.age > 63 && dat.age < 78)
            {
                Speed = 5;
            }
            else if (dat.age > 79 && dat.age < 94)
            {
                Speed = 3;
            }
            else if (dat.age > 95 && dat.age < 100)
            {
                Speed = 2;
            }
            cas = Random.Range(1, 7);//calls the switch to move in different positions.
            StartCoroutine(Movement());//it's called coroutine.
        }
        else if (dat.keep == state.rotation)//if not, if the state this rotation.
        {
            cas = Random.Range(5, 7);//calls the switch to move in different positions.
            StartCoroutine(Movement());//it's called coroutine
        }
        else if (dat.keep == state.StateReation)
        {
            cas = 8;
            StartCoroutine(Movement());
        }

    }
   
    IEnumerator Movement()//se hace una coroutine para el estado del mivimeinto.
    {
        yield return new WaitForSeconds(3f);//takes 3 seconds to work.
        dat.keep = (state)Random.Range(0, 5);//is called one of the two states.
        Move();//is called the Move function.
        yield return new WaitForSeconds(3f);//takes 3 seconds to work.
    }
    public void StateReation()
    {
        foreach (GameObject go in Manager.zomcivnpc)
        {
            if (gameObject.tag == "zombie")
            {
                float distan = Vector3.Distance(go.transform.position, transform.position);
                if (distan <= 5f)
                {
                    Vector3 direc = transform.position = go.transform.position = gameObject.transform.position;
                    direc.y = 0;
                    gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(direc), .1f);

                    if (distan > 1) gameObject.transform.Translate(0, 0, .1f);
                }
            }
            if (gameObject.tag == "civic")
            {
                float distan = Vector3.Distance(go.transform.position, transform.position);
                if (distan <= 5f)
                {
                    Vector3 direc = transform.position = go.transform.position = gameObject.transform.position;
                    direc.y = 0;
                    gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(direc), .1f);

                    if (distan > 1) gameObject.transform.Translate(0, 0, -.1f);
                }
            }
        }
    }

}
public enum state//a list is made of the zombie state.
{
    idle, move, rotation, StateReation
}
public struct Data//the structure is made to be able to call the food, the state and the color to the Zombie class.
{
    public state keep;//becomes a standard enum variable for the state.
    public int age;//an int variable is made for age.
    public float keepmove;
}
