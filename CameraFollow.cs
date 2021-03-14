using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 
   
    private GameObject followTarget;

    private Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;

    private void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        targetPosition = new Vector3(followTarget.transform.position.x,
            followTarget.transform.position.y,
            this.transform.position.z);

        
        this.transform.position = Vector3.Lerp(
            this.transform.position, targetPosition,
            cameraSpeed * Time.deltaTime);
    }


}
