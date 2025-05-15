using UnityEngine;

public class musicpitch : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    void Start()
    {
        music.pitch = GameManager.Instance.speed;
    }

    
}
