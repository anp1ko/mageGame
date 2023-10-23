using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private LevelSystem _levelSystem;

    public float fillSpeed = 0.5f;

    private void Awake()
    {
        SetLevelSystem();
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        _slider.value = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        _levelText.text = $"Уровень {levelNumber + 1}";
    }

    public void SetLevelSystem()
    {
        // Update to starting values
        SetLevelNumber(_levelSystem.GetLevelNumber());
        SetExperienceBarSize(_levelSystem.GetExperienceNormalized());

        // Subscribe to the changed events
        LevelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        LevelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged()
    {
        // Experience changed, update text
        SetExperienceBarSize(_levelSystem.GetExperienceNormalized());
    }

    private void LevelSystem_OnLevelChanged()
    {
        // Level changed, update text
        SetLevelNumber(_levelSystem.GetLevelNumber());
    }
}
