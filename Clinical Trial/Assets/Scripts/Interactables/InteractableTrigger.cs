using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    private IInteractable interactableComponent;

    void Awake()
    {
        interactableComponent = GetComponent<IInteractable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerRoleManager roleManager = other.GetComponent<PlayerRoleManager>();
        PlayerInteractionHandler player = other.GetComponent<PlayerInteractionHandler>();

        if (roleManager != null && player != null)
        {
            player.SetCurrentTarget(interactableComponent, roleManager.CurrentRole);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInteractionHandler player = other.GetComponent<PlayerInteractionHandler>();

        if (player != null)
        {
            player.ClearTarget();
        }
    }
}