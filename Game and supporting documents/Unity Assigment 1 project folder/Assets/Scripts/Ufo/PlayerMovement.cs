using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed; //Floating point variable to store the player's movement speed.
    public Text countText;         
    public Text winText;

    private Rigidbody2D rb2d;  //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private int count;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        
        other.gameObject.SetActive(false);

        count = count + 1;

        SetCountText();
}
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 15)
        {
            winText.text = "Winner??";
        }
            
    }
}