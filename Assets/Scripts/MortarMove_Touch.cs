using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMove_Touch : MonoBehaviour
{
    public Touch touch;
    private Vector3 mouseDragOffset; // Dokunma noktas�na g�re ofset de�eri
    private bool isDragging; // S�r�kleme i�lemi aktif mi
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        // Objeyi ba�lang��ta kinematik hale getirin
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
            // Dokunma noktas�n� hesaplay�n
            Vector2 touchPosition = Input.touches[0].position;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Ofset de�erini hesaplay�n
            mouseDragOffset = transform.position - worldPosition;

            // S�r�kleme i�lemini ba�lat�n
           
        }

        void OnTouchMove()
        {
            isDragging = true;
            // S�r�kleme i�lemi aktif de�ilse geri d�n�n
            if (!isDragging)
            {
                return;
            }

            // Dokunma hareketini hesaplay�n
            Vector2 touchPosition = Input.touches[0].position;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Yeni konumu hesaplay�n
            Vector3 newPosition = worldPosition + mouseDragOffset;

            // Objeyi yeni konuma ta��y�n
            transform.position = new Vector3( newPosition.x, transform.position.y, transform.position.z );
        }

        void OnTouchUp()
        {
            // S�r�kleme i�lemini sonland�r�n
            isDragging = false;

          //  rb.isKinematic = false;
        }
    }
}
