using UnityEngine;

public class OpenDoor2 : MonoBehaviour
{
    public InputPad inputPad;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        if (inputPad.success)
        {
            animator.SetBool("isSuccess",true);            
        }
    }
}
