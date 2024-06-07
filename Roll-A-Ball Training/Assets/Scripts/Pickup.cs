using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // 1. Detect collision 
    // 2. identify objects colliding with this
    // 3. Destroy this if the colliding object is the player 
    // 4. every frame update the rotation of this to this attract the player 

    public int pointValue = 1; // A var to store how many points this pickup is worth

    // This function is called whenever this collider collides with marked as a trigger (this object can be trigger)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject); // Destroy pickup
            GameManager.Instance.totalPickups -= 1; // Tell GameManager to subtract from the total # of pickups
            GameManager.Instance.UpdateScore(pointValue); // Tell GameManager to update the score by 1
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        // Time.deltaTime will make something frame independent 
    }


}
