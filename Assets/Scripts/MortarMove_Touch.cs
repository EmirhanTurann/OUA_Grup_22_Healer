using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMove_Touch : MonoBehaviour
{
    public Touch touch;
    private Vector3 mouseDragOffset; // Dokunma noktasýna göre ofset deðeri
    private bool isDragging; // Sürükleme iþlemi aktif mi
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        // Objeyi baþlangýçta kinematik hale getirin
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

                OnTouchDown();

            }
            if (touch.phase == TouchPhase.Moved)
            {

                OnTouchMove();

            }
            if (touch.phase == TouchPhase.Ended)
            {

                OnTouchUp();

            }

        }
        void OnTouchDown()
        {
            // Dokunma noktasýný hesaplayýn
            Vector2 touchPosition = Input.touches[0].position;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Ofset deðerini hesaplayýn
            mouseDragOffset = transform.position - worldPosition;

            // Sürükleme iþlemini baþlatýn
           
        }

        void OnTouchMove()
        {
            isDragging = true;
            // Sürükleme iþlemi aktif deðilse geri dönün
            if (!isDragging)
            {
                return;
            }

            // Dokunma hareketini hesaplayýn
            Vector2 touchPosition = Input.touches[0].position;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Yeni konumu hesaplayýn
            Vector3 newPosition = worldPosition + mouseDragOffset;

            // Objeyi yeni konuma taþýyýn
            transform.position = new Vector3( newPosition.x, transform.position.y, transform.position.z );
        }

        void OnTouchUp()
        {
            // Sürükleme iþlemini sonlandýrýn
            isDragging = false;

          //  rb.isKinematic = false;
        }
    }
}
