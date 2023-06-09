using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    public Transform player;
    public GameObject btnDialogue;
    public GameObject btnContinue;
    public GameObject dialoguePanel;
    public GameObject canvasMobileControls;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    Coroutine lastRoutine = null;

    public float wordSpeed;
    public bool playerIsClose;
    public float minDist = 4f;
    
    // Update is called once per frame
    void Update()
    {
        if(dialogueText.text == dialogue[index])
        {
            btnContinue.SetActive(true);
        }

        float dist = Vector3.Distance(transform.position, player.position);
        if(dist <= minDist )
        {
            btnDialogue.SetActive(true);
        }
        else
        {
            btnDialogue.SetActive(false);
        }
        //if (Input.GetKeyDown(KeyCode.E) && playerIsClose) 
        //{
        //    if (dialoguePanel.activeInHierarchy)
        //    {
        //        zeroTexto();
        //    }
        //    else
        //    {
        //        dialoguePanel.SetActive(true);
        //        StartCoroutine(Typing());
        //    }
        //}
    }

    public void OpenDialogue()
    {
        //if (other.CompareTag("Player"))
        //{
        //    playerIsClose = true;
        //}
        //if (dialoguePanel.activeInHierarchy)
        //{
        //    zeroTexto();
        //}
        //else
        //{
            canvasMobileControls.SetActive(false);
            dialoguePanel.SetActive(true);
            lastRoutine = StartCoroutine(Typing());
        //}
    }

    public void CloseDialogue()
    {
        
            //playerIsClose = false;
            zeroTexto();
            canvasMobileControls.SetActive(true);
        
    }

    public void zeroTexto()
    {
        dialogueText.text = "";
        index = 0;
        StopCoroutine(lastRoutine);
        dialoguePanel.SetActive(false); 
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        btnContinue.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroTexto();
            canvasMobileControls.SetActive(true);
        }
    }
}
