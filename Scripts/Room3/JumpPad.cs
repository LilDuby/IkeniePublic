using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float padPower;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player._rigidbody.AddForce(transform.up * padPower, ForceMode.Impulse);
        }

    }
}
