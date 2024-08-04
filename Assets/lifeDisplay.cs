using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeDisplay : MonoBehaviour
{
 

    public GameObject lifeDisplay2;

    public GameObject lifeDisplay1;

    public GameObject lifeDisplay0;



    public void updateLife()
    {
        Debug.Log("updateLife" + gameManager.playerLife);
        

        if(gameManager.playerLife == 2)
        {
            lifeDisplay2.SetActive(true);
        }

        if (gameManager.playerLife == 1)
        {
            lifeDisplay1.SetActive(true);
        }

        if (gameManager.playerLife == 0)
        {
            lifeDisplay0.SetActive(true);
        }
    }

}
