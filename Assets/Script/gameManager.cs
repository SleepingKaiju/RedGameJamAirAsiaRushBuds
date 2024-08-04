using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

 
    public static int playerLife;

    public static int playerLevel;


    public int addLife;

    public float timeRemaining;

    public int stageID;

    public bool menu;



    public float stageTime;

    public float level1Time;

    public float level2Time;

    public float level3Time;

    public bool timerIsRunning;

    public GameObject sceneManager;
    public Slider timerSlider;

    public bool taskEnd;
    public float transitionDelay;

    public Animator winCutScene;

    public Animator loseCutScene;

    public Animator LosePointAnim;
    public Animator LosePointBGAnim;

    public GameObject lifeDisplay;

    public Animator transition;


    private void Start()
    {
        if(menu)
        {
            playerLevel = 1;
        }



            playerLife = playerLife + addLife;
            Debug.Log("playerLive" + playerLife);

            // Get the currently active scene
            Scene activeScene = SceneManager.GetActiveScene();

            // Get the index of the currently active scene
            stageID = activeScene.buildIndex;

            Debug.Log("Current Scene Index: " + stageID + "PlayerLevel" + playerLevel);

            if (playerLevel == 1)
            {
                timeRemaining = level1Time;
            }
            if (playerLevel == 2)
            {
            timeRemaining = level2Time;
            }
            if (playerLevel == 3)
            {
                timeRemaining = level3Time;
            }

        if (!menu)
        {

            stageTime = timeRemaining; // Set the total time to the initial time remaining
            timerIsRunning = true; // Start the timer automatically
            timerSlider.maxValue = stageTime; // Set the max value of the slider to the total time
            timerSlider.value = stageTime; // Initialize the slider value

        }

    }


    private void Update()
    {
        if (!menu)
        {
            if (!taskEnd)
            {

                if (timerIsRunning)
                {
                    if (timeRemaining > 0)
                    {
                        timeRemaining -= Time.deltaTime;
                        UpdateSlider(timeRemaining);
                    }
                    else
                    {
                        Debug.Log("Time has run out!");

                        TaskFail();
                        timeRemaining = 0;
                        timerIsRunning = false;
                        // Optionally, trigger any event when the timer runs out
                    }
                }
            }

        }

    }

    void UpdateSlider(float timeToDisplay)
    {
        timerSlider.value = timeToDisplay;
    }

    public void TaskCompleted()
    {

        taskEnd = true;
        Debug.Log("taskComplete");
        StartCoroutine(sceneTransition());
        winCutScene.SetTrigger("triggerCutScene");
        
        
    }

    public void TaskFail()
    {
        taskEnd = true;
        Debug.Log("taskFail");
        StartCoroutine(sceneTransition());
        loseCutScene.SetTrigger("triggerCutScene");

        StartCoroutine(losePointSlide());

        playerLife = playerLife - 1;

        lifeDisplay.GetComponent<lifeDisplay>().updateLife();



    }

    private IEnumerator losePointSlide()
    {
        yield return new WaitForSeconds(2);

        LosePointAnim.SetTrigger("Trigger");

        LosePointBGAnim.SetTrigger("Trigger");
    }


    private IEnumerator sceneTransition()
    {
        yield return new WaitForSeconds(6);

        transition.SetTrigger("Trigger");

        yield return new WaitForSeconds(transitionDelay);


        if(playerLife > 0)
        {

            if (stageID >= 3)
            {
                playerLevel = playerLevel + 1;

               

                if( gameManager.playerLevel <= 3)
                {
                    sceneManager.GetComponent<sceneManager>().sceneChange(1);
                }
                if (gameManager.playerLevel >= 4)
                {
                    sceneManager.GetComponent<sceneManager>().sceneChange(5);
                }
            }

            if (stageID <= 2)

            {
                sceneManager.GetComponent<sceneManager>().sceneChange(stageID + 1);

            }


        }

        if(playerLife <= 0)
        {
            Debug.Log("Player Lose");
            sceneManager.GetComponent<sceneManager>().sceneChange(4);
        }



        
    }

}
