using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;
    private Queue<string>sentences;

    void Start(){
        sentences = new Queue<string>();
    }
    public void StartDialouge(Dialouge dialogue){
        
		dialoguePanel.SetActive(true);

		nameText.text = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence(){
        if(sentences.Count==0){
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

    void EndDialouge(){
        dialoguePanel.SetActive(false);
        FindObjectOfType<DialougeTrigger>().isDialougeOpen = false;
    }

}
