using UnityEngine;
using UnityEngine.UI;

//Скрипт для объекта который будет вызывать какуро
//На объекте добавить триггер коллайдер в который нужно будет зайти чтобы начать

public class TestBox : InteractableBox
{
    [SerializeField] private GameObject board;               //В инспекторе сюда префаб доски
    [SerializeField] private Text text;
    [SerializeField] private Portal portal;
    [SerializeField] private QuestContainer quests;
    private Player _player;

    private void Start()
    {
        _player = Player.player;
        hintHeight = 18f;
    }

    public void Success()
    {
        portal.Open();
    }

    protected override void OnInteraction()
    {
        int i = 0;
        
        foreach (var quest in quests.quests)
        {
            if (quest.completed)
                i++;
        }
        
        if (i >= quests.quests.Count - 1)
            StartTest();
        else
            UpscreenNotificator.Notify("Не все задания выполнены");
    }

    private void StartTest()
    {
        _player.DeactivateShooting();
        Instantiate(board).GetComponent<TestBoard>().box = this;
        text.enabled = true;
    }
}
