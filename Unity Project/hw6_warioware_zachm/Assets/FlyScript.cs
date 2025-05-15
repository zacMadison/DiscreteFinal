using UnityEngine;

public class FlyScript : MonoBehaviour
{
    [SerializeField] private Transform fly;
    [SerializeField] private Collider2D swatCollider;
    [SerializeField] private Collider2D flyCollider;
    [SerializeField] private SpriteRenderer flySprite;
    void Start()
    {
        fly.position = new Vector2(Random.Range(-0.2f, 13f), Random.Range(0.2f, 9.7f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (swatCollider.IsTouching(flyCollider))
            {
                flySprite.enabled = false;
                GameManager.Instance.wonLast = true;
            }
        }
    }
}
