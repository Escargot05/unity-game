using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private ScoreCounter scoreCounter;

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float timeBetweenAttacks = 2.5f;
    [SerializeField] private float attackRange = 2.5f;
    [SerializeField] private int attackDamage = 1;

    int currentHealth;
    bool alreadyAttacked;
    bool playerInAttackRange;
    string currentAnimationState;
    Color originalColor; 

    public const string RUN = "Run";
    public const string ATTACK = "Attack";

    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        originalColor = GetComponentInChildren<Renderer>().material.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void Update()
    {
        ChasePlayer();
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);
        if (playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimationState == newState) return;

        currentAnimationState = newState;
        animator.CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        { 
            Death(); 
        }
        GetComponentInChildren<Renderer>().material.color = Color.red;
        Invoke(nameof(ResetColor), 0.7f);
    }



    void Death()
    {
        scoreCounter.AddScore(10);
        Destroy(gameObject);
    }

    void ChasePlayer()
    {
        if (!alreadyAttacked)
        {
            agent.SetDestination(player.position);
            ChangeAnimationState(RUN);
        }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
            ChangeAnimationState(ATTACK);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void ResetColor()
    {
        GetComponentInChildren<Renderer>().material.color = originalColor;
    }


}
