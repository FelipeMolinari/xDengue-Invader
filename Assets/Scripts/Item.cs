using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(new Vector3(0, -1f * Time.deltaTime, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMoviments>().trocarWeapon(1);
            Destroy(gameObject);
        }
    }
   
}
