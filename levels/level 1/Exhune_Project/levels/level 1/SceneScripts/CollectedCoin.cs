using System.Collections;
using UnityEngine;

namespace CoinSystem
{
    public class CollectedCoin : MonoBehaviour
    {
        public int coinsToGive = 1;
        public ParticleSystem CoinParticule;
        public float Distance = 0.5f;

        [SerializeField] private AudioClip coinSound;
        [SerializeField] private AudioSource audioSource;

        public float moveSpeed = 1.0f;
        private float originalY;

        private SpriteRenderer spriteRenderer;
        private Collider2D coinCollider;

        private bool isCollected = false;

        private void Start()
        {
            originalY = transform.position.y;

            spriteRenderer = GetComponent<SpriteRenderer>();
            coinCollider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            float newY = originalY + Mathf.Sin(Time.time * moveSpeed) * Distance;
            transform.position = new Vector2(transform.position.x, newY);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isCollected) return;

            if (other.CompareTag("Player"))
            {
                isCollected = true;

                // Play sound
                if (audioSource != null && coinSound != null)
                {
                    audioSource.PlayOneShot(coinSound);
                }

                // Play particles
                if (CoinParticule != null)
                {
                    CreateCoinParticule(transform.position);
                }

                // Add coins safely
                if (Coin.instance != null)
                {
                    Coin.instance.AddCoins(coinsToGive);
                }

                Collect();
            }
        }

        private void Collect()
        {
            if (spriteRenderer != null)
                spriteRenderer.enabled = false;

            if (coinCollider != null)
                coinCollider.enabled = false;

            StartCoroutine(DestroyAfterDelay(1f));
        }

        private IEnumerator DestroyAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }

        private void CreateCoinParticule(Vector2 position)
        {
            CoinParticule.transform.position = position;
            CoinParticule.Play();
        }
    }
}