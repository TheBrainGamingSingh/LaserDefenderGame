using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scorekeeper : MonoBehaviour {
	public static int score = 0;
	public Text text;
	void Start(){
		text = GetComponent<Text> ();
		Reset ();
	}
	public void ScoreKeep()
	{
		score += 150;
		text.text = score.ToString ();
	}

	public static void Reset()
	{
		score = 0;
	}
}
