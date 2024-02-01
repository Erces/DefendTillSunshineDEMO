using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BuildSystem : MonoBehaviour
{
  
    public CinemachineVirtualCamera kamera;
    public CinemachineBrain brain;
    public LayerMask layer;
    public GameObject previewGameObject = null;
    public Preview previewScript = null;
    public GameObject particle;
    public float stickTolerance = 1.5f;

    public bool isBuilding = false;
    private bool pauseBuilding = false;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            previewGameObject.transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            CancelBuild();
        }
        if (Input.GetMouseButtonDown(0) && isBuilding)
        {
            if (previewScript.GetSnapped())
            {

                StopBuild();
                previewGameObject = null;
                previewScript = null;
                isBuilding = false;
            }
            else
            {
                Debug.Log("Not snapped!");
            }
        }
        if (isBuilding)
        {
            if (pauseBuilding)
            {
                Debug.Log("Building paused");
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");
                if (Mathf.Abs(mouseX) > stickTolerance || Mathf.Abs(mouseY)> stickTolerance)
                {
                    pauseBuilding = false;
                }
            }
            else
            {
                DoBuildRay();
            }
        }
    }
    public void NewBuild(GameObject _go)
    {
        previewGameObject = Instantiate(_go, Vector3.zero, Quaternion.identity);
        previewScript = previewGameObject.GetComponent<Preview>();
        isBuilding = true;
    }
    public void CancelBuild()
    {
        Destroy(previewGameObject);
        previewGameObject = null;
        previewScript = null;
        isBuilding = false;
    }
    private void StopBuild()
    {
       
        GameObject partic = Instantiate(particle, previewGameObject.transform.position + (Vector3.up * 0.2f), Quaternion.identity);
        previewScript.Place();
        previewGameObject = null;
        previewScript = null;
        isBuilding = false;
    }

    public void PauseBuild(bool _value)
    {
        pauseBuilding = _value;
    }
    private void DoBuildRay()
    {
        Ray ray = brain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, 10f, layer))
        {
            float y = hit.point.y + previewGameObject.transform.localScale.y / 2f;
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            previewGameObject.transform.position = pos;
        
        }
    }
}
