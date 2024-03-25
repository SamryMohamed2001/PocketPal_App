using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameTests
{
    private Quiz quiz;
    private GuessingGame guessingGame;

    [SetUp]
    public void Setup()
    {
        // Create instances of the Quiz and GuessingGame classes before each test
        quiz = new Quiz();
        guessingGame = new GuessingGame();
    }

    // Quiz Tests
    [UnityTest]
    public IEnumerator QuizStartsWithFirstQuestion()
    {
        // Arrange
        List<Question> questions = new List<Question>
        {
            new Question("Question 1", new List<string>{"Option 1", "Option 2", "Option 3"}, 0),
            new Question("Question 2", new List<string>{"Option 1", "Option 2", "Option 3"}, 1),
            new Question("Question 3", new List<string>{"Option 1", "Option 2", "Option 3"}, 2)
        };
        quiz.SetQuestions(questions);

        // Act
        quiz.StartQuiz();

        // Assert
        Assert.AreEqual(questions[0], quiz.GetCurrentQuestion());

        yield return null;
    }

    [UnityTest]
    public IEnumerator QuizAllowsAnswerSelection()
    {
        // Arrange
        List<Question> questions = new List<Question>
        {
            new Question("Question 1", new List<string>{"Option 1", "Option 2", "Option 3"}, 0),
            new Question("Question 2", new List<string>{"Option 1", "Option 2", "Option 3"}, 1),
            new Question("Question 3", new List<string>{"Option 1", "Option 2", "Option 3"}, 2)
        };
        quiz.SetQuestions(questions);
        quiz.StartQuiz();

        // Act
        quiz.SelectAnswer(1); // Select the second option

        // Assert
        Assert.AreEqual(1, quiz.GetSelectedAnswerIndex());

        yield return null;
    }

    [UnityTest]
    public IEnumerator QuizAdvancesToNextQuestionAfterAnswering()
    {
        // Arrange
        List<Question> questions = new List<Question>
        {
            new Question("Question 1", new List<string>{"Option 1", "Option 2", "Option 3"}, 0),
            new Question("Question 2", new List<string>{"Option 1", "Option 2", "Option 3"}, 1),
            new Question("Question 3", new List<string>{"Option 1", "Option 2", "Option 3"}, 2)
        };
        quiz.SetQuestions(questions);
        quiz.StartQuiz();

        // Act
        quiz.SelectAnswer(0); // Select the first option
        quiz.NextQuestion();

        // Assert
        Assert.AreEqual(questions[1], quiz.GetCurrentQuestion());

        yield return null;
    }

    // Guessing Game Tests
    [UnityTest]
    public IEnumerator InitializeDisplayedWord_RevealsSomeLetters()
    {
        // Arrange
        string word = "UNITY";

        // Act
        guessingGame.InitializeDisplayedWord(word);

        // Assert
        Assert.AreNotEqual("_____", guessingGame.wordDisplayText.text);

        yield return null;
    }

    [UnityTest]
    public IEnumerator InitializeDisplayedWord_HintsRevealLetters()
    {
        // Arrange
        string word = "UNITY";

        // Act
        guessingGame.InitializeDisplayedWord(word);

        // Assert
        Assert.AreNotEqual("_____", guessingGame.hintDisplayText.text);

        yield return null;
    }
}

// Example Question class for testing quiz game
public class Question
{
    public string QuestionText { get; private set; }
    public List<string> Options { get; private set; }
    public int CorrectAnswerIndex { get; private set; }

    public Question(string questionText, List<string> options, int correctAnswerIndex)
    {
        QuestionText = questionText;
        Options = options;
        CorrectAnswerIndex = correctAnswerIndex;
    }
}

// Example Quiz class for testing quiz game
public class Quiz
{
    private List<Question> questions;
    private int currentQuestionIndex;
    private int selectedAnswerIndex;

    public void SetQuestions(List<Question> questions)
    {
        this.questions = questions;
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        selectedAnswerIndex = -1;
    }

    public Question GetCurrentQuestion()
    {
        return questions[currentQuestionIndex];
    }

    public void SelectAnswer(int index)
    {
        selectedAnswerIndex = index;
    }

    public int GetSelectedAnswerIndex()
    {
        return selectedAnswerIndex;
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;
    }
}

// Example GuessingGame class for testing guessing game
public class GuessingGame
{
    public Text wordDisplayText;
    public Text hintDisplayText;
    private List<char> revealedLetters = new List<char>();


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


    }
}
