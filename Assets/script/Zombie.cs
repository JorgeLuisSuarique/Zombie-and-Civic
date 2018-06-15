using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
namespace NPC
{
    namespace Enemy
    {
        public class Zombie : ClaseNPC
        {
            GameObject[] goci;
            public ZombieData ZD;///a struct type varible is crossed.
            int iZomColor;//an integer variable is created for the colors.

            public ZombieData zombiezen()//a struct type function is created.
            {

                return ZD;//the struct type varible is returned.
            }

            void Start()
            {
                base.Herent();
                ZD.zc = (ZomColor)Random.Range(0, 4);//is randomly distributed between 0 and 4.
                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", RandomColor());//the color is added to the zombie.
                ZD.food = (comida)Random.Range(0, 5);//the food is chosen at random between 0 and 5.
                iZomColor = Random.Range(1, 4);//the color is randomly distributed again.
                dat.keepmove = 40 / dat.age;
                //gameObject.tag = "zombie";
            }
            override public void Herent()
            {
                Rot = Random.Range(1, 10);
                Move();
                dat.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
            }
        
            public override void Update()
            {
                base.Update();
                goci = FindObjectsOfType(typeof(GameObject)) as GameObject[];
                float disM = 1000;
                int idx = 0;
                for (int i = 0; i < goci.Length; i++)
                {
                    if (goci[i].GetComponent<Civic>() || goci[i].GetComponent<Hero>())
                    {
                        if (disM > Vector3.Distance(transform.position, goci[i].transform.position))
                        {
                            disM = Vector3.Distance(transform.position, goci[i].transform.position);
                            idx = i;
                        }
                    }
                }
                DisplayOrawline(goci[idx], Color.red);
            }
            Color RandomColor()//a color function is created to read it to the cubes randomly.
            {
                Color randomColor = new Color();//colors are added randomly with a variable.

                if (ZD.zc == ZomColor.cyan)//if the color is cyan.
                {
                    randomColor = Color.cyan;//the color cyan is added.
                }
                else if (ZD.zc == ZomColor.magenta)//if the color is magenta.
                {
                    randomColor = Color.magenta;//the color magenta is added.
                }
                else if (ZD.zc == ZomColor.green)//if the color is green.
                {
                    randomColor = Color.green;//the color green is added.
                }

                return randomColor;//the color variable is returned.
            }
            void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.GetComponent<Civic>())
                {
                    Civic c = collision.gameObject.GetComponent<Civic>();
                    Zombie z = c;
                }
            }

        }
        #region Enum

        public enum comida//a list is made of the zombies' food.
        {
            crebro, torso, braso, mano,
            pierna
        }
        public enum ZomColor//a list is made of the zombie's colors.
        {
            cyan, magenta, green
        }
        #endregion

        public struct ZombieData//the structure is made to be able to call the food, the state and the color to the Zombie class.
        {
            public comida food;//becomes a standard enum variable for food.
            public ZomColor zc;//becomes a standard enum variable for the colors.
        }
    }
}

