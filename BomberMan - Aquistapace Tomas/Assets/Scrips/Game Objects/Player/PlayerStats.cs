using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour , Destroyable
{
    public int lifes = 3;
    public int points;
    public float invulnerabilityTime = 2f;
    public bool invulnerable;
    public bool isDead;

    private Renderer render;

    void Start()
    {
        points = 0;
        invulnerable = false;
        isDead = false;

        render = transform.GetComponent<Renderer>();
    }

    public void TakeDamage()
    {
        if (!invulnerable)
        {
            SubtractLife();

            StartCoroutine(ReceiveDamage());

            if (lifes <= 0)
                SetIsDead(true);
        }
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

    IEnumerator ReceiveDamage()
    {
        float lenght = 0.5f;
        float time = 0;
        float colorTime = 0;

        Color originalColor = render.material.color;
        invulnerable = true;

        while (time <= invulnerabilityTime)
        {
            render.material.color = Color.Lerp(originalColor, Color.white, colorTime);

            colorTime = Mathf.PingPong(Time.time, lenght);

            time += Time.deltaTime;

            yield return null;
        }

        render.material.color = originalColor;
        invulnerable = false;

        yield return true;
    }
}
