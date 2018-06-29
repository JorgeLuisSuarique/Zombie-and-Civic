using System.Collections;
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

    public GameObject Guns;
    public GameObject gunser;
    public GameObject Mun;
   
    public float GunsDam;
    public static float GunsDamStac;
    public float Force = 9000f;
    private float TimeMy = 0.0f;
    private float Cad;
    public float FireD = 0.05f;
    public Image BarArm;
    int ContMun = 25;
    float MunMax;
    public Text StateArm;

    public static List<GameObject> zomcivnpc = new List<GameObject>();//a list is made for the texts.
    public Text zomText;//becomes a public variable for the text of the Zombie.
    public Text civText;//becomes a public variable for the Civic text.
    public Text infTex;
    int contzom; //a counter is made for the Zombie's text.
    int contciv;//a counter is made for the Civic text.
    int continf;

    public GameObject panelHero;
    public GameObject panelGO;
    public GameObject PanelYG;
    public Text texYG;
    public Text texZGO;
    public Text textZomCiv;

    public int vida = 1000;
    float maxiVida;
    public Image BarVida;
    public GameObject Cur;

    void Awake()
	{
        panelHero.gameObject.SetActive(false);
		Instancias = Random.Range(new Instanciar().identi, IDI);//the objects are instantiated between the construct of the Instanciar and conts class.
        for (int i = 0; i < Instancias; i++)//by the time the cubes are started.
        {
            corX = Random.Range(-45 , 45);//the coordinates on the X axis.
            corZ = Random.Range(-45, 45);//the coordinates on the Z axis.
            Instan = Random.Range(1,5);//the number of cases of the switch.

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
                case 4:
                    Infetc();
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
                if (PerCube.name == "Infect")
                {
                    continf += 1;
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
                if (go.name == "Infect")
                {
                    infTex.text = "Infect : "+ continf.ToString();
                }
                if(contzom == 0 && continf == 0)
                {
                    PanelYG.SetActive(true);
                    texYG.text = "YOU GAME".ToString();
                }
            }
        }
    }
    public void Start()
    {
        maxiVida = vida;
        MunMax = ContMun;
        ActualizeUI();
    }
    public void AplyVida(int dano)
    {
        vida = vida - dano;
        ActualizeUI();
    }
    public void AplyCurar(int RVida)
    {
        vida = vida + RVida;
        ActualizeUI();
    }
    public void ActualizeUI()
    {
        BarVida.fillAmount = (vida / maxiVida);
        BarArm.fillAmount = (ContMun / MunMax);
    }
    public void Disparo(int Dis)
    {
        ContMun = ContMun - Dis;
        ActualizeUI();
    }
    public void Recarga(int Rec)
    {
        ContMun = ContMun + Rec;
        ActualizeUI();
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
    void Infetc()
    {
        PerCube = GameObject.CreatePrimitive(PrimitiveType.Cube);//to create the Infect primitive.
        PerCube.transform.position = new Vector3(Mathf.Clamp(corX, -45, 45), 0.5f, Mathf.Clamp(corZ, -45, 45));//zombie cubes are placed in random places.
        PerCube.AddComponent<Infect>();//to the Infect is added the Infect class.
        PerCube.name = "Infect";//the name of the object is added.
    }
    void Civic()//a function for the Civic class.
    {
        PerCube = GameObject.CreatePrimitive(PrimitiveType.Cube);//to create the primitive civilian.
        PerCube.transform.position = new Vector3(corX, 0.5f, corZ);//civilian cubes are placed in random places.
        PerCube.name = "Civic";//the name of the object is added.
        PerCube.AddComponent<Civic>();//to the civillian is added the Civic class.
    }
    void Object()
    {
        print("fui creado");
        if (Mun)
        {
            Mun.transform.position = new Vector3(corX, 0.5f, corZ);
            Mun.tag = "municion";
           
        }
        if (Cur)
        {
            Cur.transform.position = new Vector3(corX, 0.5f, corZ);
            Cur.tag = "cura";
            
        }
    }

    void Update()
    {
        TimeMy += Time.deltaTime;
        if (Input.GetButton("Fire1") && TimeMy > Cad)
        {
            if (ContMun > 0 && ContMun <= 25)
            {
                Cad = TimeMy + FireD;
                GameObject GunsControl;
                GunsControl = Instantiate(Guns, gunser.transform.position, gunser.transform.rotation) as GameObject;
                Rigidbody rb = GunsControl.GetComponent<Rigidbody>();
                rb.AddRelativeForce(transform.forward * Force);
                Destroy(GunsControl, 2f);
                Cad = Cad - TimeMy;
                TimeMy = 0.0f;
            }
            if (ContMun == 0)
            {
                StateArm.text = "descargado".ToString();
                ContMun = 0;
            }
            
            Disparo(1);
        }
    }
   
}
public class Instanciar
{
    public readonly int identi;//a readony for the minimum number of objects to be intented.
    public readonly int instMC;

    public Instanciar()//you become a builder to call it in the Manager class.
    {
        identi = Random.Range(5,15);//he puts on the readony at random.
        instMC = 6;
    }
    
}