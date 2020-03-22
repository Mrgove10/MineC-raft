using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Perlin = TreeEditor.Perlin;
using Random = UnityEngine.Random;

public class World_Generation : MonoBehaviour
{
    public GameObject Cube; //definition du "cube" ce base

    public Material Material_2; //definition des 3 materiaux possible pour le cube
    public Material Material_1;
    public Material Material_0;

    public int Dimention_Base_X; //definition  des dimentions du monde
    public int Dimention_Base_Z;

    public bool Premiere_Generation = true; // definition d'une variable pour savoir si il d'agit de la premiere generationde monde

    // Use this for initialization
    void Start()
    {
        //Debug.Log(DimentionBaseX);
        //Debug.Log(DimentionBaseZ);
        if (Premiere_Generation == true) // si il s'agit de la premiere generation alors 
        {
            //   FonctionGenerationMonde(); // lancer la fonction de generation
            GenerateWorldPerlin();
            Premiere_Generation = false;
        }
    }

    /*  void FonctionGenerationMonde() // fonction de generation
      {
          for (int i = -(Dimention_Base_X / 2); i < Dimention_Base_X; i++) //pour la dimention x je la divise par deux
              //( affin de centrer le monde puis je fait une boucle pour chaque bloque)
          {
              for (int j = -(Dimention_Base_Z / 2); j < Dimention_Base_Z; j++) // meme chose pour la seconde dimantino
              {
                  //GENERATION DE LA BEDROCK
                  GameObject cubeactuel = Cube; // je dit que mon cube actuel est l'objet cube
                  cubeactuel.GetComponent<Renderer>().material = Material_0; // et je lui affect un material
                  GameObject.Instantiate(cubeactuel, new Vector3(i, 0, j), Quaternion.identity); // le clone ce cube a l'endroit actuel
  
                  //GENERATION DE LA COUCHE SUPERIEURE ET DE LA STONE
                  int Hauteur_Min = 1; //definition de la hauteur minimal du monde
                  int Hauteur_Max = 5; // hauteur max
                  int lol = Random.Range(Hauteur_Min, Hauteur_Max); // definitiond'une variable aleatoire entre la hauteur max et min
                  cubeactuel.GetComponent<Renderer>().material = Material_2; // je lui affect le secons mateiaux
                  GameObject.Instantiate(cubeactuel, new Vector3(i, lol, j), Quaternion.identity); // je clone ce cube
  
                  for (int k = 1; k < lol; k++) // si les cube sont entre la bedrock et le dernier alors je cree de la stone
                  {
                      cubeactuel.GetComponent<Renderer>().material = Material_1;
                      GameObject.Instantiate(Cube, new Vector3(i, k, j), Quaternion.identity);
                  }
              }
          }
  
          Premiere_Generation = false; // je dit que mapremiere generation est fini
      }*/


    void GenerateWorldPerlin()
    {
        int xsize = 10;
        int ysize = 10;
    //    global::Perlin p = new global::Perlin();

        for (int i = 0; i < xsize; i++)
        {
            for (int j = 0; j < ysize; j++)
            {
                var p = Mathf.PerlinNoise(i, j);
                Debug.Log(p);
                Instantiate(Cube, new Vector3(i, p, j), Quaternion.identity);
            }
        }
    }
}