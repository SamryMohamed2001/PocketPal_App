using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SinglePlayerTimer : MonoBehaviour
{
    public float timeLimit = 60f; // Time limit in seconds
    public float timer; // Timer variable to keep track of elapsed time
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the UI text element to display the timer
    private bool isRunning = false; // Flag to indicate if the timer is currently running
    private GameController gameController; // Reference to the GameController
    private string selectedWord; // The selected word

    public void Start()
    {
        if (timerText != null)
        {
            timerText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Timer text is not assigned in the inspector or not on the same GameObject.");
        }

        // Find the GameController object in the scene and assign it to gameController
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene.");
        }
    }

    public void StartTimer(string word)
    {
        // Reset the timer to the initial time limit
        timer = timeLimit;
        isRunning = true; // Start the timer
        selectedWord = word; // Store the selected word
        Debug.Log("Timer has Reset");
    }

    public void Update()
    {
        if (isRunning)
        {
            // Decrease the timer by deltaTime
            timer -= Time.deltaTime;

            // Check if timerText is not null before accessing it
            if (timerText != null)
            {
                // Update the UI text to display the remaining time
                timerText.text = "Time: " + Mathf.Round(timer).ToString();
            }
            else
            {
                Debug.LogWarning("timerText is null. Make sure it's properly assigned.");
            }

            // If the timer reaches zero or less, end the game
            if (timer <= 0f)
            {
                timer = 0f; // Ensure the timer does not go negative
                isRunning = false; // Stop the timer
                Debug.Log("Time's up!");
                if (gameController != null)
                {
                    // Activate the lost panel and display the message with the selected word
                    gameController.lostPanel.SetActive(true);
                    gameController.lostGameText.text = "Time's up! The correct word was: " + selectedWord;
                }
                else
                {
                    Debug.LogError("GameController is null. Cannot access lostPanel.");
                }
            }
        }
    }

    public void StopTimer()
    {
        timer = timeLimit;
        isRunning = false;
    }

    public bool IsTimeUp()
    {
        // Check if the timer has run out
        return timer <= 0f;
    }
}
