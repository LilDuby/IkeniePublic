using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;
    public bool canLook = true;    

    [Header("PickUp")]
    public GameObject curPickUp;
    public Transform PickUpParent;
    public Transform dropPosition;

    public Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        dropPosition = PlayerManager.Instance.Player.dropPosition;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && PlayerManager.Instance.Player.interaction.curInteractable != null && PlayerManager.Instance.Player.itemData == null)
        {
            bool isResource = PlayerManager.Instance.Player.interaction.curInteractable.OnInteract();
            if (isResource)
            {
                PlayerManager.Instance.Player.interaction.curInteractGameObject = null;
                PlayerManager.Instance.Player.interaction.curInteractable = null;
                PlayerManager.Instance.Player.interaction.promptText.gameObject.SetActive(false);
            }
        }
    }

    public void PickUpNew(ItemData data)
    {
        ThrowPickUp();
        curPickUp = Instantiate(data.PickUpPrefeb, PickUpParent);
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && PlayerManager.Instance.Player.itemData != null)
        {
            ThrowItem(PlayerManager.Instance.Player.itemData);
            ThrowPickUp();
            PlayerManager.Instance.Player.itemData = null;
        }
    }

    public void ThrowPickUp()
    {
        if (curPickUp != null)
        {
            Destroy(curPickUp.gameObject);
            curPickUp = null;
        }
    }

    public void ThrowItem(ItemData data)
    {
        Instantiate(data.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.forward));
    }

    public void ToggleCursor()
    {        
		bool toggle = Cursor.lockState == CursorLockMode.Locked;
		Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
		canLook = !toggle;		
    }

    public void OnKeyPad(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && PlayerManager.Instance.Player.interaction.curInteractable != null && canLook)
        {   
            PlayerManager.Instance.Player.interaction.promptText.gameObject.SetActive(false);
            bool isResource = PlayerManager.Instance.Player.interaction.curInteractable.OnClick();
            if (isResource)
            {
                PlayerManager.Instance.Player.interaction.curInteractGameObject = null;
                PlayerManager.Instance.Player.interaction.curInteractable = null;
                PlayerManager.Instance.Player.interaction.promptText.gameObject.SetActive(false);
            }
        }
    }    
}
