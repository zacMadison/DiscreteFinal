using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeValueScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.currentLevel++;
        if (!GameManager.Instance.wonLast)
        {
            GameManager.Instance.health--;
        }

        SceneManager.LoadScene("elevator");
    }

   
}
