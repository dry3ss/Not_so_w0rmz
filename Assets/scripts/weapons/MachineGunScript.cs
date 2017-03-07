using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunScript : WeaponScript
{
    void Awake ()
    {
        default_ammo = 100;
        cooldown = 0.1f;
        initial_velocity = 50;
    }
}
