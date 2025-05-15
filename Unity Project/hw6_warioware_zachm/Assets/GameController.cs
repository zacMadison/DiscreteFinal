using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This implementation is referenced from this video: https://www.youtube.com/watch?v=eGRuZ4Q5MGg
    public static GameManager Instance;

    public int health = 4;

    public int currentLevel = 0;

    public float speed = 1;

    public bool wonLast = false;

    public bool firstLevel = true;
    
    
    private void Awake()
    {
        Application.targetFrameRate = 30;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    

   
    
}
