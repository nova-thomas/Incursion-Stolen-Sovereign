using JetBrains.Annotations;
using UnityEngine;

public class RecyclerEnemy : MonoBehaviour
{
    public int HP = 1;
    public Animator animator;
   
    
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("Die");
        }
    }
}