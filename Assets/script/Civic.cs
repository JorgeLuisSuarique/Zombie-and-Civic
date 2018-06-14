using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
namespace NPC
{
    namespace Ally
    {
        public class Civic : ClaseNPC
        {
            GameObject [] gozo;


            public Civicdata civiZen()//a struct type function is created.
            {
                return CInfor;//the struct type varible is returned.
            }
            public Civicdata CInfor;//a struct type varible is crossed.
            void Start()
            {
                base.Herent();
                CInfor.name = (civ)Random.Range(0, 19);//the names of the civilians in the list are added.
                gameObject.tag = "civic";
            }
            override public void Herent()
            {
                
                Rot = Random.Range(1, 10);
                Move();
                dat.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
            }
            //public override void StateReation()
            //{
            //    foreach (GameObject go in Manager.zomcivnpc)
            //    {
            //        if (go.GetComponent<Hero>() || go.GetComponent<Zombie>())
            //        {
            //            float distan = Vector3.Distance(go.transform.position, transform.position);
            //            if (distan <= 5f)
            //            {
            //                transform.position = Vector3.MoveTowards(-transform.position, go.transform.position, dat.keepmove);
            //                Debug.Log("me persiguen");
            //            }
            //        }
            //    }
            //}
            public override void Update()
            {
                base.Update();
                gozo = FindObjectsOfType(typeof(GameObject)) as GameObject[];
                float disM = 1000;
                int idx = 0;
                for ( int i = 0; i < gozo.Length; i++)
                {
                    if (gozo[i].GetComponent<Zombie>())
                    {
                        if (disM > Vector3.Distance(transform.position, gozo[i].transform.position))
                        {
                            disM = Vector3.Distance(transform.position, gozo[i].transform.position);
                            idx = i;
                        }
                    }
                }
                DisplayOrawline(gozo[idx],Color.gray);
            }
            public static implicit operator Zombie(Civic c)
            {
                Zombie z = c.gameObject.AddComponent<Zombie>();
                z.dat.age = c.dat.age;
                
                Destroy(c);
                return z;
            }
        }
    }
}

public enum civ//a list is made of the names of the civilians.
{
    Rodrigues, Willzon, Tomas, Mario, Aliz, Eli,
    Marcelo, Mia, Alonso, Jorge, Winston, Jacobs,
    Silver, Simur, Bart, Lisa, Ned, Ector, Milton,
    Ana
}
public struct Civicdata//the struct is made to be able to call the age and names to the Civic class.
{
    public civ name;//a standard enum variable is made for the names.
}