using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketSprite : MonoBehaviour
{

    public int basketLevel;

    public Sprite basketSprite1;

    public Sprite basketSprite2;

    public Sprite basketSprite3;

    public Sprite basketSprite4;

    public void basketFilled()
    {
        basketLevel = basketLevel + 1;

        if (basketLevel == 1)
        {
            GetComponent<SpriteRenderer>().sprite = basketSprite1;
        }
        if (basketLevel == 2)
        {
            GetComponent<SpriteRenderer>().sprite = basketSprite2;
        }
        if (basketLevel == 3)
        {
            GetComponent<SpriteRenderer>().sprite = basketSprite3;
        }
        if (basketLevel == 4)
        {
            GetComponent<SpriteRenderer>().sprite = basketSprite4;
        }
    }


}
