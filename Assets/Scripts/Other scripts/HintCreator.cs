public class HintCreator : HintCreatorBase
{
    protected override void OnEnter()
    {
        hint.SetActive(true);
    }

    protected override void OnExit()
    {
        hint.SetActive(false);
    }
}
