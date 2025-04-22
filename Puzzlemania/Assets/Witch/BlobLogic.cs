using UnityEngine;
    public class BlobLogic : MonoBehaviour
    {
        public float damage;
        public float timeDestruction;
        private Health script;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                script = other.gameObject.GetComponent<Health>();
                script.Damage(damage);
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            Destroy(gameObject, timeDestruction);
        }
    }