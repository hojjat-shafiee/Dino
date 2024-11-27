using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class DinoPlayer : MonoBehaviour
{
    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;
    private CharacterController characterController;
    private Vector3 playerDirection;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }
    private void OnEnable()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Vector3.zero).x + 1, -0.11f);
        playerDirection = Vector3.zero;
    }
    private void Update()
    {
        playerDirection += gravity * Time.deltaTime * Vector3.down;
        if (characterController.isGrounded)
        {
            playerDirection = Vector3.down;
#if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetButton("Jump"))
                playerDirection = Vector3.up * jumpForce;
#endif

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                playerDirection = Vector3.up * jumpForce;

        }
        characterController.Move(playerDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
