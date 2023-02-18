using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC_GamePlay : MonoBehaviour
{

  public Sprite mainSprite;
  public string npcName = "Solider_1";

  public UnityEvent StartedTalking, StoppedTalking;

  private bool canBeInteractedWith = false;
  private bool isTalking = false;

  // References
  private Transform buttonPrompt, thoughtBubble;

  public void Start(){
    SetUp();
  }

  public void Update(){
    if(canBeInteractedWith && Input.GetKeyDown(KeyCode.Q)){
      if(isTalking) StopTalking();
      else StartTalking();
    }
  }

  public void OnCanBeInteractedWith(){
    canBeInteractedWith = true;
    buttonPrompt.gameObject.SetActive(true);
  }

  public void OnCanNOTBeInteractedWith(){
    StopTalking();
    canBeInteractedWith = false;
    buttonPrompt.gameObject.SetActive(false);
  }


  private void StopTalking(){
    buttonPrompt.gameObject.SetActive(true);
    thoughtBubble.gameObject.SetActive(false);
    isTalking = false;
    StoppedTalking.Invoke();
  }

  private void StartTalking(){
    buttonPrompt.gameObject.SetActive(false);
    thoughtBubble.gameObject.SetActive(true);
    isTalking = true;
    StartedTalking.Invoke();
  }

  private void SetUp(){
    buttonPrompt = gameObject.transform.GetChild(0);
    thoughtBubble = gameObject.transform.GetChild(1);

    buttonPrompt.gameObject.SetActive(false);
    thoughtBubble.gameObject.SetActive(false);
  }
}
