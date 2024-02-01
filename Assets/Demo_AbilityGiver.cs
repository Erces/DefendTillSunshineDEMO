using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_AbilityGiver : MonoBehaviour
{
    public GameObject gun, player,ring;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gun.GetComponent<Gun>().abilityShoot = true;
            player.GetComponent<PlayerMovement>().abilityFish = true;
            player.GetComponent<PlayerMovement>().abilityPickUp = true;
            ring.GetComponent<RingTween>().abilityRing = true;
        }
    }
}
