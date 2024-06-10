using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ButtonType
{
    Wrong,
    Right
}

[CreateAssetMenu(fileName = "Button", menuName = "New Button")]
public class JumpRoomButtonData : ScriptableObject
{
    public ButtonType buttonType;
    
}
