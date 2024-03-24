using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TextToSpeech : MonoBehaviour
{
    [SerializeField] private string apiKey = "YOUR_GOOGLE_API_KEY";
    [SerializeField] private string textToSpeak = "Hello, I am your AR model.";

    private string ttsUrl = "https://texttospeech.googleapis.com/v1/text:synthesize";

    public void StartTTS()
    {
        StartCoroutine(SendTTSRequest());
    }

    private IEnumerator SendTTSRequest()
    {
        string jsonPayload = "{\"input\":{\"text\":\"" + textToSpeak + "\"},\"voice\":{\"languageCode\":\"en-US\",\"name\":\"en-US-Wavenet-D\",\"ssmlGender\":\"NEUTRAL\"},\"audioConfig\":{\"audioEncoding\":\"LINEAR16\"}}";

        UnityWebRequest request = new UnityWebRequest(ttsUrl, "POST");
        byte[] payload = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(payload);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("TTS Request Failed: " + request.error);
        }
        else
        {
            // Play the audio using Unity AudioSource or any audio player
            byte[] audioData = request.downloadHandler.data;
            // Implement audio playback logic here
        }
    }
}