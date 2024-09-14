using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject targetsParent; // Assign the "Targets" GameObject here
    public Text timerText;
    public Text scoreMessageText; // Reference to the Score Message UI Text
    public int totalTargets = 5;

    private float timer;
    private int targetsHit;

    void Start()
    {
        timer = 0f;
        targetsHit = 0;
        scoreMessageText.gameObject.SetActive(false); // Hide the message initially
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;
        UpdateTimerText();

        // Check if all targets are hit
        if (targetsHit >= totalTargets)
        {
            StopTimer();
        }
    }

    public void TargetHit()
    {
        targetsHit++;
    }

    void UpdateTimerText()
    {
        timerText.text = $"Time: {Mathf.Round(timer)}s";
    }

    void StopTimer()
    {
        // Show the score message
        scoreMessageText.text = $"You got {Mathf.Round(timer)} seconds!";
        scoreMessageText.gameObject.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }
}
