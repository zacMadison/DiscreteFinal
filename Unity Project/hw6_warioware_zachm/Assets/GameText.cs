using TMPro;
using UnityEngine;

public class GameText : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private TMP_Text TMP;
    [SerializeField] private GameObject thisObject;
    private float timer = 2;
    void Start()
    {
        TMP.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        MoveText();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            TMP.enabled = false;
        }

    }

    void MoveText()
    {
        if (thisObject.transform.localScale.x > 1)
        {
            thisObject.transform.localScale -= new Vector3(4f, 4f, 0);
            if (thisObject.transform.localScale.x < 1)
            {
                thisObject.transform.localScale = new Vector3(1f, 1f, 0);
                TMP.enabled = true;
            }
        }
    }
}
