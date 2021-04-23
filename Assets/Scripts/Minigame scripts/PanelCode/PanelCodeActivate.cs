using UnityEngine;

public class PanelCodeActivate : InteractableBox
{
    public static PanelCodeActivate panelCode;
    [SerializeField] private GameObject board;

    private void Awake()
    {
        panelCode = this;
        hintHeight = 12f;
    }

    protected override void OnInteraction()
    {
        board.SetActive(true);
        isAlreadyUsed = true;
    }
}
