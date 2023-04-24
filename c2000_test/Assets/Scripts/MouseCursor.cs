using UnityEngine;

public class MouseCursor : MonoBehaviour
{
        [SerializeField] private Camera mainCamera;

        void Start()
        {
                // Hide the default cursor
                Cursor.visible = false;
        }


        private void Update()
        {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = -mainCamera.transform.position.z;
                Vector3 targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                targetPosition.z = 0f;

                transform.position = targetPosition;
        }
}
