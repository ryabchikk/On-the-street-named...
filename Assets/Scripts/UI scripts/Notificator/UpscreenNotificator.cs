using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpscreenNotificator
{
    private static UpscreenNotification _notificator;
    
    public static void Notify(string message)
    {
        _notificator.Notify(message);
    }
    
    internal static void CreateNotificator(UpscreenNotification notificator)
    {
        var upscreenNotificator = new UpscreenNotificator(notificator);
    }

    private UpscreenNotificator(UpscreenNotification notificator)
    {
        _notificator = notificator;
    }
}
