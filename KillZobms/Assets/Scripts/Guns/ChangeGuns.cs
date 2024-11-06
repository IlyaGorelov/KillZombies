using System.Collections;
using UnityEngine;

public class ChangeGuns : MonoBehaviour
{
    [SerializeField] GameObject[] guns;
    public int gunId=0;
    [SerializeField] GameObject ChangeUI;
    [SerializeField] AudioSource ammoSound;

    // Update is called once per frame
    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");

        if (mw > 0)
        {
            gunId += 1;
            ChangeGunActive();
        }
        else if (mw < 0)
        {
            gunId -= 1;
            ChangeGunActive();
            
        }
    }

    private void ChangeGunActive()
    {
        if (gunId == guns.Length) gunId -= 1;
        if (gunId == -1) gunId += 1;
        if (!ChangeUI.activeSelf)
            StartCoroutine(ShowUI());
        foreach (var gun in guns) 
        {
            gun.SetActive(false);
        }
        guns[gunId].SetActive(true);
    }

    private IEnumerator ShowUI()
    {
        ChangeUI.SetActive(true);
        yield return new WaitForSeconds(3);
        ChangeUI.SetActive(false);
    }

    public void PlaySound()
    {
        ammoSound.Play();
    }
}
