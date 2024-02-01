using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSituationbyTime : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float thirstspeed;
    [SerializeField] private float hungerspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<PlayerSituation>().waterlevel -= 1 * thirstspeed * Time.deltaTime;
        player.GetComponent<PlayerSituation>().hungerlevel -= 1 * hungerspeed * Time.deltaTime;

    }
}
