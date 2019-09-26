using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaCanoDuplo : MonoBehaviour
{
    public float timeBetweenShoot;
    public float pastTime = 0;
    public GameObject projectile;
    public Transform[] canoPos;
    public bool active;
    public int indexArma;
    // Start is called before the first frame update
    void Start()
    {
        indexArma = transform.GetSiblingIndex();

    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        if (pastTime > timeBetweenShoot)
        {
            Instantiate(projectile, new Vector3(canoPos[0].position.x, canoPos[0].position.y, canoPos[0].position.z), Quaternion.identity);
            Instantiate(projectile, new Vector3(canoPos[1].position.x, canoPos[1].position.y, canoPos[1].position.z), Quaternion.identity);
            pastTime = 0;
        }
    }



}
