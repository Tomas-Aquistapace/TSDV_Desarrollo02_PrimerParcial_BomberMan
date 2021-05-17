using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour , Destroyable
{
    public int lifes = 3;
    public int points;
    public bool isDead;

    void Start()
    {
        points = 0;
        isDead = false;
    }

    public void TakeDamage()
    {
        SubtractLife();

        if (lifes <= 0)
            SetIsDead(true);
    }

    private void SubtractLife()
    {
        lifes--;
    }

    public void SetPoints(int amount)
    {
        points = amount;
    }

    public void SetIsDead(bool state)
    {
        isDead = state;
    }
}
