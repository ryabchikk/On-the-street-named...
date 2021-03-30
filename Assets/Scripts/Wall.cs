using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    
    [SerializeField] private Collider wall; 
   

    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.collider.GetComponent<CheckPlayer>()!= null)
        {
            wall.enabled = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        

        if (collision.collider.GetComponent<CheckPlayer>() != null)
        {
            wall.enabled = true ;
        }
    }
}
