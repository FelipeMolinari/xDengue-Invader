using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float timeBetweenShoot = 1;
    public float pastTime = 0;
    public GameObject projectile;
    public Transform canoPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        if (pastTime > timeBetweenShoot)
        {
            Instantiate(projectile, new Vector3(canoPos.position.x, canoPos.position.y, canoPos.position.z), Quaternion.identity);
            pastTime = 0;
        }
    }

    void trocarWeapon()
    {

    }


}
