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
    private bool f = false;
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
                GRABI = GRABI + 1;
                switch (GRABI)
                {
                    case 1:
                        Grab = true;
                        break;
                    case 2:
                        Grab = false;
                        break;
                    default:
                        break;
                }
                if (GRABI == 3)
                {
                    GRABI = 0;
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
                hit.rigidbody.freezeRotation = true;
            }
        }
        //ф-ция толчка
        if (Throw)
        {
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = gameObject.transform.forward * throwPower;
                hit.rigidbody.freezeRotation = false;
                Throw = false;
            }
        }
    }
    /*private void Grabb()
    {
        Ray ray = camera.ScreenPointToRay(gameObject.transform.position);
        Physics.Raycast(ray, out hit, RayDistance);
        if (hit.rigidbody)
        {
            Grab = true;
        }
    }*/
}
