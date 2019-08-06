using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Level Load "+ name);
		Application.LoadLevel (name);
	}
	public void QuitRequest(){
		Debug.Log ("Quit Request!");
		Application.Quit();
	}

	public void LoadNextLevel(){
		Application.LoadLevel (Application.loadedLevel +1);

	}



}
//TODO 1. Sounds
	// 2. High Score
	// 3. Instructions
	// 4. Level Indicator
