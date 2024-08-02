using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Materials_Spawner : MonoBehaviour
{

    // Start is called before the first frame update
    private float baslangicPozisyonuX; // Objeyinin baþlangýçtaki x pozisyonu
    private float gidisMesafesi; // Objeyinin gidip geleceði mesafe
    private float hiz; // Objeyinin hareket hýzý
    private bool gitYonu = true; // Objeyinin gidiþ yönü (true: ileri, false: geri)

    // Spawnlanacak objelerin prefab'larý
    public GameObject[] prefabs;

    // Spawn süresi
    public float spawnSuresi = 1.5f; // Örnek: 2 saniye

    // Spawnlanacak objelerin spawn noktasý
    public Transform spawnNoktasi;

    private float zamanSayaci = 0f;

    void Start()
    {
        // Objeyinin baþlangýçtaki x pozisyonunu kaydet
        baslangicPozisyonuX = transform.position.x;

        // Gidilecek mesafeyi ayarla
        gidisMesafesi = 18f; 

        // Hareket hýzýný ayarla
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

        // Uç sýnýrlarý kontrol et
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
        
        // Zaman sayacýný artýr
        zamanSayaci += Time.deltaTime;

        // Spawn süresi dolduðunda rastgele obje spawnla
        if (zamanSayaci >= spawnSuresi)
        {
            // Rastgele bir obje prefab'ý seç
            int rastgeleIndeks = Random.Range(0, prefabs.Length);
            GameObject obje = Instantiate(prefabs[rastgeleIndeks], spawnNoktasi.position, spawnNoktasi.rotation);

            // Zaman sayacýný sýfýrla
            zamanSayaci = 0f;
        }

    }
}
