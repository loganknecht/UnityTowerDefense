using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Unity.Collections;
using UnityEngine;

public class Zombie : Enemy
{
    // -------------------------------------------------------------------------
    // State
    // -------------------------------------------------------------------------
    public float horizontalMovement = 0.01f;
    public Transform transformGameObject = null;
    public bool hasReachedPlant = false;
    // ---------- 
    public Plant currentPlantAttacking = null;

    public float attackDamage = 0.1f;
    public float attackCooldownTimer = 0f;
    public float attackCooldown = 3f;
    public bool hasPerformedAttack = false;

    // -------------------------------------------------------------------------
    // Unity Engine
    // -------------------------------------------------------------------------
    void Start()
    {

    }

    public override void Update()
    {
        this.PerformMovement();
        this.PerformAttack();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        this.hasReachedPlant = true;
        Plant currentPlant = other.gameObject.GetComponent<Plant>();

        if (currentPlant != null)
        {
            this.currentPlantAttacking = currentPlant;
        }
    }


    // -------------------------------------------------------------------------
    // Custom
    // -------------------------------------------------------------------------
    public void PerformMovement()
    {
        if (this.hasReachedPlant == false)
        {
            this.transformGameObject.position = new Vector3(this.transform.position.x - this.horizontalMovement,
                                                            this.transform.position.y,
                                                            this.transform.position.z);
        }
    }

    public void PerformAttack()
    {
        if (currentPlantAttacking != null && hasPerformedAttack == false)
        {
            this.currentPlantAttacking.health.currentHealth -= this.attackDamage;
            this.hasPerformedAttack = true;
            this.attackCooldownTimer = 0;
        }

        if (this.hasPerformedAttack == true
            && this.attackCooldownTimer > this.attackCooldown)
        {
            this.hasPerformedAttack = false;
        }
        else
        {
            this.attackCooldownTimer += Time.deltaTime;
        }

        if (this.currentPlantAttacking == null)
        {
            this.currentPlantAttacking = null;
            this.hasReachedPlant = false;
        }
    }
}
