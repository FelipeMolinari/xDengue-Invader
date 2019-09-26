using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviments : MonoBehaviour
{
    public float vel = 3;
    public Rigidbody2D rigidbody;
    public int currentLife=1;
    public ParticleSystem explosionEffect;
    public Color[] coresPossiveis;
    private Color corEnemy;
    [SerializeField]
    private GameObject playerAlvo;
    public GameObject[] itemEnemy;
    public bool dropItem = false;
    // Start is called before the first frame update
    void Start()
    {

        if (Random.Range(0, 2) == 0)
            dropItem = true;
        else dropItem = false;

        corEnemy = coresPossiveis[Random.RandomRange(0, coresPossiveis.Length)];

        gameObject.GetComponent<SpriteRenderer>().color = corEnemy;

        playerAlvo = FindObjectOfType<PlayerMoviments>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector3(0, -vel, 0);
        if (currentLife <= 0)
            enemyDie();
       
    }

    public void takeDamage(int amount)
    {
        currentLife -= amount;
       // Instantiate(effect, transform.position, Quaternion.identity);
    }

    private void enemyDie()
    {
        explosionEffect.startColor = corEnemy;
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        playerAlvo.GetComponent<PlayerMoviments>().aumentarEnergia();
        Destroy(gameObject);
        if(dropItem)
        {    
            Instantiate(itemEnemy[Random.Range(0,itemEnemy.Length)], transform.position, Quaternion.identity);
        }

    }

    

}
