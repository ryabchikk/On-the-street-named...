using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Text[] textBlocks = new Text[3];

    private void Start()
    {
        FlashDrive.Collected += ActivateFirstText;
        KakuroBox.Completed += ActivateSecondText;
        Lock.Completed += ActivateThirdText;
    }

    private void ActivateFirstText()
    {
        textBlocks[0].enabled = true;
    }

    private void ActivateSecondText()
    {
        textBlocks[1].enabled = true;
    }

    private void ActivateThirdText()
    {
        textBlocks[2].enabled = true;
    }

    private void OnDestroy()
    {
        FlashDrive.Collected -= ActivateFirstText;
        KakuroBox.Completed -= ActivateSecondText;
        Lock.Completed -= ActivateThirdText;
    }
}
