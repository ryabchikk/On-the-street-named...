using System;

public class FlashDrive : InteractableBox
{
    protected override void OnInteraction()
    {
        OnCompleted();
        Destroy(gameObject);
    }
}
