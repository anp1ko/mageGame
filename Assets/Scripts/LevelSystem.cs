using System;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    
    public static event Action OnExperienceChanged;
    public static event Action OnLevelChanged;
    
    private int _level;
    private int _experience;
    private int _experienceToNextLevel;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public LevelSystem()
    {
        _level = 0;
        _experience = 0;
        _experienceToNextLevel = 100;
    }

    public void AddExperience(int amount)
    {
        _experience += amount;
        if (_experience >= _experienceToNextLevel)
        {
            //Enough experience to level up
            _level++;
            _experience -= _experienceToNextLevel;
            OnLevelChanged?.Invoke();
        }
        OnExperienceChanged?.Invoke();
    }

    public int GetLevelNumber()
    {
        return _level;
    }

    public float GetExperienceNormalized()
    {
        return (float)_experience / _experienceToNextLevel;
    }
}
