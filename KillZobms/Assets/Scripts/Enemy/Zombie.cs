using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public int health;
    private float maxHealth;
    [SerializeField] int damage;
    [SerializeField] Animator animator;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layer;
    [SerializeField] float delay = 1;
    private float timeBtwAttack;
    private bool canDie = true;
    private NavMeshAgent agent;
    private GameObject playerController;
    private bool canDo = true;

    private void Start()
    {
        maxHealth = health;
        playerController = FindAnyObjectByType<FirstPersonController>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(playerController.transform.position);
        if (health <= 0 && canDie)
        {
            Die();
        }
        if (health <= maxHealth / 2&&canDo)
        {
            canDo = false;
            animator.SetBool("isRun",true);
            agent.speed *= 2;
            agent.angularSpeed *= 2;
        }
        if (timeBtwAttack <= 0)
            Attack();
        else timeBtwAttack -= Time.deltaTime;
    }

    private void Attack()
    {
        timeBtwAttack = delay;
        Vector3 dir = (playerController.transform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position,dir,out RaycastHit hit,maxDistance, layer))
        {
            animator.SetInteger("Attack",1);
           var ch = hit.collider.gameObject.GetComponent<CharacterHealth>();
            StartCoroutine(DamageAfter(ch));
        }
        else
        {
            animator.SetInteger("Attack", 0);
        }
    }

    private void Die()
    {
        agent.speed=0;
        agent.angularSpeed = 0;
        canDie = false;
        animator.SetTrigger("Die");
        BoxCollider[] colliders = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider collider in colliders)
        {
            if (collider.enabled) collider.enabled = false;
            else collider.enabled = true;
        }
    }

    private IEnumerator DamageAfter(CharacterHealth ch)
    {
        yield return new WaitForSeconds(0.17f);
        ch.GetDamage(damage);

    }
}
