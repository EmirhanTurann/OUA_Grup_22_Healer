using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.phase == TouchPhase.Began)
            {
                Debug.Log("Dokundu");
                Debug.Log(parmak.position);
            }
            if (parmak.phase == TouchPhase.Stationary)
            {
                Debug.Log("Dokunuyor");
                Debug.Log(parmak.deltaPosition);
            }
            if (parmak.phase == TouchPhase.Moved)
            {
                Debug.Log("Sürükleniyor");
            }
            if (parmak.phase == TouchPhase.Ended)
            {
                Debug.Log("Dokunma bitti");
            }
        }
    }
}
