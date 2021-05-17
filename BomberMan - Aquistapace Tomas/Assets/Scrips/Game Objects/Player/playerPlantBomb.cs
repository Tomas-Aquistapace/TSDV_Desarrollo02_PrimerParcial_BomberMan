using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlantBomb : MonoBehaviour
{
    public GameObject bombPref;

    public bool bombPlanted;

    private void Start()
    {
        bombPlanted = false;
    }

    void Update()
    {
        InputBomb();
    }

    void InputBomb()
    {
        if (Input.GetButtonDown("Jump"))
        {
            bool hableToMove = GetComponent<PlayerMove>().hableToMove;

            if (hableToMove && bombPlanted == false)
            {
                bombPlanted = true;

                GameObject go = Instantiate(bombPref);
                go.transform.position = transform.position;

                StartCoroutine(TimeBetweenBomb(go));
            }
        }
    }

    IEnumerator TimeBetweenBomb(GameObject go)
    {
        float time = 0;

        while (time < go.GetComponent<DetonateBomb>().timerToExplode)
        {
            time += Time.deltaTime;

            yield return null;
        }

        bombPlanted = false;

        yield return true;
    }
}
