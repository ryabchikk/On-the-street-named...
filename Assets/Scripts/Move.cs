using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   

public class Move : MonoBehaviour
{
    public float distance = 20.0f;
    void FixedUpdate()
    {
        
       

        Vector3 PositionHero = GameObject.Find("main character").GetComponent<Transform>().position;
        Vector3 PositionEnemy = gameObject.GetComponent<Transform>().position;
        Vector3 Delta = PositionHero - PositionEnemy;
        if (Vector3.Distance(PositionEnemy,PositionHero)>=distance)
        {
            PositionEnemy += Delta * Time.deltaTime;
            gameObject.GetComponent<Transform>().position = PositionEnemy;
        }
    }
}

