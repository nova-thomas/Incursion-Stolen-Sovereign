using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayerController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private XRDirectInteractor directInteractor;

    void Start()
    {
        // Get required components
        grabInteractable = GetComponent<XRGrabInteractable>();
        directInteractor = GetComponent<XRDirectInteractor>();

        // Subscribe to events
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void Update()
    {
        // idk how to do vr 
   
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        // Handle grab event
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        // Handle release event
    }
}
