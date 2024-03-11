using SerializableCallback;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    public InputActionProperty pinchAction;

    private XRDirectInteractor directInteractor;
    private SpearController currentSpearController;

    void Start()
    {
        FindPinchActionInChildren(transform);
    }

    private void FindPinchActionInChildren(Transform parent)
    {
        if (pinchAction != null)
            return; // If already found, no need to search further

        pinchAction = parent.GetComponentInChildren<InputActionProperty>();
    }

    private void OnEnable()
    {
        directInteractor = GetComponent<XRDirectInteractor>();
        if (directInteractor)
        {
            directInteractor.selectEntered.AddListener(selectEntered);
            directInteractor.selectExited.AddListener(selectExited);
        }
    }

    private void OnDisable()
    {
        if (directInteractor)
        {
            directInteractor.selectEntered.RemoveListener(selectEntered);
            directInteractor.selectExited.RemoveListener(selectExited);
        }
    }

    private void selectEntered(SelectEnterEventArgs args)
    {
        GameObject interactableObject = args.interactableObject.gameObject;
        currentSpearController = interactableObject.GetComponent<SpearController>();
        if (currentSpearController)
        {
            currentSpearController.SetPinchAction(pinchAction);
        }
    }

    private void selectExited(SelectExitEventArgs args)
    {
        currentSpearController = null;
    }
}