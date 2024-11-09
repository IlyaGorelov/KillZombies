using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using YG;

public class Zombie : MonoBehaviour
{
    public int health;
    private float maxHealth;
    [SerializeField] int damage;
    [SerializeField] Animator animator;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layer;
    [SerializeField] float delay = 1;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource handSound;
    [SerializeField] AudioSource dieSound;
    private float timeBtwAttack;
    private bool isDead = false;
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

        CrySound();
        if (!isDead)
            agent.SetDestination(playerController.transform.position);


        if (health <= 0 && !isDead)
        {
            Die();
        }
        if (health <= maxHealth / 2 && canDo)
        {
            canDo = false;
            animator.SetBool("isRun", true);
            agent.speed *= 2;
            agent.angularSpeed *= 2;
        }
        if (timeBtwAttack <= 0 && !isDead)
            Attack();
        else timeBtwAttack -= Time.deltaTime;
    }

    void CrySound()
    {
        int rand = Random.Range(0, 100000);
        if (rand == 100)
        {
            if (!isDead)
                sound.Play();
        }
    }

    private void Attack()
    {
        timeBtwAttack = delay;
        Vector3 dir = (playerController.transform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, maxDistance, layer))
        {
            animator.SetTrigger("Attack");
            agent.SetDestination(transform.position);
            var ch = hit.collider.gameObject.GetComponent<CharacterHealth>();
            StartCoroutine(DamageAfter(ch));
        }
    }

    private void Die()
    {
        dieSound.Play();
        agent.SetDestination(transform.position);
        agent.angularSpeed = 0;
        isDead = true;
        animator.SetTrigger("Die");
        BoxCollider[] colliders = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider collider in colliders)
        {
            if (collider.enabled) collider.enabled = false;
            else collider.enabled = true;
        }
        WaveState.zombiesCount--;
        if (WaveState.zombiesCount == 0) WaveState.isRest = true;

        if (WaveState.zombiesCount == 0 && WaveState.waveCount == 5)
        {
            ShowWinUI.isWin = true;
            switch (WaveState.type)
            {
                case 0:
                    YandexGame.savesData.isVillageClean = 1;
                    break;
                case 1:
                    YandexGame.savesData.isMansionClean = 1;
                    break;
                case 2:
                    YandexGame.savesData.isDumpClean = 1;
                    break;
            }
            YandexGame.SaveProgress();
        }

        if (SceneManager.GetActiveScene().buildIndex % 2 == 0)
        {
            InfWaveState.kills++;
            InfWaveState.zombiesCount--;
        }

        StartCoroutine(DestroyAfter());
    }

    private IEnumerator DamageAfter(CharacterHealth ch)
    {
        handSound.Play();
        yield return new WaitForSeconds(0.2f);
        if (Vector3.Distance(transform.position, playerController.transform.position) <= maxDistance)
            ch.GetDamage(damage / 2);
        handSound.Play();
        yield return new WaitForSeconds(0.4f);
        if (Vector3.Distance(transform.position, playerController.transform.position) <= maxDistance)
            ch.GetDamage(damage / 2);
        yield return new WaitForSeconds(0.4f);
        agent.SetDestination(playerController.transform.position);

    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }

}
