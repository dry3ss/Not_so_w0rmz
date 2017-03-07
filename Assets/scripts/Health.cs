using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class Health : MonoBehaviour
{
    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Dead!
            Destroy(gameObject);
        }
    }
}
