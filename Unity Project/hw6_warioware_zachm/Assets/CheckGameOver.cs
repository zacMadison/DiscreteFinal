using System;
using Unity.VisualScripting;
using UnityEngine;

public class CheckGameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void Gameover()
    {
        
        if (GameManager.Instance.health == 0)
        {
            // this check if the game is being played in the editor so it can quit
            // stolen from https://discussions.unity.com/t/application-quit-not-working/130493
            // (why is unity editor like this)
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit();
            #endif
        }
    }
}
