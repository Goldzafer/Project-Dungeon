using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneratorManager : MonoBehaviour
{
    public List<RoomScript> rooms;
    public RoomScript roomScript;
    public RoomPrefabs RoomPrefabs;

    public GameObject starterRoom;
    public Camera roomCamera;
    public GameObject player;

    private float sphereRadius = 1;

    //exit room
    private int counter = 0;
    private bool exitRoom = false;

    public void Start()
    {
        Generate();
    }

    private void Generate() //generates the dungeon layer
    {
        while (rooms.Count > 0) //a loop that spawns the rooms one after another using the first item in the list
        {
            RoomScript tempRoom = rooms[0];

            if (tempRoom.northDoor) //checks if the room has a north door
            {
                if (!Physics.CheckSphere(new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y + 10, 0), sphereRadius)) //checks if there is room in that direction
                {
                    if (counter >= 5 && exitRoom == false)
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.southExitRooms[Random.Range(0, RoomPrefabs.southExitRooms.Length)], new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y + 10, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                        exitRoom = true;
                    }
                    else
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.southRooms[Random.Range(0, RoomPrefabs.southRooms.Length)], new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y + 10, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                    }
                }
            }

            if (tempRoom.eastDoor) //checks if the room has a east door
            {
                if (!Physics.CheckSphere(new Vector3(tempRoom.transform.position.x + 10, tempRoom.transform.position.y, 0), sphereRadius)) //checks if there is room in that direction
                {
                    if (counter >= 5 && exitRoom == false)
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.westExitRooms[Random.Range(0, RoomPrefabs.westExitRooms.Length)], new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y + 10, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                        exitRoom = true;
                    }
                    else
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.westRooms[Random.Range(0, RoomPrefabs.westRooms.Length)], new Vector3(tempRoom.transform.position.x + 10, tempRoom.transform.position.y, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                    }
                }
            }

            if (tempRoom.southDoor) //checks if the room has a south door
            {
                if (!Physics.CheckSphere(new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y - 10, 0), sphereRadius)) //checks if there is room in that direction
                {
                    if (counter >= 5 && exitRoom == false)
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.northExitRooms[Random.Range(0, RoomPrefabs.northExitRooms.Length)], new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y + 10, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                        exitRoom = true;
                    }
                    else
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.northRooms[Random.Range(0, RoomPrefabs.northRooms.Length)], new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y - 10, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                    }
                }
            }

            if (tempRoom.westDoor) //checks if the room has a west door
            {
                if (!Physics.CheckSphere(new Vector3(tempRoom.transform.position.x - 10, tempRoom.transform.position.y, 0), sphereRadius)) //checks if there is room in that direction
                {
                    if (counter >= 5 && exitRoom == false)
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.eastExitRooms[Random.Range(0, RoomPrefabs.eastExitRooms.Length)], new Vector3(tempRoom.transform.position.x, tempRoom.transform.position.y + 10, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                        exitRoom = true;
                    }
                    else
                    {
                        GameObject newRoom = Instantiate(RoomPrefabs.eastRooms[Random.Range(0, RoomPrefabs.eastRooms.Length)], new Vector3(tempRoom.transform.position.x - 10, tempRoom.transform.position.y, 0), Quaternion.identity, transform);
                        newRoom.GetComponent<RoomScript>().roomGeneratorManager = this;
                        newRoom.GetComponent<RoomScript>().roomCamera = roomCamera;
                        rooms.Add(newRoom.GetComponent<RoomScript>());
                    }
                }
            }

            rooms.RemoveAt(0); //removes the first item in the list
            counter++;
            

        }
    }


    public void ResetDungeon() //resets the dungeon and spawns a new one
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject Starter_Room = Instantiate(starterRoom) as GameObject;
        Starter_Room.transform.parent = this.transform;
        rooms.Add(Starter_Room.GetComponent<RoomScript>());
        Starter_Room.GetComponent<RoomScript>().roomCamera = roomCamera;
        player.transform.position = new Vector2(5, 5);

        Generate();
    }
}