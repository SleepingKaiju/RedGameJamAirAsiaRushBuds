using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPoint : MonoBehaviour
{
    public GameObject gameManager;

    public int fruitCollected;

    public int fruitMax;

    public Animator BamAnim;

    public GameObject taskLock;

    public GameObject objectCollection;

    public GameObject basket;

    public AudioSource basketAudioSource;

    public AudioSource winAudio;
    public AudioSource loseAudio;



    private void OnTriggerStay2D(Collider2D other)
    {

        if(gameManager.GetComponent<gameManager>().timeRemaining > 0)
        {
            if (other.CompareTag("fresh"))
            {
                if (fruitCollected < fruitMax)
                {
                    if (other.GetComponent<DragNDrop>().isDragging == false && other.GetComponent<DragNDrop>().isPicked == true)
                    {
                        Debug.Log("FreshCollected" + fruitCollected);

                        Destroy(other.gameObject);

                        fruitCollected = fruitCollected + 1;

                        BamAnim.SetTrigger("Released");

                        basket.GetComponent<basketSprite>().basketFilled();

                        basketAudioSource.Play();
                    }
                }

                if (fruitCollected >= fruitMax)
                {
                    gameManager.GetComponent<gameManager>().TaskCompleted();

                    taskLock.SetActive(true);

                    objectCollection.GetComponent<ObjectSlideStop>().enabled = false;

                    winAudio.Play();
                    gameObject.GetComponent<CollectionPoint>().enabled = false;

                }


            }

            if (other.CompareTag("rotten"))
            {
                if (other.GetComponent<DragNDrop>().isDragging == false && other.GetComponent<DragNDrop>().isPicked == true)
                {
                    Debug.Log("FreshCollected");

                    Destroy(other.gameObject);

                    BamAnim.SetTrigger("Released");

                    gameManager.GetComponent<gameManager>().TaskFail();
                    taskLock.SetActive(true);

                    objectCollection.GetComponent<ObjectSlideStop>().enabled = false;

                    basketAudioSource.Play();

                    loseAudio.Play();

                    gameObject.GetComponent<CollectionPoint>().enabled = false;

                }
            }
        }
       
    }
}
