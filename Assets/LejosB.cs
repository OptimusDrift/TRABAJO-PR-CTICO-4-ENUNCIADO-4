using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LejosB : MonoBehaviour, IFly
{
    [SerializeField]
    private float velocidad_ventilador = 0;
    [SerializeField]
    private GameObject taza;
    public void Fly(float x)
    {
        if (velocidad_ventilador == 0)
        {
            velocidad_ventilador = Random.Range(-1, 1);
        }
        taza.GetComponent<Tubo>().velocidad_ventilador = velocidad_ventilador * x;
    }
}