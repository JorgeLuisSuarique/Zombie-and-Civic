﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;
using UnityEngine.UI;
public class Manager : MonoBehaviour 
{
    GameObject PerCube;//a private object to instantiate the primitives of the cubes of zombies and civilians.
    int corX;//an int for the X-cordinate.
    int corZ;//an int for the Z-cordinate.
    int Instancias;//a varible is created to instantiate the number of cubes that should appear.
    int Instan;//an int varible is created to try the switch cases.
    int conHero;//the accountant for the hero.
    public const int IDI = 25;//an const is made to limit the intancias of the personages.

    public static List<GameObject> zomcivnpc = new List<GameObject>();//a list is made for the texts.
    public Text zomText;//becomes a public variable for the text of the Zombie.
    public Text civText;//becomes a public variable for the Civic text.
    int contzom; //a counter is made for the Zombie's text.
    int contciv;//a counter is made for the Civic text.
    public static Transform tranforZombie;
    public Transform tz;

    public GameObject panelHero;
    public Text textZomCiv;

    void Awake()
	{
        tranforZombie = tz;
        panelHero.gameObject.SetActive(false);
		Instancias = Random.Range(new Instanciar().identi, IDI);//the objects are instantiated between the construct of the Instanciar and conts class.
        for (int i = 0; i < Instancias; i++)//by the time the cubes are started.
        {
            corX = Random.Range(-45 , 45);//the coordinates on the X axis.
            corZ = Random.Range(-45, 45);//the coordinates on the Z axis.
            Instan = Random.Range(1,4);//the number of cases of the switch.
            switch (Instan)
            {
                case 1:
                    if (conHero == 1)
                    {
                        goto case 2;
                    }
                    Hero();
                    conHero = 1;
                    break;
                case 2:
                    Zombie();
                    break;
                case 3:
                    Civic();
                    break;
            }
            if (PerCube.name != "Hero")//if the name of the object is different from that of the hero.
            {
                zomcivnpc.Add(PerCube);//the object is added to the list.
                if (PerCube.name == "Zombie")//if the name equals Zombie.
                {
                    contzom += 1;//the counter is added 1.
                }
                if (PerCube.name == "Civic")//if the name matches Civic.
                {
                    contciv += 1;//the counter is added 1.
                }
            }
            foreach (GameObject go in zomcivnpc)//for each new object and the list.
            {
                if (go.name == "Zombie")//if the new object is equal to Zombie.
                {
                    zomText.text = "Zombie : " + contzom.ToString();//the text appears in the Canvas on the scene.
                }
                if (go.name == "Civic")//if new object equals Civic.
                {
                    civText.text = "Civic : " + contciv.ToString();//the text appears in the Canvas on the scene.
                }
            }
        }
    }
    void Hero()//a function for the Hero class.
    {
        PerCube = GameObject.CreatePrimitive(PrimitiveType.Cube);//to create the hero primitive.
        PerCube.transform.position = new Vector3(corX, 0.5f, corZ);//the hero's cube is placed in a random place.
        PerCube.name = "Hero";//the name of the object is added.
        PerCube.tag = "Hero";
        PerCube.AddComponent<Hero>();//to the hero is added the Hero class.
    }
    void Zombie()//a function for the Zombie class.
    {
        PerCube = GameObject.CreatePrimitive(PrimitiveType.Cube);//to create the zombie primitive.
        PerCube.transform.position = new Vector3(Mathf.Clamp(corX, -45, 45), 0.5f, Mathf.Clamp(corZ, -45, 45));//zombie cubes are placed in random places.
        PerCube.AddComponent<Zombie>();//to the zombie is added the Zombie class.
        PerCube.name = "Zombie";//the name of the object is added.
    }
    void Civic()//a function for the Civic class.
    {
        PerCube = GameObject.CreatePrimitive(PrimitiveType.Cube);//to create the primitive civilian.
        PerCube.transform.position = new Vector3(corX, 0.5f, corZ);//civilian cubes are placed in random places.
        PerCube.name = "Civic";//the name of the object is added.
        PerCube.AddComponent<Civic>();//to the civillian is added the Civic class.
    }
}
public class Instanciar
{
    public readonly int identi;//a readony for the minimum number of objects to be intented.

    public Instanciar()//you become a builder to call it in the Manager class.
    {
        identi = Random.Range(5,15);//he puts on the readony at random.
    }
    
}