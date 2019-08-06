using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float speed = 7.5f;
	float xmin = -7.5f;
	float xmax = 7.5f;
	public GameObject Laser;
	public GameObject boom;
	float firingSpeed = 10f;
	float firingRate = 0.2f;
	float health = 500f;
	public Sprite[] hitSprites;
	private HealthKeeper healthKeeper;
	public AudioClip fireSound;
	public AudioClip hit;
	// Use this for initialization
	void Start () {
		healthKeeper = GameObject.Find ("Health").GetComponent<HealthKeeper>(); 
	}
	
	// Update is called once per frame
	void Update () {
		//moves the player left and right
		if(Input.GetKey(KeyCode.LeftArrow))
			transform.position += Vector3.left * speed * Time.deltaTime;
		if(Input.GetKey(KeyCode.RightArrow))
			transform.position += Vector3.right * speed * Time.deltaTime;
		//clamps the player in playspace
		float x = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (x, -5f, 0f);

		if (Input.GetKeyDown (KeyCode.Space))
		{
			InvokeRepeating("fire",0.00001f,firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("fire");
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile laser = col.gameObject.GetComponent<Projectile> ();
		if (laser) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[1];
			Invoke("Change",0.1f);
			health -= laser.GetDamage();
			if(health <= 0)
			{
				Die();
			}
			laser.Hit();
			healthKeeper.HealthKeep();
			AudioSource.PlayClipAtPoint(hit,transform.position);
		}
	}
	void Change(){
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[0];
	}
	void fire(){
			GameObject beam = Instantiate (Laser, transform.position + new Vector3(0,1,0), Quaternion.identity) as GameObject ;
			beam.rigidbody2D.velocity = new Vector3(0,firingSpeed,0);
			AudioSource.PlayClipAtPoint (fireSound, transform.position);
		}
	void Die(){
		Destroy (gameObject);
		GameObject explode = Instantiate (boom, transform.position, Quaternion.identity) as GameObject;
		explode.rigidbody2D.velocity = new Vector3 (0, -2, 0);
		Application.LoadLevel("Loss");

	}
}
