using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;
[RequireComponent(typeof (Rigidbody))]
public class ClaseNPC : MonoBehaviour
{
    public infectedData zombinfon;
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
        StateReation();
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
                transform.position += new Vector3(0,0,0);
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
                Speed = 1;
            }
            else if (dat.age > 31 && dat.age < 46)
            {
                Speed = 1;
            }
            else if (dat.age > 47 && dat.age < 62)
            {
                Speed = 1;
            }
            else if (dat.age > 63 && dat.age < 78)
            {
                Speed = 1;
            }
            else if (dat.age > 79 && dat.age < 94)
            {
                Speed = 1;
            }
            else if (dat.age > 95 && dat.age < 100)
            {
                Speed = 1;
            }
            cas = Random.Range(1, 4);//calls the switch to move in different positions.
            StartCoroutine(Movement());//it's called coroutine.
        }
        else if (dat.keep == state.rotation)//if not, if the state this rotation.
        {
            cas = Random.Range(5, 7);//calls the switch to move in different positions.
            StartCoroutine(Movement());//it's called coroutine
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
        GameObject her = GameObject.FindGameObjectWithTag("Hero");
        List<GameObject> Lzom = new List<GameObject>();
        List<GameObject> Lciv = new List<GameObject>();
        float cual = 0.01f;
        foreach (GameObject go in Manager.zomcivnpc)
        {
            if (go.GetComponent<Zombie>())
            {
                Lzom.Add(go);
                
            }
            if (go.GetComponent<Civic>())
            {
                Lciv.Add(go);
            }
        }
        foreach (GameObject to in Lzom)
        {

            foreach (GameObject ji in Lciv)
            {
                float dist = Vector3.Distance(to.transform.position, ji.transform.position);
                if (dist <= 5f)
                {
                    to.transform.position = Vector3.MoveTowards(to.transform.position, ji.transform.position, cual);
                }
            }
            float dist2 = Vector3.Distance(to.transform.position, her.transform.position);
            if (dist2 <= 5f)
            {
                to.transform.position = Vector3.MoveTowards(to.transform.position, her.transform.position, cual);
            }
            
        }
        foreach (GameObject ji in Lciv)
        {
            foreach (GameObject to in Lzom)
            {
                float dist3 = Vector3.Distance (ji.transform.position, to.transform.position);
                if (dist3 <= 5f)
                {
                    ji.transform.position = Vector3.MoveTowards(ji.transform.position , -to.transform.position, cual);
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
