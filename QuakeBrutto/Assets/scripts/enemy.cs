using UnityEngine;

namespace Assets.scripts
{
    public class enemy : MonoBehaviour
    {
        public void TakeDamage(float amount)
        {
            this.GetComponent<Health>().Damage(amount);
            
            if (this.GetComponent<Health>().getHealth() <= 0f)
            {
                Die();
            }
        }


        void Die()
        {
            Destroy(gameObject);
        }
    }
}