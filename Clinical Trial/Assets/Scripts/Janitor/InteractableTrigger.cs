using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    private IJanitorInteractable interactableComponent;

    void Awake()
    {
        interactableComponent = GetComponent<IJanitorInteractable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JanitorController janitor = other.GetComponent<JanitorController>();
            if (janitor != null && janitor.isControlled)
            {
                janitor.SetCurrentTarget(interactableComponent);
            }
        }
    }

    void OnTriggerStay(Collider other)      // Added this - helps when standing still inside
    {
        if (other.CompareTag("Player"))
        {
            JanitorController janitor = other.GetComponent<JanitorController>();
            if (janitor != null && janitor.isControlled && janitor.heldTrash != null)
            {
                // Force update target while holding trash near bin
                janitor.SetCurrentTarget(interactableComponent);
            }
        }
    }
}
