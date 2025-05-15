using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = Unity.Mathematics.Random;

public class NewFloor : MonoBehaviour
{
    private static readonly int First = Animator.StringToHash("First");
    private static readonly int Won = Animator.StringToHash("Won");
    private static readonly int AnimationOver = Animator.StringToHash("AnimationOver");
    private static readonly int Initiated = Animator.StringToHash("Initiated");
    [SerializeField] AudioSource newFloorSound;
    [SerializeField] AudioSource wonLast;
    [SerializeField] AudioSource lostLast;
    [SerializeField] private Animator animator;
    private string[] levels = new string[]
    {
        "anti-air",
        "Swat"
    };
    
    
    void Start()
    {
        wonLast.pitch = GameManager.Instance.speed;
        lostLast.pitch = GameManager.Instance.speed;
        newFloorSound.pitch = GameManager.Instance.speed;
        
        
        if (GameManager.Instance.firstLevel)
        {
            animator.SetBool("First", true);
            GameManager.Instance.firstLevel = false;
            StartCoroutine(PlayNewFloorSound());
            
        } else switch (GameManager.Instance.wonLast)
        {
            case true:
                animator.SetBool("Won", true);
                animator.SetBool("Initiated", true);
                GameManager.Instance.wonLast = false;
                StartCoroutine(EnteringWonLast());
                
                break;
            case false:
                animator.SetBool("Won", false);
                animator.SetBool("Initiated", true);
                
                StartCoroutine(EnteringLostLast());
                
                break;
        }
    }

    // Update is called once per frame
    IEnumerator PlayNewFloorSound()
    {
        CheckGameOver.Gameover();
        animator.SetBool("AnimationOver", true);
        newFloorSound.Play();
        yield return new WaitUntil(() => !newFloorSound.isPlaying);
        ChangeFloors();
    }

    IEnumerator EnteringWonLast()
    {
        wonLast.Play();
        yield return new WaitUntil(() => !wonLast.isPlaying);
        StartCoroutine(PlayNewFloorSound());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator EnteringLostLast()
    {
        lostLast.Play();
        yield return new WaitUntil(() => !lostLast.isPlaying);
        
        StartCoroutine(PlayNewFloorSound());
    }
    void ChangeFloors()
    {
        animator.SetBool("First", false);
        animator.SetBool("AnimationOver", false);
        animator.SetBool("Initiated", false);
        var nextLevel = levels[UnityEngine.Random.Range(0, levels.Length)];
        Debug.Log(nextLevel);
        Debug.Log(levels.Length);
        SceneManager.LoadScene(nextLevel);
    }
}
