using UnityEngine;

public class GameView : MonoBehaviour
{
    public Transform player; // reference to player object

    public float cameraDistance = 10f; // distance from camera to player
    public float cameraHeight = 5f; // height of camera above player
    public float cameraSmoothing = 5f; // smoothing factor for camera movement

    private Vector3 cameraOffset; // offset of camera from player

    void Start()
    {
        cameraOffset = new Vector3(0f, cameraHeight, -cameraDistance);
    }

    void LateUpdate()
    {
        // position camera behind player with specified offset
        Vector3 targetPosition = player.position + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSmoothing);

        // look at player
        transform.LookAt(player);
    }
}
