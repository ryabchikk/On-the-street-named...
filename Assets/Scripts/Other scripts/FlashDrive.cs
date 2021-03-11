using System;

public class FlashDrive : InteractableBox
{
    public static event Action Collected;

    private static void OnCollected() => Collected?.Invoke();

    protected override void OnInteraction()
    {
        OnCollected();
        Destroy(gameObject);
    }
}
