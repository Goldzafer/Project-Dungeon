using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public bool northDoor;
    public bool eastDoor;
    public bool southDoor;
    public bool westDoor;

    //reference to manager and parent object
    public RoomGeneratorManager roomGeneratorManager;

    public Camera roomCamera;
    public Transform cameraTransform;
    public GameObject shadow;

    public float spawnChance = 100;

    public void OnTriggerEnter2D(Collider2D other) //moves the camera and gives a number based on "spawnchance" to decide wether to spawn a monster or not
    {
        if (other.gameObject.tag == "Player")
        {
            roomCamera.transform.position = cameraTransform.position;
            shadow.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D other) //causes the shadow to apper when exiting and disapear when entering a room   
    {
        if (other.gameObject.tag == "Player")
        {
            shadow.SetActive(true);
        }
    }

    public void exitDungeon()
    {
        roomGeneratorManager.ResetDungeon();
    }
}