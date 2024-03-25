using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.Video;
using static GameController;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject gameSelectionPanel;
    [SerializeField] private GameObject wordGameOptionsPanel;
    [SerializeField] private GameObject wordGenerationPanel;
    [SerializeField] private GameObject questionGenerationPanel;
    [SerializeField] private GameObject startGamePanel;
    [SerializeField] private GameObject startGame1Panel;
    [SerializeField] private GameObject congratulationsPanel;
    [SerializeField] public GameObject lostPanel;
    [SerializeField] private GameObject quizResultsPanel;
    [SerializeField] private GameObject multiplayerPanel;
    [SerializeField] private GameObject player1Panel;
    [SerializeField] private GameObject player2Panel;
    [SerializeField] private GameObject multiplayerResults;
    [SerializeField] private InputField letterInputField;
    [SerializeField] private TextMeshProUGUI wordDisplayText;
    [SerializeField] private TextMeshProUGUI hintDisplayText;
    [SerializeField] private TextMeshProUGUI gameDescriptionText;
    [SerializeField] private Button singlePlayerButton;
    [SerializeField] private Button multiPlayerButton;
    [SerializeField] private Button wordGameButton;
    [SerializeField] private Button quizGameButton;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button startQuizGameButton;
    [SerializeField] private TextMeshProUGUI wonGametext;
    [SerializeField] private Button goBackWon;
    [SerializeField] public  TextMeshProUGUI lostGameText;
    [SerializeField] private Button goBackLost;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button playOnceAgainButton;
    [SerializeField] private Button quizNextButton;
    [SerializeField] private Button quizStopButton;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TMP_Dropdown questionTypeDropdown;
    [SerializeField] private TextMeshProUGUI questionLabel;
    [SerializeField] private TextMeshProUGUI quizResultsText;
    [SerializeField] private Button quizPlayAgainButton;
    [SerializeField] private Button quizBackToGameSelectionButton;
    [SerializeField] private TextMeshProUGUI playerword;
    [SerializeField] private TMP_InputField player1input;
    [SerializeField] private TMP_InputField player2input;
    [SerializeField] private Button close;
    [SerializeField] private Button playMultiAgain;
    [SerializeField] private Button choosegames;
    [SerializeField] private Button nextMulti;
    [SerializeField] TextMeshProUGUI multiplayersResults;
    [SerializeField] private Button singleBackButton;


    private List<string> wordList = new List<string>();
    private string selectedWord;
    private List<char> revealedLetters = new List<char>();
    private SinglePlayerTimer timerScript; // Reference to the TimerScript component
    private List<Question> questionList = new List<Question>();
    private int currentQuestionIndex = 0;
    private char correctAnswer;
    // Keep track of player scores and rounds played
    private int player1Score = 0;
    private int player2Score = 0;
    private string path = "Questions";



    void Start()
    {
        //questionTypeDropdown.value = -1;

        timerScript = new SinglePlayerTimer();
        timerScript.StopTimer();

        LoadWordList();
        gameSelectionPanel.SetActive(true);
        wordGameOptionsPanel.SetActive(false);
        startGame1Panel.SetActive(false); // Ensure startGame1Panel is initially inactive
        wordGenerationPanel.SetActive(false);
        questionGenerationPanel.SetActive(false);
        startGamePanel.SetActive(false);
        congratulationsPanel.SetActive(false);
        lostPanel.SetActive(false);
        quizResultsPanel.SetActive(false);
        // Disable the multiplayer panel at first
        multiplayerPanel.gameObject.SetActive(false);
        multiplayerResults.SetActive(false);

        // Set up button click events
        singlePlayerButton.onClick.AddListener(StartSinglePlayerGame);
        multiPlayerButton.onClick.AddListener(SetupMultiplayer);
        wordGameButton.onClick.AddListener(ShowWordGameOptions);
        quizGameButton.onClick.AddListener(ShowQuizGameOptions); // Assign the method to the quiz game button
        startGameButton.onClick.AddListener(StartGame);
        goBackWon.onClick.AddListener(Start);
        goBackLost.onClick.AddListener(Start);
        startQuizGameButton.onClick.AddListener(StartQuizGame);
        playAgainButton.onClick.AddListener(PlayAgain);
        playOnceAgainButton.onClick.AddListener(PlayAgain);
        letterInputField.onEndEdit.AddListener(OnLetterEnteredSingle);
        close.onClick.AddListener(Start);
        playMultiAgain.onClick.AddListener(PlayPlayerAgain);
        choosegames.onClick.AddListener(Start);
        player1input.onEndEdit.AddListener(OnLetterEnteredMulti);
        player2input.onEndEdit.AddListener(OnLetterEnteredMulti);
        quizNextButton.onClick.AddListener(DisplayNextQuestion);
        quizStopButton.onClick.AddListener(Start);
        questionTypeDropdown.onValueChanged.AddListener(OnAnswerSelected);
        quizPlayAgainButton.onClick.AddListener(StartQuizGame);
        quizBackToGameSelectionButton.onClick.AddListener(Start);
        nextMulti.onClick.AddListener(ActivateMultiplayerPanel);
        singleBackButton.onClick.AddListener(Start);
        SetupMultiplayer();

        if (multiplayerPanel == null)
        {
            Debug.LogError("MultiplayerPanel is not assigned in the GameController script.");
        }
        else
        {
            Debug.Log("MultiplayerPanel is properly assigned.");
        }
    }



    void StartSinglePlayerGame()
    {


        // Hide the word generation panel
        wordGenerationPanel.SetActive(false);

        // Show the start game panel
        startGamePanel.SetActive(true);
        
        // Ensure that the SinglePlayerTimer component is already attached to the same GameObject
        timerScript = GetComponent<SinglePlayerTimer>();

        LoadWordList();
        selectedWord = SelectRandomWord();
        revealedLetters.Clear();
        InitializeDisplayedWord(selectedWord);

    }

    void LoadWordList()
    {
        TextAsset wordData = Resources.Load<TextAsset>("Collins Scrabble Words (2015)");
        if (wordData != null)
        {
            StringReader reader = new StringReader(wordData.text);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                wordList.Add(line.ToUpper()); // Convert words to uppercase for consistency
            }
        }
        else
        {
            Debug.LogError("Unable to load word list. Make sure the CSV file is in the 'Resources' folder.");
        }
    }

    public string SelectRandomWord()
    {
        if (wordList.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, wordList.Count);
            return wordList[randomIndex];
        }
        else
        {
            Debug.LogError("Word list is empty.");
            return "NoWord";
        }
    }

    public void InitializeDisplayedWord(string word)
    {
        // Clear the previous text
        wordDisplayText.text = "";
        hintDisplayText.text = "";
        hintDisplayText.text = "Hints (Not all of these hints are correct!): ";

        // Randomly reveal some letters in the word for display
        for (int i = 0; i < word.Length; i++)
        {
            if (UnityEngine.Random.Range(0f, 1f) < 0.5f || revealedLetters.Contains(word[i]))
            {
                wordDisplayText.text += word[i]; // Display the letter
                revealedLetters.Add(word[i]); // Add the revealed letter to the list
            }
            else
            {
                wordDisplayText.text += "_"; // Display a blank
            }
        }

        // Add spacing to separate the displayed word and hints
        wordDisplayText.text += "\n";

        // Display hints with some revealed letters from the displayed word and some wrong letters
        int hintLength = Mathf.Min(word.Length, 7); // Limit the hint length to 6 characters
        for (int i = 0; i < hintLength; i++)
        {
            char currentLetter = word[i];
            if (revealedLetters.Contains(currentLetter))
            {
                // If the letter is revealed in the displayed word, display it as a hint
                hintDisplayText.text += currentLetter;
            }
            else if (UnityEngine.Random.Range(0f, 1f) < 0.5f)
            {
                // Randomly reveal some of the blank letters as hints
                hintDisplayText.text += currentLetter;
            }
            else
            {
                // Add a wrong letter as a hint
                char randomWrongLetter = GetRandomWrongLetter();
                hintDisplayText.text += randomWrongLetter;
            }
        }
    }

    // Function to get a random wrong letter (can be adjusted as needed)
    private char GetRandomWrongLetter()
    {
        // Assuming 'A' to 'Z' are valid letters
        return (char)UnityEngine.Random.Range('A', 'Z' + 1);
    }



    void FillInBlankSpaces(char enteredLetter)
    {
        string updatedWordDisplay = ""; // Initialize an empty string to store the updated word display

        // Iterate through each character in the selected word
        for (int i = 0; i < selectedWord.Length; i++)
        {
            // Check if the current character matches the entered letter or if it's already revealed
            if (selectedWord[i] == enteredLetter || revealedLetters.Contains(selectedWord[i]))
            {
                // Append the matched character to the updated word display
                updatedWordDisplay += selectedWord[i];
            }
            else
            {
                // Append a blank space to represent an unrevealed letter
                updatedWordDisplay += "_";
            }
        }

        // Update the word display text with the updated word display
        wordDisplayText.text = updatedWordDisplay;
    }

    void CalculatePlayersScores()
    {
        // Update the multiplayer results text
        multiplayersResults.text = "Warrior 1 Score: " + player1Score + "\n" +
                                   "Warrior 2 Score: " + player2Score;
        // Show the multiplayer results panel
        multiplayerResults.SetActive(true);
        multiplayerPanel.gameObject.SetActive(false);
    }



    public void OnLetterEnteredSingle(string input)
    {
        if (input.Length == 1 && char.IsLetter(input[0])) // Check if input is a single letter
        {
            char letter = char.ToUpper(input[0]); // Convert input to uppercase to match the word

            bool correctGuess1 = false;

            // Check if the guessed letter is in the selected word
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == letter)
                {
                    // Update the displayed word to reveal the guessed letter at all occurrences
                    FillInBlankSpaces(letter);
                    revealedLetters.Add(letter); // Add the revealed letter to the list
                    correctGuess1 = true;
                }
            }

            // Check if all letters are revealed
            if (AllLettersGuessed())
            {
                // Display results and proceed to next word
                timerScript.StopTimer();
                DisplayCongratulationsPanel();
                wonGametext.text = "You won! The correct word was: " + selectedWord;
            }
        }
        else
        {
            Debug.Log("Incorrect guess. Try again.");
        }

        // Check if the timer is up and the word has not been guessed
        if (timerScript.IsTimeUp() && !AllLettersGuessed())
        {
            Debug.Log("Tiem");
            // If the timer is up and the word has not been guessed, show the lost panel
            ShowLostPanel(selectedWord);
            lostGameText.text="You lost! The Correct word was: " + selectedWord;
        }
    }

    public void ShowLostPanel(string correctWord)
    {
        lostPanel.SetActive(true); // Show the lost panel
    }

    public void OnLetterEnteredMulti(string input)
    {
        if (input.Length == 1 && char.IsLetter(input[0])) // Check if input is a single letter
        {
            char letter = char.ToUpper(input[0]); // Convert input to uppercase to match the word

            bool correctGuess = false;

            // Check if the guessed letter is in the selected word
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == letter)
                {
                    // Update the displayed word to reveal the guessed letter at all occurrences
                    FillInBlankSpaces(letter);
                    revealedLetters.Add(letter); // Add the revealed letter to the list
                    correctGuess = true;
                    UpdateMultiplayerWordForOpponent(letter);
                    UpdateWordForPlayer1(letter);
                }
            }

        }
    }

    void PlayPlayerAgain()
    {
        // Reset scores and rounds played
        player1Score = 0;
        player2Score = 0;
       

        multiplayerPanel.SetActive(true);


        // Reset the word display
        wordDisplayText.text = "";

        // Clear the revealed letters list
        revealedLetters.Clear();

        
    }

    public void UpdateMultiplayerWordForOpponent(char guessedLetter)
    {
        // Check if it's Player 1's turn to guess
        if (multiplayerPanel.activeSelf)
        {
            bool correctGuess1 = false;

            // Check if the Player 2 input field is filled
            if (!string.IsNullOrEmpty(player2input.text))
            {
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (selectedWord[i] == guessedLetter)
                    {
                        playerword.text = ReplaceCharInWord(playerword.text, guessedLetter, i);
                        //player1word.text = ReplaceCharInWord(player1word.text, guessedLetter, i);
                        correctGuess1 = true;
                        Debug.Log("Player 2 got a point");
                    }
                }
            }

            // Increment Player 2's score if they made a correct guess
            if (correctGuess1)
            {
                player2Score++;
                Debug.Log("Player 2 score increased");
            }

        }
    }


    public void UpdateWordForPlayer1(char guessedLetter)
    {
        // Check if it's Player 1's turn to guess
        if (multiplayerPanel.activeSelf)
        {
            bool correctGuess = false;
            // Debug.Log("Player 1");

            // Check if the Player 1 input field is filled
            if (!string.IsNullOrEmpty(player1input.text))
            {
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (selectedWord[i] == guessedLetter)
                    {
                        playerword.text = ReplaceCharInWord(playerword.text, guessedLetter, i);
                        //player2word.text = ReplaceCharInWord(player2word.text, guessedLetter, i);
                        correctGuess = true;
                        Debug.Log("Player 1 got a point");
                        // CalculatePlayersScores();

                    }
                }
            }

            if (correctGuess)
            {
                player1Score++;
                Debug.Log("Player 1 score increased");
                
            }
        }
    }


    string ReplaceCharInWord(string word, char letter, int index)
    {
        string newWord = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (selectedWord[i] == letter)
            {
                newWord += letter;
            }
            else
            {
                newWord += word[i];
            }
        }
        return newWord;
    }

   
    bool AllLettersGuessed()
    {
        // Check if revealedLetters or selectedWord is null
        if (revealedLetters == null || selectedWord == null)
        {
            Debug.LogError("revealedLetters or selectedWord is null.");
            return false; // Return false to handle the error gracefully
        }

        // Check if all letters in the selected word have been revealed
        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (!revealedLetters.Contains(selectedWord[i]))
            {
                return false;
            }
        }
        return true;
    }



    private void SetupMultiplayer()
    {
        // Hide the multiplayer panel by default
        multiplayerPanel.gameObject.SetActive(false);

        // Add a listener to the multiplayer button to activate the multiplayer panel
        multiPlayerButton.onClick.AddListener(ActivateMultiplayerPanel);
    }

    private void ActivateMultiplayerPanel()
    {
        // Hide the game selection panel
        gameSelectionPanel.SetActive(false);

        // Activate the multiplayer panel
        multiplayerPanel.gameObject.SetActive(true);

        // Update the multiplayer word
        UpdateMultiplayerWord();
    }


    public void UpdateMultiplayerWord()
    {
        // Generate a single word
        selectedWord = SelectRandomWord();
        Debug.Log(selectedWord);

        // Determine the positions where blanks will be inserted
        List<int> blankPositions = new List<int>();
        int wordLength = selectedWord.Length;
        int numberOfBlanks = Mathf.FloorToInt(wordLength * 0.3f); // Adjust the percentage of blanks as needed

        // Generate random positions for the blanks
        for (int i = 0; i < numberOfBlanks; i++)
        {
            int randomPosition;
            do
            {
                randomPosition = UnityEngine.Random.Range(0, wordLength);
            } while (blankPositions.Contains(randomPosition)); // Ensure each position is unique
            blankPositions.Add(randomPosition);
        }

        // Update the text displays for each player with the word containing blanks
        string wordWithBlanks = "";
        for (int i = 0; i < wordLength; i++)
        {
            if (blankPositions.Contains(i))
            {
                wordWithBlanks += "_"; // Insert a blank at the position
            }
            else
            {
                wordWithBlanks += selectedWord[i]; // Use the original letter
            }
        }

        // Update the text displays for each player with the same word containing blanks
        playerword.text = wordWithBlanks;
    }


    void DisplayCongratulationsPanel()
    {
        timerScript.StopTimer();
        congratulationsPanel.SetActive(true); // Show the congratulations panel
    }

    void PlayAgain()
    {
        // Hide the congratulations panel
        congratulationsPanel.SetActive(false);

        // Hide the lost panel
        lostPanel.SetActive(false);

        // Reset the word display
        wordDisplayText.text = "";

        // Clear the revealed letters list
        revealedLetters.Clear();

        // Start a new single-player game
        StartSinglePlayerGame();
        // timerScript.Start();

        // Reset the timer
        timerScript.StartTimer(selectedWord);

    }



    void ShowWordGameOptions()
    {
        // Hide the game selection panel
        gameSelectionPanel.SetActive(false);

        // Show the Word Game options panel
        wordGameOptionsPanel.SetActive(true);
    }

    void ShowQuizGameOptions()
    {
        // Hide the game selection panel
        gameSelectionPanel.SetActive(false);

        // Show the start game panel for quiz
        startGame1Panel.SetActive(true);

        // Hide other panels
        wordGameOptionsPanel.SetActive(false);
        wordGenerationPanel.SetActive(false);

        // Initialize the question generation panel
        questionGenerationPanel.SetActive(false);

        // Clear the question list
        questionList.Clear();

    }



    void StartGame()
    {
        path = "Questions";
        LoadQuestionsFromFile();

        // Hide the start game panel
        startGamePanel.SetActive(false);

        // Show the word generation panel
        wordGenerationPanel.SetActive(true);
        // Ensure that the SinglePlayerTimer component is already attached to the same GameObject
        timerScript = GetComponent<SinglePlayerTimer>();

        if (timerScript == null)
        {
            // If the timerScript is still null, create a new instance and add it to the GameObject
            timerScript = gameObject.AddComponent<SinglePlayerTimer>();
            timerText.gameObject.SetActive(true);
            timerScript.Start();
        }

        // Start the singlePlayer timer countdown
        timerScript.StartTimer(selectedWord);
        //timerScript.AddComponent<SinglePlayerTimer>();
        timerText.text = "Time: " + Mathf.Round(timerScript.timer).ToString();
    }

    private void LoadQuestionsFromFile()
    {
        // Load the questions file from Resources folder
        TextAsset questionsFile = Resources.Load<TextAsset>(path);

        if (questionsFile != null)
        {
            // Split the file contents into separate questions
            string[] questions = questionsFile.text.Split(new string[] { "-->" }, StringSplitOptions.RemoveEmptyEntries);

            // Create a list to hold the shuffled questions
            List<string> shuffledQuestions = new List<string>(questions);

            // Shuffle the list of questions
            ShuffleList(shuffledQuestions);


            // Clear the current question list
            questionList.Clear();

            // Add each shuffled question to your question list
            foreach (string questionString in shuffledQuestions)
            {
                // Split the question into question text and options
                string[] questionParts = questionString.Split('\n');

                // Extract options and correct answer
                List<string> options = new List<string>();
                int correctAnswerIndex = 0;//itialize the correct answer index
                for (int i = 1; i < questionParts.Length; i++)
                {
                    string option = questionParts[i];
                    options.Add(option);

                    // Check if this option contains the correct answer marker (*)
                    if (option.Contains("*"))
                    {
                        correctAnswerIndex = i-1; // Set the correct answer index
                        options[i - 1] = option.Replace("*", ""); 
                    }
                }

                // Extract the question text (assuming it's the first part)
                string questionText = questionParts[0];

                // Create a new Question object and add it to the question list
                Question question = new Question(questionText, options, correctAnswerIndex);
                questionList.Add(question);

                // Debug log to inspect the loaded question
                Debug.Log("Loaded question: " + question.questionText);
                foreach (string option in question.options)
                {
                    Debug.Log("Option: " + option);
                }
            }
        }
        else
        {
            Debug.LogError("Questions file not found at path: " + path);
        }
    }

    // Method to shuffle a list
    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            T temp = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = temp;
        }
    }

    private void DisplayQuestion(int index)
    {
        if (index >= 0 && index < questionList.Count)
        {
            // Get the current question
            Question question = questionList[index];

            // Set question text
            questionLabel.text =  question.questionText;

            // Clear previous options in the dropdown
            questionTypeDropdown.ClearOptions();
            

            // Initialize the dropdown with the default option
            List<string> options = new List<string>();
           

            // Add only the first 5 options as answers
            for (int i = 0; i < Mathf.Min(5, question.options.Count); i++)
            {
                options.Add(question.options[i]);
            }

            // Set the dropdown options
            questionTypeDropdown.AddOptions(options);

            
        }
        else
        {
            Debug.LogError("Invalid question index: " + index);
        }
    }



    private void DisplayNextQuestion()
    {
        // Check if there are more questions available
        if (currentQuestionIndex < questionList.Count - 1)
        {
            int index = currentQuestionIndex;
            // Get the current question
            Question question = questionList[index];
            questionLabel.text = (index + 1) + question.options[0];
            currentQuestionIndex++;
            DisplayQuestion(currentQuestionIndex);
            OnAnswerSelected(currentQuestionIndex);
        }
        else
        {
            // Handle the case when all questions have been displayed
            Debug.LogWarning("All questions have been displayed.");
        }
    }
    public void OnAnswerSelected(int selectedIndex)
    {
        // Check if the selected index is valid
        if (selectedIndex >= 0 && selectedIndex < questionList[currentQuestionIndex].options.Count)
        {
            // Get the selected option text
            string selectedOption = questionList[currentQuestionIndex].options[selectedIndex];

            // Get the correct answer index for the current question
            int correctAnswerIndex = questionList[currentQuestionIndex].correctAnswerIndex;

            // Check if the selected option matches the correct answer
            if (selectedIndex == correctAnswerIndex)
            {
                // Handle correct answer logic here
                Debug.Log("Correct answer selected: " + selectedOption);
                
                Color darkerGreen = new Color(0f, 0.5f, 0f);
                questionTypeDropdown.captionText.color = darkerGreen;
            }
            else
            {
                // Handle incorrect answer logic here
                Debug.Log("Incorrect answer selected: " + selectedOption);
                questionTypeDropdown.captionText.color = Color.red;
            }

        }
        else
        {
            Debug.LogError("Invalid selected index: " + selectedIndex);
        }
    }

    // Call this method to initialize the dropdown value to empty
    public void InitializeDropdown()
    {
        // Set the dropdown value to -1 to select the empty option
        questionTypeDropdown.value = -1;
    }

    void StartQuizGame()
    {
        
        LoadQuestionsFromFile();

        // Hide the game selection panel (if needed)
        gameSelectionPanel.SetActive(false);

        // Show the start game panel for quiz (if needed)
        startGame1Panel.SetActive(true);
        // Hide or clear any other panels (if needed)
        quizResultsPanel.SetActive(false);

        // Initialize the question generation panel (if needed)
        questionGenerationPanel.SetActive(true);

        // Display the first question
        DisplayQuestion(currentQuestionIndex);

        
    }

    [System.Serializable]
    public class Question
    {
        public string questionText;
        public List<string> options;
        public int correctAnswerIndex; // Add this property

        public Question(string text, List<string> opts, int correctAnswerIndex)
        {
            questionText = text;
            options = opts;
            this.correctAnswerIndex = correctAnswerIndex; // Assign the correct answer index
        }
    }

}
