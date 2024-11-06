using System.Collections;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int health;
    [SerializeField] GameObject DamageUI;
    [SerializeField] GameObject AidUI;
    [SerializeField] AudioSource healSound;

    private void Update()
    {
        if (health <= 0) Time.timeScale = 0;
    }

    public void GetDamage(int dam)
    {
        health -= dam;
        DamageUI.SetActive(true);
        StartCoroutine(CloseUI(DamageUI));
    }

    public void GetAid(int heal)
    {
        healSound.Play();
        health = heal;
        AidUI.SetActive(true);
        StartCoroutine(CloseUI(AidUI));
    }

    IEnumerator CloseUI(GameObject UI)
    {
        yield return new WaitForSeconds(0.1f);
        UI.SetActive(false);
    }
}
