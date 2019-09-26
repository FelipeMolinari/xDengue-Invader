using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoviments : MonoBehaviour
{
    public float speed;
    public Animator camAnim;
    public GameObject armaAtual;
    public changeColor panel;
    public GameObject[] weaponsInGame;
    public Slider sickSlider;
    
    public int currentSickStatus;
    public int startingSickBar = 0;
    public bool isSick = false;

    public int tempoDoente=3;
    public float tempoDecorrido = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        sickSlider.value = startingSickBar;
        currentSickStatus = startingSickBar;
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        armaAtual = weaponsInGame[0];

        
    }

    // Update is called once per frame
    void Update()
    {
        float translationx = Input.GetAxis("Horizontal") * Time.deltaTime * speed * -1;
        transform.Translate(translationx, 0, 0);
        if (isSick)
        {

            tempoDecorrido += Time.deltaTime;
            if (tempoDecorrido > tempoDoente)
            {
                currentSickStatus = 0;
                sickSlider.value = currentSickStatus;
                isSick = false;
                tempoDecorrido = 0;
                speed *= 2;
            }
        }
    }

    public void diminuirVelocidade()
    {
        if (!isSick)
        {
            currentSickStatus += 50;
            sickSlider.value = currentSickStatus;
            if (currentSickStatus == 100)
            {
                isSick = true;
                speed *= 0.5f;
                StartCoroutine(panelNaTela("green"));

                
            }
        }
    }


  
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            camAnim.SetTrigger("Shake");
            StartCoroutine(panelNaTela("red"));
        }
        
    }

    public void trocarWeapon(int indexArma)
    {
        if(indexArma == 1)
        {
            trocarPraCanoDuplo();
        }
    }

    private void trocarPraCanoDuplo()
    {
        armaAtual.SetActive(false);
        foreach(GameObject arma in weaponsInGame)
        {
            if(arma.gameObject.name == "ArmaCanoDuplo")
            {
                arma.SetActive(true);
                armaAtual = arma;
            }
        }
    }

    public void aumentarEnergia()
    {
        camAnim.SetTrigger("Shakinho");
    }

    IEnumerator panelNaTela(string cor)
    {
        if(cor == "red")
        {
            panel.mudarPraRed();
            yield return new WaitForSeconds(camAnim.GetCurrentAnimatorStateInfo(0).speed - 0.2f);
        }else if(cor == "green")
        {
            panel.mudarPraGreen();
            yield return new WaitForSeconds(1);
        }
        
        panel.mudarPraDefault();

    }

}
