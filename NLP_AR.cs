using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;

public class NLP_AR_Controller : MonoBehaviour
{
    public Text outputText;

    void Start()
    {
        // Call the Python script
        string inputText = "Your input text goes here";
        string result = RunPythonScript("nlp_processing.py", inputText);

        // Display the result in Unity UI
        outputText.text = result;
    }

    string RunPythonScript(string scriptPath, string arguments)
    {
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"{scriptPath} {arguments}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        
        process.Start();
        string result = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return result;
    }
}