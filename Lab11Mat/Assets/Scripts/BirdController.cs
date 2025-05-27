using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    public float verticalImpulse = 5f;
    public float rotationSpeed = 5f;
    public float forwardForce = 2f;
    public float reboundForceHorizontal = 5f;
    public float reboundForceVertical = 3f;

    public UnityEvent onFlapInput;

    [SerializeField] private Rigidbody rb;

    void FixedUpdate()
    {
        AdjustRotation();
    }

    public void ApplyImpulse(InputAction.CallbackContext context)
    {
        float inputValue = context.ReadValue<float>();
        float appliedForce = inputValue > 0 ? verticalImpulse : -verticalImpulse;

        rb.linearVelocity += new Vector3(0, appliedForce, 0);
        onFlapInput?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpperObstacle"))
        {
            rb.AddForce(new Vector3(forwardForce, -reboundForceVertical, 0), ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("LowerObstacle"))
        {
            rb.AddForce(new Vector3(forwardForce, reboundForceVertical, 0), ForceMode.Impulse);
        }
    }

    void AdjustRotation()
    {
        float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotationSpeed);
    }
}