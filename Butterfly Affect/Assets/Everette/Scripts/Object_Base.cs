using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Object_Base : MonoBehaviour
{

  public Sprite mainSprite;
  public string ObjectName = "Treasure Chest";

  private bool canObjectBeInteractedWith = false;
  private bool isBeingHeld = false;

  // References
  private SpriteRenderer mainSpriteRenderer;
  private Transform buttonPrompt;
  private GameObject player;


  public void Start(){
    SetUp();
  }

  public void Update(){
    if(Input.GetKeyDown(KeyCode.E) == true){
      if(isBeingHeld) Drop();
      else if(canObjectBeInteractedWith) Interact();
    }
  }

  public string GetObjectName(){
    return ObjectName;
  }

  public void OnCanBeInteracted(){
    // what happens when the player enters the interaction radius
    canObjectBeInteractedWith = true;
    buttonPrompt.gameObject.SetActive(true);
  }

  public void OnCanNOTBeInteracted(){
    // what happens when the player exits the interaction radius
    canObjectBeInteractedWith = false;
    buttonPrompt.gameObject.SetActive(false);
  }


  private void Interact(){
    // what happens when the player interacts with an object
    Debug.Log("I've been interacted with");
    isBeingHeld = true;
    gameObject.transform.SetParent(player.transform, true);
  }

  private void Drop(){
    // what happens when the player drps the object
    Debug.Log("I've been dropped");
    isBeingHeld = false;
    gameObject.transform.parent = null;
  }

  private void SetUp(){
    // Sets up all the references this script needs
    mainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    buttonPrompt = gameObject.transform.GetChild(0);
    player = GameObject.FindWithTag("Player");

    mainSpriteRenderer.sprite = mainSprite;
    buttonPrompt.gameObject.SetActive(false);
  }
}
