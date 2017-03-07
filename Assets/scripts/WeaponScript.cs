using System;
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
    public void Attack(Vector2 spawn_position)
   {
        if(current_cooldown <= 0f)
        {
            var projectile = Instantiate(projectile_prefab) as Transform;
            projectile.position = spawn_position;

            Vector3 current_direction = this.transform.right;
            //rotate the sprite of the projectile to face the right direction
            projectile.Rotate(new Vector3(0,0, 180+getAngleZDegreesFromDirection(current_direction)));
            //add the initial velocity with the right angle
            Rigidbody2D proj_rb = projectile.GetComponent<Rigidbody2D>();
            proj_rb.velocity = initial_velocity*current_direction;


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
