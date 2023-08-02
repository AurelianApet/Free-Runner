using UnityEngine;
using System.Collections;

public class ScoreMover : MonoBehaviour
{

	// Use this for initialization

	public Texture tex200;
	public Texture hdc20;
	public Texture hdc30;

	void Start ()
	{

		//Debug.Log ("INGameUI.glucosa_old:" + INGameUI.glucosa_old);
		//Debug.Log ("INGameUI.glucosa:" + INGameUI.glucosa);

		int carbohidratosConsumidos = INGameUI.glucosa - INGameUI.glucosa_old;

		//Debug.Log (" carbohidratosConsumidos -->" + carbohidratosConsumidos);


		Hashtable ht = new Hashtable ();

		if ( carbohidratosConsumidos == 60 ) {
			// Apple or Sandwich
			GetComponent<Renderer> ().material.mainTexture = hdc20;
		} else if ( carbohidratosConsumidos == 90 ) {
			// Icecream
			GetComponent<Renderer> ().material.mainTexture = hdc30;
		} else if (transform.position.y > 2) {
			INGameUI.scoreCount += 200;
			GetComponent<Renderer> ().material.mainTexture = tex200;
		} else {
			INGameUI.scoreCount += 100;
		}

		if (transform.position.y > 2) {
			ht.Add ("position", transform.position + new Vector3 (0, -3, 0));
		} else {
			ht.Add ("position", transform.position + new Vector3 (0, 3, 0));
		}
		transform.Translate (0, 0, -2);

		ht.Add ("time", 1f);

		switch (Random.Range (0, 6)) {
		case 0:
			ht.Add ("easetype", iTween.EaseType.easeInBounce);
			break;
		case 1:
			ht.Add ("easetype", iTween.EaseType.easeInOutSine);
			break;
		case 2:
			ht.Add ("easetype", iTween.EaseType.easeInExpo);
			break;
		case 3:
			ht.Add ("easetype", iTween.EaseType.easeInOutExpo);
			break;
		case 4:
			ht.Add ("easetype", iTween.EaseType.easeInOutQuart);
			break;
		case 5:
			ht.Add ("easetype", iTween.EaseType.easeInQuad);
			break;
		}
		 
		iTween.MoveTo (gameObject, ht);
		iTween.FadeTo (gameObject, iTween.Hash ("delay", 0.5f, "time", 0.5f, "alpha", 0));
		Destroy (gameObject, 2);

		INGameUI.glucosa_old = INGameUI.glucosa;


	}

}
