using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    public ItemData itemData;   
    public Action Interaction;
    public Action Interaction2;
    

    public Interaction interaction;

    public Transform dropPosition;
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        interaction = GetComponent<Interaction>();
    }
}
