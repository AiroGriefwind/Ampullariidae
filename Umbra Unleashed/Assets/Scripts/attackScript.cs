using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{

    public HealthBar healthBar;
    public int currentHealth;
    public int maxHealth = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar) healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        // i know how to use on trigger enter, but i forgot the exact syntax and asked chatgpt for an example and learned about
        // this function!
        //if (other.CompareTag("Player"))
        //{
        //Debug.Log("taking damage");
        //DealDamage(2);

        //}
    }

    public int DealDamage(int amount) {
        currentHealth -= amount;
        if (healthBar) healthBar.SetHealth(currentHealth);
        return currentHealth;
    }
}
