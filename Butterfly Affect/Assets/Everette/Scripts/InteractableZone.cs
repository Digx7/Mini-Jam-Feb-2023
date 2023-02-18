using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableZone : MonoBehaviour
{
  public UnityEvent OnCanBeInteractedWith, OnCanNOTBeInteractedWith;

  private void OnTriggerEnter2D(Collider2D col){
    if(col.tag == "Player"){
      OnCanBeInteractedWith.Invoke();
    }
  }

  private void OnTriggerExit2D(Collider2D col){
    if(col.tag == "Player"){
      OnCanNOTBeInteractedWith.Invoke();
    }
  }
}
