using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //This controls the speed
    public float speed = 0;
    //This keeps track of the amount of collectibles
    private int count;
    //This keeps track of the collectible counters text
    public TextMeshProUGUI CountText;
    public GameObject winTextObject;
    //This variable is for the Rigidbody
    private Rigidbody rb;
    //This keeps track of the amount of lives
    private int lives;
    //this keeps track of the text counter for lives
    public TextMeshProUGUI LivesText;
    public GameObject gameoverTextObject;
    //This controls the movement on the X and Y axes
    private float movementX;
    private float movementY; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        lives = 3;
        SetLivesText();
        gameoverTextObject.SetActive(false);
        winTextObject.SetActive(false);
    }

    //Activated once the player input to the keyboard
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            //Set the text value of your text
            winTextObject.SetActive(true);
        }
    }
    void SetLivesText()
    {
        LivesText.text = "Lives: " + lives.ToString();

        if (lives == 0)
        {
            //Set the text value of your text
            gameoverTextObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives--;
            SetLivesText();
        }
    }
}
