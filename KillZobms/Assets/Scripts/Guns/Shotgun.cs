using System.Collections;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] Animator animator;
    public int magazine;
    [SerializeField] int fullMagazine;
    [SerializeField] int ammoInOneShot = 3;
    public int allAmmo;
    [SerializeField] AudioSource shoot;
    [SerializeField] AudioSource recharge;
    [SerializeField] GameObject bullet;
    [SerializeField] int damage;
    [SerializeField] Transform sleeveSpawn;
    [SerializeField] ParticleSystem shootParticle;
    [SerializeField] float delay;
    [SerializeField] GameObject groundEffect;
    [SerializeField] GameObject bodyEffect;
    private float timeBeforeShot;
    public Camera cam;
    [SerializeField] float spread;

    private void OnEnable()
    {
        animator.SetTrigger("Show");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && timeBeforeShot <= 0 && magazine > 0)
        {
            timeBeforeShot = delay;
            Shooting();
            magazine--;
        }
        else if (delay > 0)
            timeBeforeShot -= Time.deltaTime;
        if (magazine <= 0 && allAmmo > 0)
        {
            Recharging();
        }

        if (Input.GetKeyDown(KeyCode.R))
            Recharging();
    }

    private void Recharging()
    {
        timeBeforeShot += 1;
        if (allAmmo >= fullMagazine)
        {
            allAmmo -= fullMagazine;
            magazine += fullMagazine;
            animator.SetTrigger("Recharge");
            recharge.Play();
        }
        else
        {

            if (magazine + allAmmo <= fullMagazine)
            {
                magazine += allAmmo;
                allAmmo = 0;
            }
            else
            {
                magazine = fullMagazine;
                allAmmo -= fullMagazine - magazine;
            }

            animator.SetTrigger("Recharge");
            recharge.Play();
        }
    }

    private void Shooting()
    {
        shootParticle.Play();
        PlaySound();
        for (int i = 0; i < ammoInOneShot; i++)
        {


            Vector3 dir = CalculateDirectionAndSpreading().normalized;
            animator.SetTrigger("Stop");
            animator.SetTrigger("Shoot");
            Ray ray = new(cam.gameObject.transform.position,dir);
            var bulletBeing = Instantiate(bullet, sleeveSpawn.position, Quaternion.identity);
            bulletBeing.GetComponent<Rigidbody>().AddForce(sleeveSpawn.right * 1f);
             
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.layer == 6)
                {
                    var g = Instantiate(groundEffect, hit.point, Quaternion.identity);
                    StartCoroutine(DestroyAfter(5, g));
                }
                if (hit.collider.gameObject.layer == 7)
                {
                    var g = Instantiate(bodyEffect, hit.point, Quaternion.identity);
                    if (hit.collider.gameObject.TryGetComponent(out TakeDamage td))
                        td.GetDamage(damage);
                    StartCoroutine(DestroyAfter(5, g));
                }
                if (hit.collider.gameObject.layer == 8)
                {
                    var g = Instantiate(groundEffect, hit.point, Quaternion.identity);
                    if (hit.collider.gameObject.TryGetComponent(out DestroyableThing td))
                        td.GetDamage(damage);
                    StartCoroutine(DestroyAfter(5, g));
                }
            }
        }
    }

    private void PlaySound()
    {
        shoot.Stop();
        shoot.Play();
    }

    private Vector3 CalculateDirectionAndSpreading()
    {
        Ray rayFromCam = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Vector3 targetPoint;

        if (Physics.Raycast(rayFromCam, out RaycastHit hit))
            targetPoint = hit.point;
        else
            targetPoint = rayFromCam.GetPoint(100);

        Vector3 dir = targetPoint-cam.gameObject.transform.position;

        float xSpread = Random.Range(-spread, spread);
        float ySpread = Random.Range(-spread, spread);

        return dir + new Vector3(xSpread, ySpread, 0);
    }

    private IEnumerator DestroyAfter(int sec, GameObject g)
    {
        yield return new WaitForSeconds(sec);
        if (g != null)
            Destroy(g);
    }

}
