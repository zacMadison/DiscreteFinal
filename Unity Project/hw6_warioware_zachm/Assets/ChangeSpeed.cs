using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
  
    void Start()
    {
        if (GameManager.Instance.currentLevel % 2 == 0 && GameManager.Instance.currentLevel != 0)
        {
            GameManager.Instance.speed += 0.1f;
        }
    }
}
