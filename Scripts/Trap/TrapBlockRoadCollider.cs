using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBlockRoadCollider : MonoBehaviour
{
    public int blockSpeed;
    public bool right;

    private void OnTriggerEnter(Collider other)
    {

        if(other.TryGetComponent(out Rigidbody _rigidbody))
        {
            if (right)
            {
                _rigidbody.AddForce(Vector3.back * blockSpeed, ForceMode.Impulse);
            }
            else
            {
                _rigidbody.AddForce(Vector3.forward * blockSpeed, ForceMode.Impulse);
            }
        }
    }
}
