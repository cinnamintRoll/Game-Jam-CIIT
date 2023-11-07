using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 1f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) + Mathf.Abs(vertical) > 0)
        {
            animator.SetTrigger("Walk");

            Vector3 direction = new Vector3(horizontal, 0, vertical);
            transform.position = transform.position + direction * walkSpeed * Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}
