using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour , Destroyable
{
    public int lifes = 1;

    public void TakeDamage()
    {
        lifes--;

        if (lifes <= 0)
            Destroy(this.gameObject);
    }
}
