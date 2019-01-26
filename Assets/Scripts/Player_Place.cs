using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Place : MonoBehaviour {
    

    public float range = 5f; // vaiable de distance mac
    public GameObject Cube;
    public Camera MainCamera;
    // Use this for initialization
    public  List<GameObject> myinv = new List<GameObject>(); // je definie un inventaire comme un  liste vide

    public Text CurrectObjectText; // text d'affichage de l'inventaire

    private int curItem; // objet actuelement selectioner
    void Start()
    {
        CurrectObjectText = GameObject.Find("CurrentObjectText").GetComponent<Text>(); // je met l'objet actuel sous forme de text et l'affiche
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) // si j'appuie sur le bouton gauche de ma souri
        {
            Place();//lance la fonction 
        }
        choixBlock(); //a chaque update lance la fonction
    }

    void choixBlock()// fonction du choix du block
    {
        CurrectObjectText.text = myinv[curItem].name; // affiche le nom de l'objet
        var mouv = Input.GetAxis("Mouse ScrollWheel"); // affect le mouvement de lamolette
        if (mouv > 0)//si le desent avace la molette 
        {
            if (curItem < myinv.Capacity-1) // parcours ma list
            {
                curItem++; //augemnte la variable de l'objet actuel
                //Debug.Log(myinv[curItem]);
                //Debug.Log("up, cur = " + curItem);
            }
        }
        if (mouv < 0)// si je monte la molette
        {
            if (curItem > 0) //parcours ma list
            {
                curItem--;// reduit la variablede l'objet actuel
               // Debug.Log(myinv[curItem]);
               // Debug.Log("down, cur = " + curItem);
            }
        }
    }
    void Place() // fonction de placage des blocs
    {
        RaycastHit hit;//definit le lazer
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, range)) //cree le "lazer"
        {
            Transform Cible = hit.transform.GetComponent<Transform>(); // recupere le composant trasnform de la cible 
            if (Cible != null)
            {
                Vector3 incomingVec = hit.normal - Vector3.up; //cree un vector qui va vers le haut et fait la difference avec celui qui touche le cube
                //Debug.Log(incomingVec);

                //ici on fait des verification si chaque vecor a toucher une face particuliere et on place le cube au bon endroit a chqque fois

                if (incomingVec == new Vector3(0, -1, -1))
                {
                    Instantiate(myinv[curItem], new Vector3(Cible.position.x, Cible.position.y, Cible.position.z - 1), Quaternion.identity);
                    //Debug.Log("South");
                }

                if (incomingVec == new Vector3(0, -1, 1))
                {
                    Instantiate(myinv[curItem], new Vector3(Cible.position.x, Cible.position.y , Cible.position.z + 1), Quaternion.identity);
                    //Debug.Log("North");
                }

                if (incomingVec == new Vector3(0, 0, 0))
                {
                    Instantiate(myinv[curItem], new Vector3(Cible.position.x, Cible.position.y+1, Cible.position.z), Quaternion.identity);
                    //Debug.Log("Up");
                }

                if (incomingVec == new Vector3(0, -2, 0))
                {
                    Instantiate(myinv[curItem], new Vector3(Cible.position.x, Cible.position.y-1, Cible.position.z), Quaternion.identity);
                    //Debug.Log("Down");
                }

                if (incomingVec == new Vector3(-1, -1, 0))
                {
                    Instantiate(myinv[curItem], new Vector3(Cible.position.x-1, Cible.position.y, Cible.position.z), Quaternion.identity);
                    //Debug.Log("West");
                }

                if (incomingVec == new Vector3(1, -1, 0))
                {
                    Instantiate(myinv[curItem], new Vector3(Cible.position.x+1, Cible.position.y, Cible.position.z), Quaternion.identity);
                    //Debug.Log("East");
                }
            }
        }
    }
}
