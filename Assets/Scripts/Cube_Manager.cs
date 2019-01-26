using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Manager : MonoBehaviour
{

    public float hitPoints = 50f;// creation de la vie du cube

    public void toucher(float degat) //creation de la fonction toucher
    {
        hitPoints = hitPoints - degat; // j'enleve mes points de vie 
        if (hitPoints < 0) // si les point de vie sont inferieure a 0
        {
            Destroy(gameObject);// alors detruit le cube
        }
    }
}
