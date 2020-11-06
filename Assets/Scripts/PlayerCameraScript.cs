using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    float mouseX;

    void Update() {
        mouseX += Input.GetAxis("Mouse X");
        this.gameObject.transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
