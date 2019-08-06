using UnityEngine;
using System.Collections;

public class Enemy_1 : MonoBehaviour {
	public GameObject Laser;
	public GameObject boom;
	public Sprite[] hitSprites;
	float firingSpeed = 10f;
	float health = 250f;
	float frequency = 0.5f;
	private Scorekeeper scoreKeep;
	public AudioClip firesound;
	public AudioClip hit;
	public AudioClip explosion;
	void Start()
	{
		scoreKeep = GameObject.Find ("Score").GetComponent<Scorekeeper> ();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile laser = col.gameObject.GetComponent<Projectile> ();
		if (laser) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[1];
			Invoke("Change",0.2f);
			health -= laser.GetDamage();
			if(health <= 0)
				Die ();
			laser.Hit();
			AudioSource.PlayClipAtPoint(hit,transform.position);
		}
	}

	void Change(){
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[0];
	}
	void Update(){
		float probability = Time.deltaTime * frequency;
		//this.GetComponent<SpriteRenderer>().sprite = hitSprites[0];
		if (Random.value < probability) {
			fire ();
		}
	}

	void fire(){
		GameObject beam = Instantiate (Laser, new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3 (0, -firingSpeed, 0);
		AudioSource.PlayClipAtPoint (firesound,transform.position);
	}
	void Die(){
		Destroy (gameObject);
		GameObject explode = Instantiate (boom, transform.position, Quaternion.identity) as GameObject;
		explode.rigidbody2D.velocity = new Vector3 (0, -2, 0);
		scoreKeep.ScoreKeep ();
		AudioSource.PlayClipAtPoint (explosion,transform.position);
	}

}

