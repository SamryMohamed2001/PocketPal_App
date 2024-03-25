using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject startButton;

    [SerializeField] private Text letsGetToKnowYouLabel;
    [SerializeField] private Text avoidance;
    [SerializeField] private Text fear;
    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text resultLabel;
    [SerializeField] private GameObject fearDropdown;
    [SerializeField] private GameObject avoidanceDropdown;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject resultButton;
    [SerializeField] private GameObject againButton;
    [SerializeField] private List<int> fearScores = new List<int>();
    [SerializeField] private List<int> avoidanceScores = new List<int>();
    [SerializeField] private RawImage lsasTestImage;

    private List<LSASItem> lsasItems = new List<LSASItem>();
    private int currentQuestionIndex = 0;
    private int totalFearScore = 0;
    private int totalAvoidanceScore = 0;

    private void Start()
    {
        // Show only LSAS test label and start button
        lsasTestImage.gameObject.SetActive(true);
        startButton.SetActive(true);

        // Hide other elements
        letsGetToKnowYouLabel.gameObject.SetActive(false);
        avoidance.gameObject.SetActive(false);
        fear.gameObject.SetActive(false);
        scoreLabel.gameObject.SetActive(false);
        resultLabel.gameObject.SetActive(false);
        fearDropdown.SetActive(false);
        avoidanceDropdown.SetActive(false);
        nextButton.SetActive(false);
        resultButton.SetActive(false);
        againButton.SetActive(false);

        // Add LSAS items/questions
        AddLSASItems();
    }

    private void AddLSASItems()
    {
        lsasItems.Add(new LSASItem("Using a telephone in public"));
        lsasItems.Add(new LSASItem("Participating in a small group activity"));
        lsasItems.Add(new LSASItem("Eating in public"));
        lsasItems.Add(new LSASItem("Drinking with others"));
        lsasItems.Add(new LSASItem("Talking to someone in authority"));
        lsasItems.Add(new LSASItem("Acting, performing, or speaking in front of an audience"));
        lsasItems.Add(new LSASItem("Going to a party"));
        lsasItems.Add(new LSASItem("Working while being observed"));
        lsasItems.Add(new LSASItem("Writing while being observed"));
        lsasItems.Add(new LSASItem("Calling someone you don't know very well"));
        lsasItems.Add(new LSASItem("Talking face to face with someone you don't know very well"));
        lsasItems.Add(new LSASItem("Meeting strangers"));
        lsasItems.Add(new LSASItem("Urinating in a public bathroom"));
        lsasItems.Add(new LSASItem("Entering a room when others are already seated"));
        lsasItems.Add(new LSASItem("Being the center of attention"));
        lsasItems.Add(new LSASItem("Speaking up at a meeting"));
        lsasItems.Add(new LSASItem("Taking a test of your ability, skill, or knowledge"));
        lsasItems.Add(new LSASItem("Expressing disagreement or disapproval to someone you don't know very well"));
        lsasItems.Add(new LSASItem("Looking someone who you don't know very well straight in the eyes"));
        lsasItems.Add(new LSASItem("Giving a prepared oral talk to a group"));
        lsasItems.Add(new LSASItem("Trying to make someone's acquaintance for the purpose of a romantic/sexual relationship"));
        lsasItems.Add(new LSASItem("Returning goods to a store for a refund"));
        lsasItems.Add(new LSASItem("Giving a party"));
        lsasItems.Add(new LSASItem("Resisting a high pressure sales person"));
    }

    public void StartGame()
    {
        // Hide LSAS test label and start button
        lsasTestImage.gameObject.SetActive(false);
        startButton.SetActive(false);
        againButton.SetActive(false);

        // Show "Let's get to know you" label and other necessary elements
        letsGetToKnowYouLabel.gameObject.SetActive(true);
        avoidance.gameObject.SetActive(true);
        fear.gameObject.SetActive(true);
        scoreLabel.gameObject.SetActive(true);
        fearDropdown.SetActive(true);
        avoidanceDropdown.SetActive(true);
        nextButton.SetActive(true);

       

        // Add event listeners to dropdowns
        Dropdown fearDropdownComponent = fearDropdown.GetComponent<Dropdown>();
        fearDropdownComponent.onValueChanged.AddListener(delegate { UpdateScoreLabel(); });

        Dropdown avoidanceDropdownComponent = avoidanceDropdown.GetComponent<Dropdown>();
        avoidanceDropdownComponent.onValueChanged.AddListener(delegate { UpdateScoreLabel(); });

        // Display first question
        DisplayQuestion();
    }


    public void GoBack()
    {
        if (currentQuestionIndex > 0)
        {
            // Move to the previous question
            currentQuestionIndex--;

            // Update the dropdown values and score label
            UpdateScoreLabel();
        }
    }

    private void UpdateScoreLabel()
    {
        // Calculate current score based on the selected values in the dropdowns
        int currentScore = fearDropdown.GetComponent<Dropdown>().value + avoidanceDropdown.GetComponent<Dropdown>().value;

        // Update score label text
        scoreLabel.text = "Current Score: " + currentScore.ToString();
    }


    public void SubmitResponse()
    {
        // Get selected fear and avoidance ratings from dropdowns
        int fearRating = fearDropdown.GetComponent<Dropdown>().value;
        int avoidanceRating = avoidanceDropdown.GetComponent<Dropdown>().value;

        // Update total fear and avoidance scores
        totalFearScore += fearRating;
        totalAvoidanceScore += avoidanceRating;

        // Save the scores for the current question
        fearScores.Add(fearRating);
        avoidanceScores.Add(avoidanceRating);

        // Move to next question
        currentQuestionIndex++;

        // Display next question
        DisplayQuestion();
    }


    private void DisplayQuestion()
    {
        if (currentQuestionIndex < lsasItems.Count)
        {
            // Display current question
            letsGetToKnowYouLabel.text = lsasItems[currentQuestionIndex].QuestionText;

            // Reset dropdowns to default value
            fearDropdown.GetComponent<Dropdown>().value = 0;
            avoidanceDropdown.GetComponent<Dropdown>().value = 0;

            // Update score label text
            scoreLabel.text = "Current Score: " + (totalFearScore + totalAvoidanceScore).ToString();
        }
        else
        {
            // All questions answered, show result button
            nextButton.SetActive(false);
            resultButton.SetActive(true);
        }
    }

    public void ViewResult()
    {
        // Calculate total LSAS score
        int totalScore = totalFearScore + totalAvoidanceScore;

        // Determine social anxiety severity
        string severity;
        if (totalScore < 30) severity = " no ";
        else if (totalScore < 50) severity = " Mild ";
        else if (totalScore < 65) severity = " Moderate ";
        else if (totalScore < 80) severity = " Marked ";
        else if (totalScore < 95) severity = " Severe ";
        else severity = " Very severe ";

        // Display LSAS score and social anxiety severity
        resultLabel.text = "Your LSAS Score: " + totalScore + "\n\n" + "You have " + severity + " Social Anxiety";

        // Hide other elements and show result label
        letsGetToKnowYouLabel.gameObject.SetActive(false);
        avoidance.gameObject.SetActive(false);
        fear.gameObject.SetActive(false);
        scoreLabel.gameObject.SetActive(false);
        fearDropdown.SetActive(false);
        avoidanceDropdown.SetActive(false);
        nextButton.SetActive(false);
        resultButton.SetActive(false);
        resultLabel.gameObject.SetActive(true);
        againButton.SetActive(true);
    }


    public void TryAgain()
    {
        // Reset scores and current question index
        totalFearScore = 0;
        totalAvoidanceScore = 0;
        currentQuestionIndex = 0;

        // Clear previous responses
        fearScores.Clear();
        avoidanceScores.Clear();

        // Hide result label and try again button
        resultLabel.gameObject.SetActive(false);
        againButton.SetActive(false);

        // Show necessary elements
        lsasTestImage.gameObject.SetActive(true);
        startButton.SetActive(true);
    }
}



public class LSASItem
{
    public string QuestionText { get; }

    public LSASItem(string questionText)
    {
        QuestionText = questionText;
    }
}
