using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public float damageInstant = 1;
    public float damageAreaMax = 5;
    public float damageAreaMin = 3;

    public int radius = 2;

    // Use this for initialization
    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 20); // 20sec
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
            player.Damage((int)damageInstant);
        }
        else
        {
            // It's the floor, we check the area damages
            Collider2D[] allUnit = Physics2D.OverlapCircleAll(new Vector2(this.transform.position.x, this.transform.position.y), radius);

            for (int i = 0; i < allUnit.Length; i++)
            {
                applyDamages(allUnit[i], this.transform.position);
            }
        }
        
        // Destroy the shot
        Destroy(this.gameObject); // Remember to always target the game object, otherwise you will just remove the script
    }

    void applyDamages(Collider2D entity, Vector2 positionBullet)
    {
        Vector2 positionCible = new Vector2(entity.transform.position.x, entity.transform.position.y);
        float distance = Vector2.Distance(positionCible, positionBullet);

        // Bug to fix : the distance is beetween the 2 origin, which are not the centers but the corners
        if (distance < radius)
        {
            Health player = entity.gameObject.GetComponent<Health>();
            int damages = (int)((damageAreaMax - damageAreaMin) * (radius - distance) / radius);
            if (player != null)
            {
                player.Damage(damages);
            }
        }
    }
}
