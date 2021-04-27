using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    private Transform player;

    public float enemySpeed;
    public float howClose;
    private float distance;

    
    // Start is called before the first frame update
    void Start()
    {
       // enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("NewPlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //grab the distance between the player and the enemy
        distance = Vector3.Distance(player.transform.position, transform.position);
        //if the distance is less than or equal to the set closeness then the enemy will look at the player
        //and follow the player until that closeness is out of reach
        if (distance <= howClose) {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * enemySpeed);
        }
       
        //enemy follows the player 
       // Vector3 enemyFollow = (player.transform.position - transform.position).normalized;
       
        
        //enemy is as fast as the player
       // enemyRB.AddForce(enemyFollow * enemySpeed);
        //destroy the enemy if it falls in the water or collides with a projectile
        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
    }

    

}
