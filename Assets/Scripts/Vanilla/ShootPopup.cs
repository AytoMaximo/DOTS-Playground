using UnityEngine;

namespace Vanilla
{
    public class ShootPopup : MonoBehaviour
    {
        private float destroyTimer = 1f;

        private void Update()
        {
            var moveSpeed = 2f;
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            
            destroyTimer -= Time.deltaTime;
            if (destroyTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}