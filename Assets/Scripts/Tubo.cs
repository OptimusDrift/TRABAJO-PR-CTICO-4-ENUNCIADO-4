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
    [SerializeField]
    private float velocidad_ventilador = 0;
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




    // Update is called once per frame
    void FixedUpdate()
    {
        caos = Random.Range(-.5f, .5f);

        GetComponent<Rigidbody>().velocity = new Vector3(0, velocidad_ventilador, 0);
        List<Arreglos> array = new List<Arreglos>();
        var a = new Arreglos();
        a.Arreglo(lejosB, Distance(lejosB));
        array.Add(a);
        a.Arreglo(normalB, Distance(normalB));
        array.Add(a);
        a.Arreglo(cercaB, Distance(cercaB));
        array.Add(a);
        a.Arreglo(centro, Distance(centro));
        array.Add(a);
        a.Arreglo(cercaA, Distance(cercaA));
        array.Add(a);
        a.Arreglo(normalA, Distance(normalA));
        array.Add(a);
        a.Arreglo(lejosA, Distance(lejosA));
        array.Add(a);


        array.Sort(
        );
        Debug.Log(array[0].distancia);
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