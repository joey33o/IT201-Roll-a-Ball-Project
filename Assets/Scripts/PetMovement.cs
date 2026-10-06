using UnityEngine;
public class PetMovement : MonoBehaviour
{ 
    public GameObject player;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            offset = transform.position - player.transform.position; 

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) // if player exists, then move towards the player
       {    
        transform.position = player.transform.position + offset; 
       }
    }
}
