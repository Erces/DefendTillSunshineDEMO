using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] clips_snow,clips_wood,clips_rock,clips_dogsound;
    public Transform foot;
    public LayerMask ground;
    public AudioClip start, middle, end;
    

    public AudioSource audioSource;
    
    
    // Update is called once per frame
    public void Step()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(foot.position, Vector3.down, out hit, 2, ground))
        {
            
            if (hit.transform.tag == "Rock")
            {
                AudioClip clip = GetRandomClipRock();
                audioSource.PlayOneShot(clip);
            }
            else if(hit.transform.tag == "Wood")
            {
                AudioClip clip = GetRandomClipWood();
                audioSource.PlayOneShot(clip);
            }
            else
            {
                AudioClip clip = GetRandomClipSnow();
                audioSource.PlayOneShot(clip);
            }
        }
        
    }
    public void StartFishing()
    {
        audioSource.PlayOneShot(start);
    }
    public void MiddleFishing()
    {
        audioSource.PlayOneShot(middle);
    }
    public void EndFishing()
    {
        audioSource.PlayOneShot(end);
    }
    public void StepDog()
    {
        RaycastHit hit;
        if (Physics.Raycast(foot.position, Vector3.down, out hit, 2, ground))
        {
            
            if (hit.transform.tag == "Rock")
            {
                AudioClip clip = GetRandomClipRock();
                audioSource.PlayOneShot(clip);
            }
            else if (hit.transform.tag == "Wood")
            {
                AudioClip clip = GetRandomClipWood();
                audioSource.PlayOneShot(clip);
            }
            else
            {
                AudioClip clip = GetRandomClipSnow();
                audioSource.PlayOneShot(clip);
            }
        }

    }

    public void SoundDog()
    {
        Debug.Log("SOUNDDOG!");
        AudioClip clip = GetRandomClipDogSound();
        audioSource.PlayOneShot(clip);
    }
    private AudioClip GetRandomClipSnow()
    {
        return clips_snow[UnityEngine.Random.Range(0, clips_snow.Length)];
    }
    private AudioClip GetRandomClipWood()
    {
        return clips_wood[UnityEngine.Random.Range(0, clips_wood.Length)];
    }
    private AudioClip GetRandomClipRock()
    {
        return clips_rock[UnityEngine.Random.Range(0, clips_rock.Length)];
    }
    private AudioClip GetRandomClipDogSound()
    {
        return clips_dogsound[UnityEngine.Random.Range(0, clips_rock.Length)];
    }
}
