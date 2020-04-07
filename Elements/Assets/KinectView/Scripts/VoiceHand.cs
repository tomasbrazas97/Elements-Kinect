using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceHand : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        spriteArray = Resources.LoadAll<Sprite>("Elements");

        actions.Add("turn fire", Fire);
        actions.Add("turn earth", Earth);
        actions.Add("turn water", Water);
        actions.Add("turn air", Air);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log("Keyword: "+ speech.text);
        actions[speech.text].Invoke();
    }

    private void Fire()
    {
        spriteRenderer.sprite = spriteArray[0];
        Debug.Log("fire");
    }

    private void Earth()
    {
        spriteRenderer.sprite = spriteArray[3];
        
    }

    private void Water()
    {
        spriteRenderer.sprite = spriteArray[1];
    }

    private void Air()
    {
        spriteRenderer.sprite = spriteArray[2];
    }
}
