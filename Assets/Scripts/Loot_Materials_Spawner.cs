using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Materials_Spawner : MonoBehaviour
{

    // Start is called before the first frame update
    private float baslangicPozisyonuX; // Objeyinin ba�lang��taki x pozisyonu
    private float gidisMesafesi; // Objeyinin gidip gelece�i mesafe
    private float hiz; // Objeyinin hareket h�z�
    private bool gitYonu = true; // Objeyinin gidi� y�n� (true: ileri, false: geri)

    // Spawnlanacak objelerin prefab'lar�
    public GameObject[] prefabs;

    // Spawn s�resi
    public float spawnSuresi = 1.5f; // �rnek: 2 saniye

    // Spawnlanacak objelerin spawn noktas�
    public Transform spawnNoktasi;

    private float zamanSayaci = 0f;

    void Start()
    {
        // Objeyinin ba�lang��taki x pozisyonunu kaydet
        baslangicPozisyonuX = transform.position.x;

        // Gidilecek mesafeyi ayarla
        gidisMesafesi = 18f; 

        // Hareket h�z�n� ayarla
        hiz = 4f; 
    }
    void Update()
    {
        // Objeyi hareket ettir
        transform.position = new Vector3(
            transform.position.x + (gitYonu ? hiz : -hiz) * Time.deltaTime,
            transform.position.y,
            transform.position.z
        );

        // U� s�n�rlar� kontrol et
        if (gitYonu)
        {
            if (transform.position.x >= baslangicPozisyonuX + gidisMesafesi)
            {
                gitYonu = false;
            }
        }
        else
        {
            if (transform.position.x <= baslangicPozisyonuX)
            {
                gitYonu = true;
            }
        }
        
        // Zaman sayac�n� art�r
        zamanSayaci += Time.deltaTime;

        // Spawn s�resi doldu�unda rastgele obje spawnla
        if (zamanSayaci >= spawnSuresi)
        {
            // Rastgele bir obje prefab'� se�
            int rastgeleIndeks = Random.Range(0, prefabs.Length);
            GameObject obje = Instantiate(prefabs[rastgeleIndeks], spawnNoktasi.position, spawnNoktasi.rotation);

            // Zaman sayac�n� s�f�rla
            zamanSayaci = 0f;
        }

    }
}
