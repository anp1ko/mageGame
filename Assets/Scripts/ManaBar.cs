using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public void SetMana(float mana)
    {
        slider.value = mana;
    }

    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }
}
