using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Arreglos : MonoBehaviour{
    public GameObject obj;
    public float distancia;

    public void Arreglo(GameObject obj, float distancia){
        this.obj = obj;
        this.distancia = distancia;
    }
}

public class Tubo : MonoBehaviour
{
    private float caos;
    private float velocidad;
    public float velocidad_ventilador = 0;
    [SerializeField]
    private GameObject lejosB;
    [SerializeField]
    private GameObject normalB;
    [SerializeField]
    private GameObject cercaB;
    [SerializeField]
    private GameObject centro;
    [SerializeField]
    private GameObject cercaA;
    [SerializeField]
    private GameObject normalA;
    [SerializeField]
    private GameObject lejosA;
    [SerializeField]
    private GameObject[] posiciones;


    // Update is called once per frame
    void FixedUpdate()
    {
        caos = Random.Range(-.5f, .5f);
        Velocity();
        
        GetComponent<Rigidbody>().velocity = new Vector3(0, velocidad_ventilador * caos, 0);
    }

    void Velocity(){
        var distancias = new float[posiciones.Length];
        for (int i = 0; i < distancias.Length; i++)
        {
            distancias[i] = Vector3.Distance(transform.position,posiciones[i].transform.position);
        }
        
        var min = Mathf.Min(distancias);
        for (int i = 0; i < posiciones.Length; i++)
        {
            if (distancias[i] == min)
            {
                posiciones[i].GetComponent<LejosB>().Fly(Vector3.Distance(transform.position,posiciones[i].transform.position));
                break;
            }
        }
    }

    private int Compare(float a, float b, float c){
        if(a < b && a < c){
            return 0;
        }else if(b < a && b < c){
            return 1;
        }else{
            return 2;
        }
    }

    private float Distance(GameObject ubicacion)
    {
        return Vector3.Distance(transform.position, ubicacion.transform.position);
    }

    /*private trapezoid(float x, float a, float b, float c, float d){
        let member = 0;
        if(x <= a) {
            member = 0;
        }else{
            if (x > a && x <= b) {
                member = (x/(b-a)) - (a/(b-a));
            }else{
                if (x > b && x <= c) {
                    member = 1;
                } else {
                    if (x>c && x <= d) {
                        member = - (x/(d-c)) + (d/(d-c));
                    } else {
                        if (x>d) {
                            member = 0;
                        }
                    }
                }
            }
        }
        return member;
    }*/
}