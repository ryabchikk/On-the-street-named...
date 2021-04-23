using System;

public class FlashDrive : InteractableBox
{
    public static FlashDrive drive;

    private void Awake()
    {
        drive = this;
    }

    protected override void OnInteraction()
    {
        OnCompleted();
        Destroy(gameObject);
    }
}
