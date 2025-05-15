using TMPro;
using UnityEngine;

public class SetCurrentGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int currentGame = GameManager.Instance.currentLevel;
    void Start()
    {
        // +1 is a workaround for being behind a game object
        text.text = currentGame.ToString();
        
    }
}
