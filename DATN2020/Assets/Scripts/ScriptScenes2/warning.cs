using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class warning : MonoBehaviour
{
    public GameObject dialogBox;
    // public Text dialogText,dialogText2;
    //public string dialog;
    public bool dialogActive;
    public bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            dialogBox.SetActive(true);        
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
