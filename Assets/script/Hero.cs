using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;

public class Hero : MonoBehaviour
{
    public Civicdata civil;//a Civic-class struct type barable.
    public Data dt;
    public ZombieData zom;//a Zombie-class struct type barable.
    Manager manger;
    void Start()
    {
        manger = FindObjectOfType<Manager>().GetComponent<Manager>();
        gameObject.AddComponent<FPS>();//the FPS script is added to it.
        gameObject.AddComponent<Movimiento>();//the movement script is added to it.
        gameObject.AddComponent<Rigidbody>().freezeRotation = enabled;//the RigidBody is added and the rotation is blocked.
        Camera.main.gameObject.transform.localPosition = gameObject.transform.position;//the camera becomes the child of the object.
        Camera.main.transform.SetParent(gameObject.transform);//It looks like the camera with the player.
        Camera.main.gameObject.AddComponent<FPS>();//FPS script is added to the camera.
    }
    public void OnCollisionEnter(Collision collision)//a function for when colliding with objects of the Civic and Zombie class.
    {
        if(collision.gameObject.GetComponent<Civic>())//when it collides with the Civic class.
        {
            manger.panelHero.SetActive(true);
            dt = collision.gameObject.GetComponent<ClaseNPC>().NewData();
            civil = collision.gameObject.GetComponent<Civic>().civiZen();//when it collides with the Civic class.
            //Debug.Log();//this text appears on the console.
            manger.textZomCiv.text = "Hola soy " + civil.name + " y tengo " + dt.age + " años";
        }
        if(collision.gameObject.GetComponent<Zombie>())//when it collides with the Zombie class.
        {
            manger.panelHero.SetActive(true);
            dt = collision.gameObject.GetComponent<ClaseNPC>().NewData();
            zom = collision.gameObject.GetComponent<Zombie>().zombiezen();//when it collides with the Zombie class.
            //Debug.Log();//this text appears on the console.
            manger.textZomCiv.text = "waaaarrr me comere tu " + zom.food;
        }
    }
}