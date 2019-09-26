using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    public float widthBound;
    public float timeBetweenInstantiate=2;
    public float pastTime=0;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        widthBound = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        if (pastTime > timeBetweenInstantiate)
        {
            float instantiatedInPos = Random.Range(-widthBound, widthBound);
            Instantiate(enemy, new Vector2(instantiatedInPos, transform.position.y), Quaternion.identity);
            pastTime = 0;
        }

    }
}
