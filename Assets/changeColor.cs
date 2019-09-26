using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour
{

    public Color red;
    public Color green;
    public Color defaultC;

    public void mudarPraRed()
    {
        gameObject.GetComponent<Image>().color = red;
    }
    public void mudarPraGreen()
    {
        gameObject.GetComponent<Image>().color = green;
    }
    public void mudarPraDefault()
    {
        gameObject.GetComponent<Image>().color = defaultC;
    }
}
