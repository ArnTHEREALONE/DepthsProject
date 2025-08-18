using UnityEditor;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public float height = 15f;
    public float distance = 5f;
    public float cameraLimits = 10f;
    private bool lookAtPlayer = false;
    private bool heightIsFixed = false;
    public PlayerControl playerControl;
    
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned in CameraControl.");
        }
        else
        {
            lookAtPlayer = false;
            transform.position = player.position + new Vector3(0, height, -distance);
            transform.LookAt(player.position);
        }
    }
    void LateUpdate()
    {   
        if (player)
        {
            Vector3 targetPosition = player.position;
            if (playerControl)
            {
                if(!playerControl.grounded)
                {
                    lookAtPlayer = false;
                }
            }
            if (!heightIsFixed)
            {
                targetPosition.y += height;
                heightIsFixed = true;
            }
            else
            {
                targetPosition.y = transform.position.y;
            }
            targetPosition.z -= distance;
            if (!lookAtPlayer)
            {
                transform.LookAt(player.position);
                lookAtPlayer = true;
            }
            
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 mouseOffset = (Vector2)Input.mousePosition - screenCenter;

            float deadZoneX = Screen.width / 4f;
            float deadZoneY = Screen.height / 4f;

            Vector2 normalized = Vector2.zero;

            // X
            if (Mathf.Abs(mouseOffset.x) > deadZoneX)
            {
                normalized.x = (Mathf.Abs(mouseOffset.x) - deadZoneX) / (Screen.width / 2f - deadZoneX) * Mathf.Sign(mouseOffset.x);
                normalized.x = Mathf.Clamp(normalized.x, -1f, 1f);
            }

            // Y
            if (Mathf.Abs(mouseOffset.y) > deadZoneY)
            {
                normalized.y = (Mathf.Abs(mouseOffset.y) - deadZoneY) / (Screen.height / 2f - deadZoneY) * Mathf.Sign(mouseOffset.y);
                normalized.y = Mathf.Clamp(normalized.y, -1f, 1f);
            }

            Vector3 offset = new Vector3(normalized.x * cameraLimits, 0, normalized.y * cameraLimits);

            targetPosition += offset;

            transform.position = targetPosition;

        }
        else
        {
            Debug.LogWarning("Player Transform is not assigned in CameraControl.");
        }
    }
}