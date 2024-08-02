using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLootSystem : MonoBehaviour
{
    public Task Task;
    public int[] NecessariesItemsLootCount;
    public bool[] doneNecessariesCount;
    public UIManager UIManager;
    public int CheckDoneNecessariesCount()
    {
        int DoneNecessariesCount = 0;
        for (int i = 0; i < doneNecessariesCount.Length; i++)
        {
            if (doneNecessariesCount[i] == true)
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
            for (int i = 0; i <= Task.necessaries.Length - 1; i++)
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
    }
}
