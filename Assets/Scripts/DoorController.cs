using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openRotation;
    public float openSpeed = 2f;

    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = Quaternion.Euler(openRotation);
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            openSpeed * Time.deltaTime
        );
    }
}