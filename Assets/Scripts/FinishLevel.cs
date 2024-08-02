using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject TransitionMinigameUI;
    public GameObject LoseScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (other.gameObject.GetComponent<CharacterLootSystem>().CheckDoneNecessariesCount() == 2)
            {
                //other.gameObject.GetComponent<CameraFollow>().enabled=false;
                other.gameObject.GetComponent<playerMovementController>().enabled = false;

                TransitionMinigameUI.SetActive(true);
            }
            else
            {
                LoseScreen.SetActive(true);
            }

            

        }


    }

   
}
