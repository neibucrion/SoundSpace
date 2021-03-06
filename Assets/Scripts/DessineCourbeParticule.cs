using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessineCourbeParticule: MonoBehaviour {

	public GameObject controller;
	public ParticleSystem emetteur;
	public float hauteurBlanc = 2f;
    public float hauteurBleu = 1.7f;
    public float hauteurVert = 1.5f;
    public float hauteurRouge = 1.3f;    
	public float hauteurNoir = 1f;
    public float distanceCouleur = 0.2f;
	public float saturation;

    private bool dessinActif = false;

    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("TriggerLeft")) {
			emetteur.Play ();
			dessinActif = true;
		} else if (Input.GetButtonUp ("TriggerLeft")) {
			emetteur.Stop ();
			dessinActif = false;
		}

		if (dessinActif) {
			//changeCouleurEmetteur ();
			couleurHSV();
		}

	}

	void couleurHSV()
	{
		float hauteurActuelle = controller.transform.position.y;
		Color couleur = new Color ();
		if (hauteurActuelle >= hauteurRouge && hauteurActuelle <= hauteurBleu) {
			float hue = ((hauteurActuelle - hauteurRouge) / (hauteurBleu - hauteurRouge)) * 0.7f;
			couleur = Color.HSVToRGB (hue, saturation, 0.5f);
		} else if (hauteurActuelle <= hauteurRouge && hauteurActuelle >= hauteurNoir) {
			float value = 0.5f - (((hauteurRouge - hauteurActuelle) / (hauteurRouge - hauteurNoir)) / 2f);
			couleur = Color.HSVToRGB (0f, 1f, value);
		} else if (hauteurActuelle <= hauteurBlanc && hauteurActuelle >= hauteurBleu) {
			float value = 0.5f + (((hauteurActuelle - hauteurBleu) / (hauteurBlanc - hauteurBleu)) / 2f);
			couleur = Color.HSVToRGB (0.7f, 1f- value, value);
		} else if (hauteurActuelle > hauteurBlanc) {			
			couleur = Color.HSVToRGB (0f, 0f, 1f);
		} else {
			couleur = Color.HSVToRGB (0.7f, 1f, 0f);
		}
		var main = emetteur.main;
		main.startColor = couleur;
	}

    /*void changeCouleurEmetteur()
	{
		float hauteurSphere = controller.transform.position.y;
		Color couleur = new Color ();
		if (hauteurSphere >= hauteurNoir) {
			couleur = Color.black;
		} else if (hauteurSphere < hauteurNoir && hauteurSphere >= hauteurBleu) {
			float valeurNoir = (hauteurNoir - hauteurSphere) / distanceCouleur;
			couleur = new Color (0f, 0f, valeurNoir);
		} else if (hauteurSphere < hauteurBleu && hauteurSphere >= hauteurVert) {
			float valeurVert = 1f - ((hauteurSphere - hauteurVert) / distanceCouleur);
			float valeurBleu = 1f - valeurVert;            
			couleur = new Color (0f, valeurVert, valeurBleu);
		} else if (hauteurSphere < hauteurVert && hauteurSphere >= hauteurRouge) {
			float valeurRouge = 1f - ((hauteurSphere - hauteurRouge) / distanceCouleur);
			float valeurVert = 1f - valeurRouge;
			couleur = new Color (valeurRouge, valeurVert, 0f);
		} else if (hauteurSphere < hauteurRouge && hauteurSphere >= hauteurBlanc) {
			float valeurBlanc = 1f - ((hauteurSphere - hauteurBlanc) / distanceCouleur);
			couleur = new Color (1.0f, valeurBlanc, valeurBlanc);
		} else {
			couleur = Color.white;
		}
		var main = emetteur.main;
		main.startColor = couleur;
		RenderSettings.skybox.SetColor ("_SkyTint", couleur);
		sol.SetColor ("_Color", couleur);
	}*/
}
