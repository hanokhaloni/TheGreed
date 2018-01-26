using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRigidBody : MonoBehaviour {
    public float shakeAmount = 22.0f;
    public Renderer transmittingMesh;
    public int PlayerNumber;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Debug.Log("BOOM!");
            transmittingMesh.enabled = true;
            //ShakeMainCamera()
        }
    }

    private void ShakeMainCamera()
    {
        Vector3 cameraLocalPosition = Camera.main.transform.localPosition;
        cameraLocalPosition.x = cameraLocalPosition.x + Random.insideUnitSphere.x* shakeAmount;
        cameraLocalPosition.y = cameraLocalPosition.y + Random.insideUnitSphere.y* shakeAmount + 1.78f;
        Camera.main.transform.localPosition = cameraLocalPosition;
    }
}
