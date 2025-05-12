using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int health = 100;
    public void TakeDamage()
    {
        health -= 50;
        if (health <= 0)
            Dead();


    }
    void Dead()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bulelt"))
            TakeDamage();

    }


}
