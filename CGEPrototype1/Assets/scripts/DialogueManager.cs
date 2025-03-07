using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Must add this to use TMP_Text
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    void onEnable()
    {
        StartCoroutine(Type());
    }

    //Coroutine for out typewriter effect
    IEnumerator Type()
    {
        //Set the intial text for textbox to empty string
        textbox.text = "";
        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length -1)
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        } else
        {
            textbox.text = "";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
