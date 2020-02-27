using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform door;
    public Vector3 closedPosition = new Vector3(.51f, 3.63f, 0);
    public Vector3 openedPosition = new Vector3(.51f, 7f, 0);
    public float openSpeed = 5f;
    private bool open = false;

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            door.position = Vector3.Lerp(door.position, openedPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            door.position = Vector3.Lerp(door.position, closedPosition, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            OpenDoor();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        open = false;

    }
    public void OpenDoor()
    {
        open = true;

    }
}