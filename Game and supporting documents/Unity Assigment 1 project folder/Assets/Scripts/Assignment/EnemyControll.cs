using UnityEngine;
using System.Collections;

public class EnemyControll : MonoBehaviour
{
    public AudioSource Explosion;
    GameObject TextScoreUIControl;

    public GameObject ExplosionMain;
    float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 2f;

        TextScoreUIControl = GameObject.FindGameObjectWithTag("TextScore Tag");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
  }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShip Tag") || (col.tag == "PlayerBullet Tag"))
        {
            PlayerExplosion();

            TextScoreUIControl.GetComponent<GameScore>().Score += 100; //adds 100 points to the score when an enemy die

            Destroy(gameObject);
        }
    }

    void PlayerExplosion()
    {
        Explosion.Play();

        GameObject explosion = (GameObject)Instantiate(ExplosionMain);

        explosion.transform.position = transform.position;
    }

}
