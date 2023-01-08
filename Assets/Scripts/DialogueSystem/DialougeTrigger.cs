using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouges;
    public bool isDialougeOpen = false;


    public void TriggerDialouge(){
        FindObjectOfType<DialougeManager>().StartDialouge(dialouges);
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            isDialougeOpen = true;
            FindObjectOfType<DialougeManager>().StartDialouge(dialouges);
        }
    }

}
