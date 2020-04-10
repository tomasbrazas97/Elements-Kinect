
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

public class VoiceMenu : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("start", Begin);
        actions.Add("begin", Begin);
        actions.Add("play", Begin);
        actions.Add("quit", Quit);
        actions.Add("stop", Quit);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log("Keyword: " + speech.text);
        actions[speech.text].Invoke();
    }

    private void Begin()
    {
        keywordRecognizer.Stop();
        keywordRecognizer.Dispose();
        SceneManager.LoadScene("MainScene");
    }

    private void Quit()
    {
        Application.Quit();
    }

}


