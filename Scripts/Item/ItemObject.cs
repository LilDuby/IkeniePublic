using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    public string GetInteractPrompt();
    public bool OnInteract();
    public bool OnClick();
}

public class ItemObject : MonoBehaviour, IInteractable
{

    public ItemData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public bool OnInteract()
    {
        if (data.type == ItemType.CanPickUp)
        {
            PlayerManager.Instance.Player.itemData = data;           
            Destroy(gameObject);
            PlayerManager.Instance.Player.controller.PickUpNew(data);
            return true;
        }        
        return false;
    }
    public bool OnClick()
    {
        if (data.type == ItemType.Interaction)
        {   
            if(data.PadNum==1)
            {            
                PlayerManager.Instance.Player.Interaction?.Invoke();
                return true;
            }
            else
            {
                PlayerManager.Instance.Player.Interaction2?.Invoke();
            return true;
            }
        }
        return false;
    }
}
