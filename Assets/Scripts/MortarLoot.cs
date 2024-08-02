using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarLoot : MonoBehaviour
{
    public Task Task;
    public int[] NecessariesItemsLootCount;
    public LayerMask layer;
    public bool[] doneNecessariesCount;
    public bool isWin;
    public bool isLose;
    public UIManager UIManager;
    public Loot_Materials_Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        Task = GameObject.Find("TaskManagement").GetComponent<Task>();
        UIManager = GameObject.Find("UIManagement").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckDoneNecessariesCount()==2)
        {
            isWin = true;

        }
    }
    int CheckDoneNecessariesCount() 
    {
        int DoneNecessariesCount = 0;
        for (int i = 0; i < doneNecessariesCount.Length; i++)
        {
            if (doneNecessariesCount[i]==true)
            {
                DoneNecessariesCount++;
            }

        }
        return DoneNecessariesCount;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NecessariesItems"))
        {
            

            for (int i = 0; i <= Task.necessaries.Length-1; i++)
            {
                if (Task.necessaries[i].name == other.gameObject.GetComponent<NecessariesItem_info>().prefabName && Task.necessariesCount[i] != NecessariesItemsLootCount[i])
                {
                    NecessariesItemsLootCount[i]++;
                    
                    

                }

                if (Task.necessariesCount[i] == NecessariesItemsLootCount[i])
                {
                    doneNecessariesCount[i] = true;


                }

            }
            UIManager.UI_Update(); 
            Destroy(other.gameObject);

        }

      
        if (other.gameObject.CompareTag("WrongItem"))
        {
            isLose = true;
            Time.timeScale = 0;
            Destroy(other.gameObject);
        }

      
    }

}
