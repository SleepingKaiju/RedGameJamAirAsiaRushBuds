using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaggagePoint : MonoBehaviour
{
    public int baggageMax;
    public int baggageCurrent;

    public GameObject gameManager;

    public Animator BigieAnim;

    public AudioSource panicAudio;
    public AudioSource loseAudio;
    public AudioSource winAudio;

    public AudioSource itemIn;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("legal"))
        {

            itemIn.Play();
            baggageCurrent = baggageCurrent + 1;

                if(baggageCurrent >= 3)
                {
                BigieAnim.SetTrigger("Trigger");
                    gameManager.GetComponent<gameManager>().TaskCompleted();

                    GetComponent<BaggagePoint>().enabled = false;
                    panicAudio.Stop();
                winAudio.Play();
            }
        }



        if (other.CompareTag("illegal"))
        {
            itemIn.Play();
            gameManager.GetComponent<gameManager>().TaskFail();
            GetComponent<BaggagePoint>().enabled = false;
            loseAudio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("legal"))
        {


            baggageCurrent = baggageCurrent - 1;

        }

    }


}
