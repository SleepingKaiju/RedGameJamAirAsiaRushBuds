using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class taskOrangUtan : MonoBehaviour
{
    public string tagToCheck = "TargetTag"; // Tag to check for


    private Collider[] objectsInTrigger; // Array to hold objects inside the trigger

    public GameObject gameManager;

    public string[] stringsToChooseFrom = new string[3]; // Array to hold the strings

    public GameObject prompt;

    public GameObject EiffelTowerPrompt;

    public GameObject KLCCPrompt;

    public GameObject PisaPrompt;


    public TMP_Text categoryName;

    public GameObject taskEnded;
    public GameObject Button;

    public GameObject winLike;
    public Animator winLikeAnim;

    public GameObject loseLike;
    public GameObject objectSpawn;

    public Animator OguAnim;

    public GameObject pointDisplay;

    public AudioSource loseAudio;
    public AudioSource winAudio;


    void Start()
    {
        if (stringsToChooseFrom.Length != 3)
        {
            Debug.LogError("Please provide exactly 3 strings in the array.");
            return;
        }

        string selectedString = GetRandomString();
        Debug.Log("Selected String: " + selectedString);

        tagToCheck = selectedString;

        categoryName.text = selectedString;

        if(selectedString == "categoryA")
        {
            EiffelTowerPrompt.SetActive(true);
        }
        if (selectedString == "categoryB")
        {
            KLCCPrompt.SetActive(true);
        }
        if (selectedString == "categoryC")
        {
            PisaPrompt.SetActive(true);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            Debug.Log("Object with tag " + tagToCheck + " entered the trigger.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            Debug.Log("Object with tag " + tagToCheck + " exited the trigger.");
        }
    }

    public void CheckForObjectsWithTag()
    {



        objectsInTrigger = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);
        bool objectFound = false;

        foreach (Collider col in objectsInTrigger)
        {
            if (col.CompareTag(tagToCheck))
            {
                Debug.Log("Found object with tag " + tagToCheck + " inside the trigger.");
                objectFound = true;

                gameManager.GetComponent<gameManager>().TaskCompleted();

                gameManager.GetComponent<gameManager>().timerIsRunning = false;

                Button.SetActive(false);
                taskEnded.SetActive(true);

                winLike.SetActive(true);
                winLikeAnim.SetTrigger("Trigger");

                prompt.SetActive(false);
                objectSpawn.GetComponent<ObjectSlideStop>().enabled = false;

                OguAnim.StopPlayback();

                OguAnim.SetTrigger("Trigger");

                winAudio.Play();



            }


        }

        if (!objectFound)
        {
            gameManager.GetComponent<gameManager>().TaskFail();

            Debug.Log("No objects with tag " + tagToCheck + " found inside the trigger.");


            gameManager.GetComponent<gameManager>().timerIsRunning = false;

            Button.SetActive(false);
            taskEnded.SetActive(true);

            loseLike.SetActive(true);

            prompt.SetActive(false);

            objectSpawn.GetComponent<ObjectSlideStop>().enabled = false;

            OguAnim.SetTrigger("Trigger");

            loseAudio.Play();

            
        }
    }


    string GetRandomString()
    {
        // Generate a random index between 0 and the length of the array - 1
        int randomIndex = Random.Range(0, stringsToChooseFrom.Length);
        return stringsToChooseFrom[randomIndex];
    }
}
