using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 2f; // amount to multiply player's speed by
    public float duration = 5f; // duration of power-up effect

    public GameObject pickupEffect; // visual effect to play when power-up is picked up

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other)); // start power-up effect
        }
    }

    IEnumerator Pickup(Collider player)
    {
        // spawn pickup effect and disable power-up object
        Instantiate(pickupEffect, transform.position, transform.rotation);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //// apply power-up effect to player
        //Player playerMovement = player.GetComponent<Player>();
        //playerMovement.speed *= multiplier;

        //// wait for duration of power-up effect and then disable it
        yield return new WaitForSeconds(duration);
        //playerMovement.speed /= multiplier;

        // destroy pickup effect and power-up object
        Destroy(gameObject);
    }
}

