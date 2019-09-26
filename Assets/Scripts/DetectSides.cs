using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSides : MonoBehaviour
{
    public float sideBounds;
    public float navWidth;
    // Start is called before the first frame update
    void Start()
    {
        sideBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        navWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -sideBounds+ navWidth, sideBounds - navWidth);
        transform.position = viewPos;
    }

}
