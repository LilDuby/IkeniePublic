using UnityEngine;

public enum ItemType
{
    CanPickUp,
    Resource,
    Interaction
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public GameObject dropPrefab;
    public bool isKey;

    [Header("PickUp")]
    public GameObject PickUpPrefeb;

    [Header("UI")]
    public int PadNum;
}
