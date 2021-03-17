using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryHealthSlider : HealthSliderBase
{
    public override void Change(int amount)
    {
        StartCoroutine(Fade(amount));
    }

    private IEnumerator Fade(int amountToFade)
    {
        yield return new WaitForSeconds(1f);
        while (slider.value > (float)amountToFade / maxHealth)
        {
            slider.value -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
