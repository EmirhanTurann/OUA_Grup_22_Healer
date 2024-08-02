using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMove : MonoBehaviour
{
    private Vector3 hedefPozisyon;
    public float hiz = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        // Fare imlecinin ekran koordinatlar�n� al
        Vector3 farePozisyonu = Input.mousePosition;

        // Fare imlecinin d�nya koordinatlar�n� hesapla
        hedefPozisyon = Camera.main.ScreenToWorldPoint(farePozisyonu);

        // Z ve Y eksenini sabit tut
        hedefPozisyon.z = transform.position.z;
        hedefPozisyon.y = transform.position.y;

        // Objeyi hedef pozisyona do�ru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, hedefPozisyon, hiz * Time.deltaTime);
                                             
    }
}
