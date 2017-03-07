using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public int damage = 1;
    // Use this for initialization
    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 3); // 20sec
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        Health player = otherCollider.gameObject.GetComponent<Health>();
        if (player != null)
        {
            player.Damage(damage);
        }

        Collider[] allUnit = Physics.OverlapSphere(this.transform.position, 1);

        // Destroy the shot
        Destroy(this.gameObject); // Remember to always target the game object, otherwise you will just remove the script
    }
}
