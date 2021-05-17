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

        CollisionChecks(transform.position, Vector3.forward);

        CollisionChecks(transform.position, - Vector3.forward);

        CollisionChecks(transform.position, - Vector3.right);

        CollisionChecks(transform.position, Vector3.right);
        
        CollisionChecks(transform.position + Vector3.up, -Vector3.up);
        
        Destroy(this.gameObject);
    }

    void CollisionChecks(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;

        Ray collisionRay = new Ray(origin, direction);

        if (Physics.Raycast(collisionRay, out hit, blastRange))
        {
            // Colisiono con algo
            Debug.Log("Colisiono con: " + hit.transform.name);

            if (hit.transform.tag == "Player")
            {
                PlayerStats playerGO = hit.transform.GetComponent<PlayerStats>();

                playerGO.TakeDamage();
            }
            else if (hit.transform.tag == "DestroyableWall")
            {
                DestroyWall wallGO = hit.transform.GetComponent<DestroyWall>();

                wallGO.TakeDamage();
            }
        }
        else
        {
            // No colosiono con nada
        }
    }

    // -------------------------------

    void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, new Vector3(0, 0, blastRange), Color.red);
        Debug.DrawRay(transform.position, new Vector3(0, 0, -blastRange), Color.red);
        Debug.DrawRay(transform.position, new Vector3(blastRange, 0, 0), Color.red);
        Debug.DrawRay(transform.position, new Vector3(-blastRange, 0, 0), Color.red);

        Debug.DrawRay(transform.position + Vector3.up, new Vector3(0, -1, 0), Color.blue);
    }
}
