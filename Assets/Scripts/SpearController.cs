using UnityEngine;
using UnityEngine.InputSystem;

public class SpearController : MonoBehaviour
{
    public float throwForce = 10f;
    private Vector3 throwStartPosition;
    private Vector3 throwEndPosition;
    private bool isThrowing = false;
    public InputActionProperty pinchAnimationAction;


    public void SetPinchAction(InputActionProperty action)
    {
        pinchAnimationAction = action;
    }

    void Update()
    {
        if (pinchAnimationAction != null)
        {
            float triggerValue = pinchAnimationAction.action.ReadValue<float>();
            if (triggerValue > 0)
            {
                OnTriggerPressed();
            }
            else
            {
                OnTriggerReleased();
            }
        }
    }

    void OnTriggerPressed()
    {
        if (!isThrowing)
        {
            throwStartPosition = transform.position; // Get initial position
            isThrowing = true;
        }
    }

    void OnTriggerReleased()
    {
        if (isThrowing)
        {
            throwEndPosition = transform.position; // Get release position
            ThrowSpear();
            isThrowing = false;
        }
    }

    void ThrowSpear()
    {
        Vector3 throwDirection = throwEndPosition - throwStartPosition;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision with target or environment
        Debug.Log("Spear hit something!");
    }
}