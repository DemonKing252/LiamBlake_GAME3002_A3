using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeToStart = 120f;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private Button tutorialBtn;

    [SerializeField]
    private Text userMsg;

    [SerializeField]
    private Text zoneText;

    // Works, because you can't go to the next room until you get the previous key

    private float time = 0f;

    public string activeKey;

    private bool timerActive = false;

    private void Start()
    {
        time = timeToStart;
    }
    private bool passedZone = false;

    [System.Obsolete]
    private void Update()
    {
        if (FindObjectOfType<ThirdPersonCharacter>() != null)
        {
            if (transform.Find("TimerStart") != null)
            {
                if (FindObjectOfType<ThirdPersonCharacter>().transform.position.x >=
                    transform.Find("TimerStart").transform.position.x && !passedZone)
                {
                    FindObjectOfType<GameManager>().AddMessage("Good luck!", 5f);
                    tutorialBtn.gameObject.SetActive(false);
                    // After the player passes the tutorial, start the timer
                    timerActive = true;
                    passedZone = true;
                }
                else if (transform.Find("TimerStart").gameObject == null)
                {
                    print("ERROR: Timer start child not found!");
                }
            }
        }

        if (timerActive)
            time -= Time.deltaTime;

        float seconds = time % 60f;

        int minutes = (int)Mathf.Floor((int)time / 60); // Always round down

        timerText.text = "Time: " + minutes.ToString() + ":" + (seconds < 10f ? "0" : "") + seconds.ToString("F2");

    }

    public void OnSkipTutorial()
    {
        if (FindObjectOfType<ThirdPersonCharacter>() != null)
        {
            if (transform.Find("TimerStart") != null)
            {
                FindObjectOfType<ThirdPersonCharacter>().transform.position = transform.Find("TimerStart").transform.position;
                tutorialBtn.gameObject.SetActive(false);

                FindObjectOfType<GameManager>().AddMessage("Tutorial Skipped. Good luck!", 5f);
            }
        }
    }
    public void AddMessage(string msg, float timeDisplay)
    {
        userMsg.text = msg;
        Invoke("_ResetUserMessage", timeDisplay);
    }
    private void _ResetUserMessage()
    {
        userMsg.text = "";
    }
    public void SetZoneText(string zoneName)
    {
        zoneText.text = "Current Zone: " + zoneName;
    }
}
