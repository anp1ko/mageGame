using System;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public float maxMana = 100f;
    public float currentMana;
    public float manaRechargeRate = 2f;

    public ManaBar manaBar;

    private void Start()
    {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    private void Update()
    {
        RegenerateMana();
    }

    private void RegenerateMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += manaRechargeRate * Time.deltaTime;
            currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
            manaBar.SetMana(currentMana);
        }
    }
}
