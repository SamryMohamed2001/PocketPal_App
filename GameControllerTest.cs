using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using System.Collections;

public class GameControllerTest
{
    private GameController gameController;

    [SetUp]
    public void Setup()
    {
        // Create an instance of the GameController class before each test
        GameObject gameControllerObject = new GameObject();
        gameController = gameControllerObject.AddComponent<GameController>();
    }

    [UnityTest]
    public IEnumerator StartGame_DisplaysFirstQuestion()
    {
        // Act
        gameController.StartGame();

        // Assert
        Assert.IsTrue(gameController.letsGetToKnowYouLabel.gameObject.activeSelf);

        yield return null;
    }

    [UnityTest]
    public IEnumerator SubmitResponse_IncreasesScoresAndDisplaysNextQuestion()
    {
        // Arrange
        gameController.StartGame();

        // Act
        int initialFearScore = gameController.totalFearScore;
        int initialAvoidanceScore = gameController.totalAvoidanceScore;
        gameController.SubmitResponse();

        // Assert
        Assert.Greater(gameController.totalFearScore, initialFearScore);
        Assert.Greater(gameController.totalAvoidanceScore, initialAvoidanceScore);
        Assert.IsFalse(gameController.letsGetToKnowYouLabel.gameObject.activeSelf);

        yield return null;
    }

    [UnityTest]
    public IEnumerator ViewResult_HidesQuestionsAndDisplaysResult()
    {
        // Arrange
        gameController.StartGame();
        while (gameController.currentQuestionIndex < gameController.lsasItems.Count)
        {
            gameController.SubmitResponse();
        }

        // Act
        gameController.ViewResult();

        // Assert
        Assert.IsFalse(gameController.letsGetToKnowYouLabel.gameObject.activeSelf);
        Assert.IsTrue(gameController.resultLabel.gameObject.activeSelf);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TryAgain_ResetsScoresAndCurrentQuestionIndex()
    {
        // Arrange
        gameController.StartGame();
        while (gameController.currentQuestionIndex < gameController.lsasItems.Count)
        {
            gameController.SubmitResponse();
        }
        gameController.ViewResult();

        // Act
        gameController.TryAgain();

        // Assert
        Assert.AreEqual(0, gameController.totalFearScore);
        Assert.AreEqual(0, gameController.totalAvoidanceScore);
        Assert.AreEqual(0, gameController.currentQuestionIndex);
        Assert.AreEqual(0, gameController.fearScores.Count);
        Assert.AreEqual(0, gameController.avoidanceScores.Count);
        Assert.IsTrue(gameController.letsGetToKnowYouLabel.gameObject.activeSelf);

        yield return null;
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the GameController object after each test
        Object.Destroy(gameController.gameObject);
    }
}
