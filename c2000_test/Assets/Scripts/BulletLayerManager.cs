using UnityEngine;

public class BulletLayerManager : MonoBehaviour
{
        private void Awake()
        {
                int bulletLayer = LayerMask.NameToLayer("Bullet");
                Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer, true);
        }
}
