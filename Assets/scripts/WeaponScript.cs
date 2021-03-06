﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{


    public Transform projectile_prefab;
    public int default_ammo = 100;
    public float cooldown =0.5f;
    public float initial_velocity = 20;

    private float current_cooldown = 0f;

    void Update()
    {
        if (current_cooldown > 0)
        {
            current_cooldown -= Time.deltaTime;
        }
    }

    //spawn_angle in degrees
    public void Attack()
   {
        if(current_cooldown <= 0f)
        {
            Vector3 current_direction = this.transform.up;
            var q = Quaternion.FromToRotation(Vector3.left, current_direction);
            var projectile = Instantiate(projectile_prefab, transform.position+current_direction, q);
            Rigidbody2D proj_rb = projectile.GetComponent<Rigidbody2D>();
            proj_rb.velocity = initial_velocity * current_direction;

            current_cooldown += cooldown;
        }
   }

    public static float getAngleZDegreesFromDirection(Vector3 current_direction)
    {
        if (current_direction.x != 0)
            return (float)(180.0f*Math.Atan(current_direction.y / current_direction.x)/Math.PI);
        else
            return 0;
    }
}
