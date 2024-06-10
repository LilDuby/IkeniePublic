using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRoomButton : MonoBehaviour
{
    public JumpRoomButtonData buttonData;
    public GameObject keyNumber;
    public GameObject openRoom4Door;

    public DoorOpenSound sound;

    private void OnCollisionEnter(Collision collision)
    {
        if (buttonData.buttonType == ButtonType.Right)
        {
            keyNumber.SetActive(true);
            openRoom4Door.transform.rotation = Quaternion.Euler(0f, -110f, 0f);
            sound.OpenSound();
        }
        else
        {
            return;
        }
    }
}
