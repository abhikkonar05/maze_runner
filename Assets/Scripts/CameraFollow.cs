using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0f, 5f, -8f);

    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (player == null)
            return;

        // Desired position
        Vector3 desiredPosition =
            player.position + offset;

        // Smooth follow
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Stable look at player
        transform.LookAt(player.position + Vector3.up * 2f);
    }
}