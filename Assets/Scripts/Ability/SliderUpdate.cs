using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour
{
    [SerializeField] Slider reloadSlider;
    public Ability skill;

    void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        if (!skill.onCooldown)
            return;
        
        skill.timePassed += Time.deltaTime;
        reloadSlider.value = reloadSlider.maxValue - skill.timePassed / skill.timeCooldown;
    }
}
