using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WeaponsTypes
{
    MachineGun,RocketLauncher
}


public class Player : MonoBehaviour {

    public Vector2 speed = new Vector2(20, 20);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    private Dictionary<int,WeaponScript> weapons= new Dictionary<int, WeaponScript>();
    // Use this for initialization
    void Start ()
    {
        WeaponScript machine_gun=GetComponent<MachineGunScript>();
        if (machine_gun != null)
            weapons.Add((int)WeaponsTypes.MachineGun, machine_gun);
    }

    // Update is called once per frame
    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 4 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // attack for debug
        WeaponScript attack_weapon;        
        if (weapons.TryGetValue((int)WeaponsTypes.MachineGun, out attack_weapon))
        {
            Vector3 spawn_pos = this.transform.position;
            attack_weapon.Attack(spawn_pos);
        }
        

    }
    void FixedUpdate()
    {
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;
    }
}
