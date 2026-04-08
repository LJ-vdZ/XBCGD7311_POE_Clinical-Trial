using UnityEngine;

public class MiniMapPlayerFollower : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        if (player == null) {  return; }

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            // Create rotation looking at player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
}
