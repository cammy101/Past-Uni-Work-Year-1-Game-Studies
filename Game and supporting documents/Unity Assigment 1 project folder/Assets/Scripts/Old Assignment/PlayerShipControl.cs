using UnityEngine;
using System.Collections;

public class PlayerShipControl : MonoBehaviour {

    public GameObject PlayerBulletPrefab;
    public GameObject PlayerBulletPosition1;
    public GameObject PlayerBulletPosition2;
    public float fireRate = 0.5F;
    public float nextFire = 0.0F;
    public float speed;

    private Rigidbody2D shipRigidBody;

    void Start()
    {
        shipRigidBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bulletleft = (GameObject)Instantiate(PlayerBulletPrefab);
            bulletleft.transform.position = PlayerBulletPosition1.transform.position;

            nextFire = Time.time + fireRate;
            GameObject bulletright = (GameObject)Instantiate(PlayerBulletPrefab);
            bulletright.transform.position = PlayerBulletPosition2.transform.position;
        }

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion roat = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = roat;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        float input = Input.GetAxisRaw("Vertical");
        shipRigidBody.AddForce(gameObject.transform.up *speed*input);
    }
}