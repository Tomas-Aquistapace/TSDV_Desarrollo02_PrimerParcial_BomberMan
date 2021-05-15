using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonateBomb : MonoBehaviour
{
    public float timerToExplode = 3;
    public float blastRange = 1;

    void OnEnable()
    {
        StartCoroutine(Detonate());
    }
    
    IEnumerator Detonate()
    {
        Debug.Log("Me detoné");

        float time = 0;

        while (time < timerToExplode)
        {
            time += Time.deltaTime;

            yield return null;
        }

        Explosion();

        yield return true;
    }

    void Explosion()
    {
        Debug.Log("exploté");

        Destroy(this.gameObject);
    }
}
