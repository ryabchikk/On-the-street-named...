using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public int GRABI;
    public float grabPower = 10.0f;
    public float throwPower = 10f;   //скорость толчка
    public float RayDistance = 30.0f;   //дистанция

    private bool Grab = false;   //ф-ция притяжения
    private bool Throw = false;   //ф-ция толчка
    public Transform offset;
    public Camera camera;
    RaycastHit hit;   //луч


    private void Start()
    {
        GRABI = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics.Raycast(new Ray(gameObject.transform.position + new Vector3(0, -2, 0), gameObject.transform.forward), out hit, RayDistance);
            if (hit.rigidbody)
            {
                GRABI+=1;
                if (GRABI == 1)
                {
                    Grab = true;
                }
                else 
                {
                    GRABI = 0;
                    Grab = false;
                }
                if (Grab == false)
                {
                    GRABI = 0;
                }
            }
            Debug.Log(GRABI);
        }
        //если нажата левая  кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            if (Grab)
            { 
                GRABI = 0;
                Grab = false;
                Throw = true;
            }
        }
        //ф-ция притяжения
        if (Grab)
        {
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass)) * grabPower;

            }
        }
        //ф-ция толчка
        if (Throw)
        {
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = gameObject.transform.forward * throwPower;
                Throw = false;
            }
        }
    }

    private void Grabb()
    {
        Ray ray = camera.ScreenPointToRay(gameObject.transform.position);
        Physics.Raycast(ray, out hit, RayDistance);
        if (hit.rigidbody)
        {
            Grab = true;
        }
    }
}
