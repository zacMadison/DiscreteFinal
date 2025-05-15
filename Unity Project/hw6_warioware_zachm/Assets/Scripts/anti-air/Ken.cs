using global;
using UnityEngine;

namespace anti_air
{
    public class Ken : MonoBehaviour
    {
        // Using public fields is bad practice, but this is moreso about learning unity fine for now
        [SerializeField] private Sprite kenHit;
        [SerializeField] private Sprite kenGrounded;
        [SerializeField] private float jumpHeight;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private BoxCollider2D kenBoxCollider;
        [SerializeField] private BoxCollider2D kenGroundedBoxCollider;
        public Rigidbody2D rb;
        public SpriteRenderer sr;
        void Start()
        {
            rb.gravityScale = rb.gravityScale * GameManager.Instance.speed;
        }

      

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (!GameManager.Instance.wonLast)
                {
                    Jump();
                } else if (GameManager.Instance.wonLast)
                {
                    sr.sprite = kenGrounded;
                    kenBoxCollider.enabled = false;
                    kenGroundedBoxCollider.enabled = true;
                }
            }
            else if (collision.gameObject.CompareTag("Ryu"))
            {
                if (!GameManager.Instance.wonLast)
                {
                    Hit();
                }
            }
        }

        private void Jump()
        {
            
            Vector2 jump = Vector2.up * jumpHeight * GameManager.Instance.speed;
            rb.linearVelocity = jump;
            
        }

        private void Hit()
        {
            rb.linearVelocity = new Vector2(1f, 1f);
            GameManager.Instance.wonLast = true;
            rb.gravityScale = 0.4f;
            sr.sprite = kenHit;
            audioSource.Play();
        }
    }
}
