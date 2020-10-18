using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShipControl2 : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject PlayerBulletPrefab;
    public GameObject PlayerBulletPosition1;
    public GameObject ExplosionMain;
    public GameObject DeathExplosion;
    public GameObject RestartPanel;
    public ScoreManager1 sc;
    public AudioSource laser;
    public AudioSource Explosion;
    public AudioSource DeathExplosionSound;

    public Slider HealthBarPlayer;

    public bool doubleShot;

    public Transform doubleShotPoint1;
    public Transform doubleShotPoint2;

    public int HP;

    public Text TextForLivesUI;

    private Rigidbody2D shipRigidBody;

    const int MaxLives = 3;
    int lives;

    public float fireRate = 0.5F;
    public float nextFire = 0.0F;
    public float speed;

    public void Init()
    {
        lives = MaxLives;

        TextForLivesUI.text = lives.ToString();

        transform.position = new Vector2(0, 0);

        gameObject.SetActive(true);
    }

    void Start()
    {
        doubleShot = false;
    }


    void Update()
    {
        if (Input.GetKey("space") && Time.time > nextFire)
        {
            {
                if (doubleShot)
                {
                    FireBullet();
                    StartCoroutine("DoubleCountDown", 0);
                }

                laser.Play();

                nextFire = Time.time + fireRate;
                GameObject bulletleft = (GameObject)Instantiate(PlayerBulletPrefab);
                bulletleft.transform.position = PlayerBulletPosition1.transform.position;
            }
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);

        HealthBarPlayer.value = HP;
    }

    void Move(Vector2 direction)
    {


        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Debug.Log("Test");
        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position; //I use this to get the player's current position

        pos += direction * speed * Time.deltaTime; //I use this to calculate the new postion

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y); //I use these 2 lines to check and make sure the player's position is not outside the screen

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShip Tag") || (col.tag == "EnemyBullet Tag") || (col.tag == "Hazard"))
        {
            PlayerExplosion();

            HP--;            
        }
        if ((col.tag == "DoubleShot"))
        {
            doubleShot = true;
        }
        if ((col.tag == "NoSoHealthPill"))
        {
            HP--;
        }
        if ((col.tag == "HealthPill"))
        {
            if (HP <=10)
            {
                HP++;
            }
        }
        if (HP==0)
        {
            sc.OnPlayerDestory();
            Destroy(gameObject);
            RestartPanel.SetActive(true);            
        }
     }

    void EndExplosion()
    {
        DeathExplosionSound.Play();

        GameObject explosion = (GameObject)Instantiate(DeathExplosion);

        explosion.transform.position = transform.position;
    }

    void PlayerExplosion()
    {
        Explosion.Play();

        GameObject explosion = (GameObject)Instantiate(ExplosionMain);

        explosion.transform.position = transform.position;
    }

    void FireBullet()
    {
        GameObject Bullet1 = (GameObject)Instantiate(PlayerBulletPrefab);
        Bullet1.transform.position = doubleShotPoint1.transform.position;

        GameObject Bullet2 = (GameObject)Instantiate(PlayerBulletPrefab);
        Bullet2.transform.position = doubleShotPoint2.transform.position;
    }
    IEnumerator DoubleCountDown()
    {
        yield return new WaitForSeconds(8f);
        doubleShot = false;
    }

}