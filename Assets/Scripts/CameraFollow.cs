using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (karakter)
    public float smoothSpeed = 0.125f; // Kameranın hareket yumuşaklığı

    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y+50, target.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);

    }
}