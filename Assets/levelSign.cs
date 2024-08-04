using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSign : MonoBehaviour
{

    public GameObject level1;

    public GameObject level2;

    public GameObject level3;


    private void Start()
    {
        if(gameManager.playerLevel == 1)
        {
            level1.SetActive(true);
        }

        if (gameManager.playerLevel == 2)
        {
            level2.SetActive(true);
        }

        if (gameManager.playerLevel == 3)
        {
            level3.SetActive(true);
        }
    }

}
