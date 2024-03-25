using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string questionText;
    public List<string> options;
    public int correctAnswerIndex; // Index of the correct answer in the options list

    public Question(string questionText, List<string> options)
    {
        this.questionText = questionText;
        this.options = options;
    }
}
