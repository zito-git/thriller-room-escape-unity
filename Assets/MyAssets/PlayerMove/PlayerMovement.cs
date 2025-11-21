using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CharacterController controller;

    // 애니메이터
    public Animator animator;

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>(); // 자식에서 자동으로 찾아줌
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // A,D
        float v = Input.GetAxis("Vertical");    // W,S

        Vector3 move = transform.right * h + transform.forward * v;

        controller.Move(move * moveSpeed * Time.deltaTime);

        // ---- 애니메이션 처리 ----
        bool isMoving = (h != 0 || v != 0);
        animator.SetBool("is_working", isMoving);
    }
}
