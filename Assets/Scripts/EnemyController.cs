using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /* Enemy Type:
     * 0 = Recycler
     * 1 = Tross
     * 
     */
    private int enemyType;
    private int health;
    private GameObject self;
    private bool damagable;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        damagable = true;
        switch (gameObject.name)
        {
            case string name when name.StartsWith("Recycler"):
                enemyType = 0;
                health = 1;
                break;
            case string name when name.StartsWith("Tross"):
                enemyType = 1;
                health = 3;
                break;
            // Add more cases as needed
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            damagable = false;
            // Play death animation
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("SpearHitbox"))
        {
            health--;
            damagable = false;
        }
    }
}
