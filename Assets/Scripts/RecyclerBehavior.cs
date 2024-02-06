using UnityEngine;

public class RecyclerEnemy : MonoBehaviour
{
    public float proximityRange = 5f;
    public float attackRange = 2f;
    public float movementSpeed = 2f;

    private Animator animator;
    private Transform player;
    private bool isPlayerInRange = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform; 
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!isPlayerInRange)
        {

            animator.Play("Recycler.Idle.Gnawing");

            // Check if player is in proximity
            if (distanceToPlayer < proximityRange)
            {
                isPlayerInRange = true;
            }
        }
        else
        {
            animator.Play("Recycler.Walk.Forward");
            transform.LookAt(player);

            if (distanceToPlayer < attackRange)
            {
                animator.Play("Recycler.Attack.Standard");

                // hurt player logic. are we still doing 5 hearts? 
            }
            else
            {
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
        }
    }

    public void TakeDamage()
    {
        // Perform Damage Die animation
        animator.Play("Recycler.Damage.Die");

        Destroy(gameObject, 2f); // Destroy the enemy after 2 seconds
    }
}