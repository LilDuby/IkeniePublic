using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4Goal : MonoBehaviour
{
    public OpenDoor openDoor;

    public int openNum = 0;

    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.GetComponent<Player>() != null)
        {
            openNum = 5;
            openDoor.OpenDoorSituation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(boxCollider);
    }
}
