using UnityEngine;
using UnityEngine.UI;

//Скрипт для объекта который будет вызывать какуро
//На объекте добавить триггер коллайдер в который нужно будет зайти чтобы начать

public class TestBox : InteractableBox
{
    [SerializeField] private GameObject board;               //В инспекторе сюда префаб доски
    [SerializeField] private Text text;
    [SerializeField] private Portal portal;
    private Player _player;
    private bool _flashCollected;
    private bool _kakuroCompleted;
    private bool _lockCompleted;

    private void Start()
    {
        _player = Player.player;
        KakuroBox.kakuroBox.Completed += OnKakuroCompleted;
        FlashDrive.drive.Completed += OnFlashCollected;
        PanelCodeActivate.panelCode.Completed += OnLockCompleted;
        hintHeight = 18f;
    }

    public void Success()
    {
        portal.Open();
    }

    private void OnFlashCollected() => _flashCollected = true;

    private void OnKakuroCompleted() => _kakuroCompleted = true;

    private void OnLockCompleted() => _lockCompleted = true;

    protected override void OnInteraction()
    {
        if (_flashCollected && _kakuroCompleted && _lockCompleted)
            StartTest();
        else
            Debug.Log("TODO добавить сообщение о том, что не все пройдено");
    }

    private void StartTest()
    {
        _player.DeactivateShooting();
        Instantiate(board).GetComponent<TestBoard>().box = this;
        text.enabled = true;
    }
}
