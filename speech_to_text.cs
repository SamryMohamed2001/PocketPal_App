using UnityEngine;
using UnityEngine.UI;

public class SpeechToText : MonoBehaviour
{
    [SerializeField] private Text speechText;

    void Start()
    {
        if (SpeechRecognizer.IsAvailable())
        {
            SpeechRecognizer.OnResult += OnSpeechResult;
        }
        else
        {
            Debug.LogError("Speech Recognition not available on this device.");
        }
    }

    public void StartSTT()
    {
        SpeechRecognizer.Start();
    }

    private void OnSpeechResult(string result)
    {
        speechText.text = result;
        // Implement logic to handle the recognized speech result
    }
}