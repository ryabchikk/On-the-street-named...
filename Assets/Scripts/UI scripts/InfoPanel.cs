using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Text[] textBlocks = new Text[3];

    private void Start()
    {
        FlashDrive.drive.Completed += ActivateFirstText;
        KakuroBox.kakuroBox.Completed += ActivateSecondText;
        PanelCodeActivate.panelCode.Completed += ActivateThirdText;
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
        FlashDrive.drive.Completed -= ActivateFirstText;
        KakuroBox.kakuroBox.Completed -= ActivateSecondText;
        PanelCodeActivate.panelCode.Completed -= ActivateThirdText;
    }
}
