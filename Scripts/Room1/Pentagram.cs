using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour
{
    public int stack = 0;
    public AudioClip plusStackClip;
    AudioSource audioSource;
    public Room1 room1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ItemObject itemObject))
        {
            if (itemObject.data.isKey)
            {
                Destroy(other.gameObject);
                audioSource.PlayOneShot(plusStackClip);
                PlusStack();
            }
        }
    }

    void PlusStack()
    {
        stack++;
        if (stack == 4)
        {
            room1.MissingWwall();
            this.gameObject.SetActive(false);
        }
    }
}
