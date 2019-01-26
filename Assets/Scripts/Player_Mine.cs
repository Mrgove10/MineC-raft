using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mine : MonoBehaviour
{
    public float damage = 50f; //variable degat

    public float range = 5f; // varriable distance max

    public Camera MainCamera;// variabe dela camera
    
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // si j'appuie sur le clique droit de ma souris
        {
            Mine(); // alors lance la fonction mine
        }
    }

    void Mine()
    {
        RaycastHit hit; // cree un "lazer"
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, range)) //rentre tout les paramatere du laser comme sa distance et se qu'il resort
        {
            Cube_Manager Cible = hit.transform.GetComponent<Cube_Manager>(); //affect la varriable cible a se queje touche
            if (Cible != null) // si je touche bin un bloc
            {
                Cible.toucher(damage); //lance la fontion toucher avec le parametre degat u cube
            }
           // Debug.Log(hit.transform.name);
        }
    }

}
