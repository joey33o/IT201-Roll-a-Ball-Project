using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{ 
    public Transform Player; //knows where player is
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

     // to know where it  can move
    navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) // if player exists, then move towards the player
       {    
           navMeshAgent.SetDestination(Player.position);
       }
    }
}
