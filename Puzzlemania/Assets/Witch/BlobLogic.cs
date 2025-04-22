using UnityEngine;
    public class BlobLogic : MonoBehaviour
    {
        public float damage;
        public float timeDestruction;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerHealth mainCharacterScript = other.gameObject.GetComponent<PlayerHealth>();
                mainCharacterScript.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            Destroy(gameObject, timeDestruction);
        }
    }