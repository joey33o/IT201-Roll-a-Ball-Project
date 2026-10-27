using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpForce;
    public float shiftForce;
    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    private Rigidbody rb; 
    private float movementX;
    private float movementY;
    private int count;
    private Transform player;
    private Transform respawnpoint;

    public bool isPaused;

    [SerializeField] public AudioSource PickupSound; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    rb = GetComponent <Rigidbody>(); 
    count = 0;
    SetCountText();
    winTextObject.SetActive(false);
    isPaused = false;
    }
    
     void FixedUpdate() 
   {    
    //Needs 3d vector in order to sphere to move so take 2d var
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
   rb.AddForce(movement*speed); 
  
    if(Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
        rb.AddForce(transform.forward * shiftForce);
    }

    if (Input.GetKeyDown(KeyCode.P))
    {
        // Toggle the pause state
        if (isPaused) // if game is paused 
        {
            Time.timeScale = 1f; // resume the game
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f; // pause the game
            isPaused = true;
        }
   }
   }   
    


       void OnMove (InputValue movementValue)
   {
      //2D vector movement
      Vector2 movementVector = movementValue.Get<Vector2>(); 
      movementX = movementVector.x; 
      movementY = movementVector.y; 

      
   }

      void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 16) 
       {
          winTextObject.SetActive(true);
          Destroy(GameObject.FindGameObjectWithTag("Enemy"));
       }
   }





    void OnTriggerEnter(Collider other) 
   {
      if (other.gameObject.CompareTag("PickUp")) 
       {
         other.gameObject.SetActive(false);

         count= count +1;
         SetCountText();
         PickupSound.Play();
         if(count == 2){
             GameObject.FindWithTag("Door").SetActive(false);
         }
       }
    if (other.gameObject.CompareTag("Respawn"))
    {
        // Set the respawn point to the position of the respawn object
         respawnpoint = other.transform;
    }
    if (other.gameObject.CompareTag("kill-floor"))
   {
       // Respawn the player
       transform.position = respawnpoint.position;
       rb.linearVelocity = Vector3.zero; // Reset velocity to prevent falling through the floor
       rb.angularVelocity = Vector3.zero; // Reset angular velocity

   }
   }


private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       // Destroy the current object
       Destroy(gameObject); 
       // Update the winText to display "You Lose!"
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
   
}


}
