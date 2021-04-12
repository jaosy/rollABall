using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // reference to ball's Rigidbody
    public float speed; // making it public allows you to set it in the editor without
                        // opening script & recompiling
    private int count; // only available in this script
    public Text countText;
    public Text winText;
    private AudioSource pickupSfx;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        count = 0; 
        updateCountText();
        winText.text = "";
        pickupSfx = GetComponent<AudioSource>();
    }

    // Performed before doing any physics calculations
    void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical"); 
        // The meaning of this value depends on the type of input control,
        // for example with a joystick's horizontal axis a value of 1
        // means the stick is pushed all the way to the right and a value
        // of -1 means it's all the way to the left; a value of 0 means the
        // joystick is in its neutral position.

        Vector3 movement = new Vector3(moveHorizontal,0,moveVertical);
        // y = 0, as we don't want to move up at all

        rb.AddForce(movement * speed);
    }

    // this function will be called when the player object touches
    // the trigger Collider object called "other"
    void OnTriggerEnter(Collider other) 
    {
        // tag allows us to identify a GameObject by it's String tag
        // use with CompareTag method

        // SetActive is the equivalent of the activation checkbox for objects

        if (other.gameObject.CompareTag("Pick Up"))
        {
            pickupSfx.Play();
            other.gameObject.SetActive(false);
            count++;
            updateCountText();
        }
      
    }

    void updateCountText() {
        countText.text = "Score: " + count.ToString();
        if (count >= 8) {
            winText.text = "You win!";
        } 
    }
}
