using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Transform player;
    public Vector3 distancebetween;
    public MeshRenderer mrenderer;
    public Material transp, normal;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        mrenderer = GetComponent<MeshRenderer>();
        player = GameObject.Find("!MAINCHARACTER").transform;
    }
    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Abs( Vector3.Distance(this.transform.position, player.position));   

        if (dist< 2)
        {
            mrenderer.material = transp;
        }
        else
        {
            mrenderer.material = normal;
        }
    }
}
