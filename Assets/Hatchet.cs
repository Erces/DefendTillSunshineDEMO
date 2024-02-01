using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchet : MonoBehaviour
{
    [SerializeField] private int hatchet_damage;
    public bool ableToHit;
    public static Hatchet instance;
    private void Start()
    {
        ableToHit = true;
        if (instance != null)
        {
            Debug.LogWarning("Already hatchet");
            return;
        }
        instance = this;
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger");
        if (col.tag == "Tree" && ableToHit)
        {
            
            SoundEffects.instance.playHatchetSound();
            col.gameObject.GetComponent<Tree>().takeDamage(hatchet_damage);
            CameraShake.Instance.ShakeCamera(2f, .25f);
        }
    }
    public void setAxeTrue()
    {
        ableToHit = true;
    }
    public void setAxeFalse()
    {
        ableToHit = false;
    }
}

