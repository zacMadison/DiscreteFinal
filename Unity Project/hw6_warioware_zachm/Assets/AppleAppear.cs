using UnityEngine;

public class AppleAppear : MonoBehaviour
{
    [SerializeField] private SpriteRenderer apple;

    [SerializeField] private int thisApple;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance.health < thisApple)
        {
            apple.enabled = false;
        }
    }
}
