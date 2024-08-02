using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public Task task;
    public Sprite[] necessariesPhotos;
    public GameObject Sprites;
    public GameObject Counter;
    public GameObject Mortar;
    public GameObject Player;
    public GameObject winScreen;
    public GameObject LoseScreen;

    // Start is called before the first frame update
    void Start()
    {
        task = GameObject.Find("TaskManagement").GetComponent<Task>();
        Mortar = GameObject.Find("mortar");

        for (int i = 0; i <= task.necessaries.Length-1; i++)
        {
            necessariesPhotos[i] = task.necessaries[i].GetComponent<NecessariesItem_info>().prefabPhoto;
            Sprites.transform.GetChild(i).GetComponent<Image>().sprite = necessariesPhotos[i];
            if (Mortar!=null)
            {
                Counter.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = task.necessariesCount[i].ToString() + " / " + Mortar.GetComponent<MortarLoot>().NecessariesItemsLootCount[i].ToString();
            }
            else
            {
                Counter.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = task.necessariesCount[i].ToString() + " / " + Player.GetComponent<CharacterLootSystem>().NecessariesItemsLootCount[i].ToString();
            }
            

          //  Counter.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = 0 + " / " + 2;

        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Mortar != null)
        {

        
        if (Mortar.GetComponent<MortarLoot>().isWin==true)
        {
            winScreen.SetActive(true);
        }
        if (Mortar.GetComponent<MortarLoot>().isLose == true)
        {
            LoseScreen.SetActive(true);
        }
        }
    }

    public void UI_Update() 
    {

        for (int i = 0; i <= Counter.transform.childCount-1; i++)
        {
            if (Mortar != null)
            {
                Counter.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = task.necessariesCount[i].ToString() + " / " + Mortar.GetComponent<MortarLoot>().NecessariesItemsLootCount[i].ToString();
            }
            else
            {
                Counter.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = task.necessariesCount[i].ToString() + " / " + Player.GetComponent<CharacterLootSystem>().NecessariesItemsLootCount[i].ToString();
            }
               
            


        }


     }
}
