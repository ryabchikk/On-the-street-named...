using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Text[] textBlocks = new Text[3];

    private void Start()
    {
        FlashDrive.drive.Completed += () => ActivateText(0);
        KakuroBox.kakuroBox.Completed += () => ActivateText(1);
        PanelCodeActivate.panelCode.Completed += () => ActivateText(2);
    }

    private void ActivateText(int index)
    {
        UpscreenNotificator.Notify("Информационная панель обновлена");
        textBlocks[index].enabled = true;
    }

    /*private void OnDestroy()
    {
        FlashDrive.drive.Completed -= ActivateFirstText;
        KakuroBox.kakuroBox.Completed -= ActivateSecondText;
        PanelCodeActivate.panelCode.Completed -= ActivateThirdText;
    }*/
}
