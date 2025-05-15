using UnityEngine;

public class SwatController : MonoBehaviour
{
    [SerializeField] private Transform swatter;
    [SerializeField] private Camera cam;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        swatter.position = new Vector3(mousePos.x, mousePos.y, -5f);
        swatter.rotation = Quaternion.Euler(0, 0, 0);
        
    }
}
