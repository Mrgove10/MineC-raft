using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {
	public Button Play_Button; // definition des deux boutons
	public Button Quit_Button;
	// Use this for initialization
	void Start () {
		Play_Button.onClick.AddListener (OnPlayButtonClicked); // ajout un "ecouteur " de click de button
		Quit_Button.onClick.AddListener (OnQuitButtonClicked);
	}

	void OnPlayButtonClicked(){// si le boutton play est appuyer
		SceneManager.LoadScene ("MainScene"); // alors charge la scene
	}

	void OnQuitButtonClicked(){ // si j'appuie sur le bouttonquitter
		Application.Quit (); //alors quite l'application
	}
}
