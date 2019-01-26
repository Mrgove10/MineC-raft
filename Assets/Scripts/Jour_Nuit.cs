using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jour_Nuit : MonoBehaviour
{
    public GameObject Soleil; //creation de la variable de type objet soleil
    public Transform MouvementSoleil; //creation de la variable de type transform
    public float Speed = 10f; //creation de la varriable vitesse

	// Use this for initialization
	void Start () {
		Soleil = GameObject.Find("Soleil"); // recherche du soleil
	    MouvementSoleil = Soleil.GetComponent<Transform>(); //affectation du composant transform
	}
	
	// Update is called once per frame
	void Update () {
		MouvementSoleil.Rotate(new Vector3(-1,0,0) * Speed * Time.deltaTime); // a chaue update je fait tourner le solei
	}
}
