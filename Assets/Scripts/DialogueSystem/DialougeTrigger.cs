using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouges;

    public void TriggerDialouge(){
        FindObjectOfType<DialougeManager>().StartDialouge(dialouges);
    }


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"){
            Debug.Log("it' player");
            FindObjectOfType<DialougeManager>().StartDialouge(dialouges);
        }
    }

}
