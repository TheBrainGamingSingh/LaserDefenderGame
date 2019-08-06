using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public AudioClip start;
	public AudioClip game;
	public AudioClip end;
	static Music instance = null;
	private AudioSource musicPlayer;
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			musicPlayer = GetComponent<AudioSource>();
			musicPlayer.clip = start;
			musicPlayer.loop = true;
			musicPlayer.Play();
		}
	}
	
	void OnLevelWasLoaded(int level){
		Debug.Log ("Music:" + level);

		musicPlayer.Stop ();
		if (level == 0)
			musicPlayer.clip = start;
		if (level == 1)
			musicPlayer.clip = game;
		if (level == 2)
			musicPlayer.clip = end;
		musicPlayer.Play ();
		musicPlayer.loop = true;
	}
}
