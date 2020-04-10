using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

public class VoiceHand : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    public GameObject menuContainer;

    void Start()
    {
        spriteArray = Resources.LoadAll<Sprite>("Elements");

        actions.Add("turn fire", Fire);
        actions.Add("turn earth", Earth);
        actions.Add("turn water", Water);
        actions.Add("turn air", Air);
        actions.Add("pause", Pause);
        actions.Add("continue", Continue);
        actions.Add("restart", Restart);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("Left", Left);
        actions.Add("Right", Right);

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
        transform.gameObject.tag = "Fire";

    }

    private void Earth()
    {
        spriteRenderer.sprite = spriteArray[3];
        transform.gameObject.tag = "Earth";
    }

    private void Water()
    {
        spriteRenderer.sprite = spriteArray[1];
        transform.gameObject.tag = "Water";
    }

    private void Air()
    {
        spriteRenderer.sprite = spriteArray[2];
        transform.gameObject.tag = "Air";
    }

    private void Pause()
    {
        Time.timeScale = 0;
        menuContainer.SetActive(true);
        
    }

    private void Continue()
    {
        Time.timeScale = 1;
        menuContainer.SetActive(false);
    }

    private void Restart()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("MainScene");
    }

    private void Up()
    {
        transform.Translate(0, 5, 0);
    }

    private void Down()
    {
        transform.Translate(0, -5, 0);
    }

    private void Left()
    {
        transform.Translate(-5, 0, 0);
    }

    private void Right()
    {
        transform.Translate(5, 0, 0);
    }

}
