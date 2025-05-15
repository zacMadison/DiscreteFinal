using global;
using UnityEngine;
using UnityEngine.Serialization;

public class RyuScript : MonoBehaviour
{
    [SerializeField] private Sprite ryuStanding;
    [SerializeField] private Sprite ryuDp;
    [SerializeField] private float hVelocity;
    [SerializeField] private float vVelocity;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private float timer;
    private bool pressedDp = false;

    void Start()
    {
        rb.gravityScale = rb.gravityScale * GameManager.Instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!pressedDp)
            {
                Shoruken();
                timer = Time.time;
                pressedDp = true;
            }
        }
        
        

        if (timer - Time.time < -0.1f)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    // Activates when space is pressed to send Ryu forward, up, and change sprite
    private void Shoruken()
    {
        var dpVelocity = new Vector2(hVelocity, vVelocity) * GameManager.Instance.speed;
        rb.linearVelocity = dpVelocity;
        sr.sprite = ryuDp;
    }
    
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            sr.sprite = ryuStanding;
        }
    }

    
}
