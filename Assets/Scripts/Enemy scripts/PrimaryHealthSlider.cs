using System.Collections;
using UnityEngine;

public class PrimaryHealthSlider : HealthSliderBase
{
    public override void Change(int amount)
    {
        StartCoroutine(UpdateSlider(amount));
    }

    private IEnumerator UpdateSlider(int amount)
    {
        yield return new WaitForEndOfFrame();
        slider.value = (float)amount / maxHealth;
    }
}
