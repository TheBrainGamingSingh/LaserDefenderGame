using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthKeeper : MonoBehaviour {

	int health = 100;
	public Text text;
	void Start(){
		text = GetComponent<Text> ();
	}
	public void HealthKeep()
	{
		health -= 20;
		text.text = health.ToString ();
	}
	
	public void Reset()
	{
		health = 100;
	}
}
