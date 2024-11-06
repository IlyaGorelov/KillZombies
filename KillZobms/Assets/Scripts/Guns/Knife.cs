using System;
using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform spawn;
    [SerializeField] AudioSource shoot;
    [SerializeField] int damage;
    [SerializeField] float delay;
    [SerializeField] GameObject bodyEffect;
    private float timeBeforeShot;
    [SerializeField] float minDistance;
    [SerializeField] Camera cam;

    private void OnEnable()
    {
        animator.SetTrigger("Show");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && timeBeforeShot <= 0)
        {
            timeBeforeShot = delay;
            Shooting();
        }
        else if (delay > 0)
            timeBeforeShot -= Time.deltaTime;

    }


    private void Shooting()
    {
        PlaySound();
        
        animator.SetTrigger("Stop");
        animator.SetTrigger("Shoot");
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
            StartCoroutine(DoAfter(0.5f, hit));

        }
    }



    private void PlaySound()
    {
        shoot.Stop();
        shoot.Play();
    }

    

    private IEnumerator DestroyAfter(int sec, GameObject g)
    {
        yield return new WaitForSeconds(sec);
        if (g != null)
            Destroy(g);
    }

    private IEnumerator DoAfter(float sec, RaycastHit hit)
    {
            yield return new WaitForSeconds(sec);
        if (hit.collider.gameObject.layer == 7 && Vector3.Distance(hit.point, spawn.position) <= minDistance)
        {
            
            var g = Instantiate(bodyEffect, hit.point, Quaternion.identity);
            if (hit.collider.gameObject.TryGetComponent(out TakeDamage td))
                td.GetDamage(damage);
            StartCoroutine(DestroyAfter(5, g));
        }
        if (hit.collider.gameObject.layer == 8 && Vector3.Distance(hit.point, spawn.position) <= minDistance)
        {
            if (hit.collider.gameObject.TryGetComponent(out DestroyableThing td))
                td.GetDamage(damage);
        }
    }

}
