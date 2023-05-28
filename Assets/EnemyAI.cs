using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Player;
    public Transform playert;
    public LayerMask whatIsGround, whatIsPlayer;
    private float enemyHealth = 90f;
    private float playerHealth = 90f;
    private Animator animator;
    private Animator animatorPlayer;
    private bool enemyMove;
    private float enemyDamage = 10f;
    public bool enemyAttack;


    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playert = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        animatorPlayer = Player.GetComponent<Animator>();
        
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange &&  !playerInSightRange) {Patrolling();} //görüþ ve attck menzilinde deðilse gez
        if (playerInSightRange && !playerInAttackRange) {ChasePlayer();} //görüþ menzilindeyse amaattack menzilinde deðilse kovala
        if (playerInAttackRange &&  playerInSightRange) {AttackPlayer();} // hem görüþ hem attack menzilindeyse attack player
    }

    private void Patrolling()
    {
        if (!walkPointSet) { SearchWalkPoint(); }
        if (walkPointSet) { agent.SetDestination(walkPoint); }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        animator.SetBool("enemyMove", true);
        animator.SetBool("enemyAttack", false);


        //WalkPoint Reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) { walkPointSet = true; }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(playert.position);
        animator.SetBool("enemyMove", true);
        animator.SetBool("enemyAttack", false);

    }
    private void AttackPlayer()
    {
        //Make sureenemy doesn't move
        agent.SetDestination(transform.position);
        animator.SetBool("enemyMove", false);
        animator.SetBool("enemyAttack", true);
        enemyAttack = true;
       



        transform.LookAt(playert);

        if (!alreadyAttacked)
        {
            //Attack code here
            
            animator.SetBool("enemyAttack", false);
            enemyAttack = false;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(30f);
        }

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("enemyAttack", true);
        enemyAttack = true;
    }
    public void TakeDamage(float damage)
    {

        enemyHealth -= damage;
        if (enemyHealth <= 0) { Invoke(nameof(DestroyEnemy), .5f); }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
   

}
