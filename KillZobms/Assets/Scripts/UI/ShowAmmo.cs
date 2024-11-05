using TMPro;
using UnityEngine;

public class ShowAmmo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject[] guns;

   

    void Update()
    {
        foreach (GameObject go in guns)
        {
            if (go.activeSelf)
            {
                Weapon weapon = go.GetComponent<Weapon>();
                if (weapon != null)
                {
                    try
                    {
                        text.text = $"{weapon.magazine} / {weapon.allAmmo}";
                    }
                    catch
                    {
                        text.text = $"- / -";
                    }
                }
                else
                {
                    Shotgun shotgun = go.GetComponent<Shotgun>();
                    try
                    {
                        text.text = $"{shotgun.magazine} / {shotgun.allAmmo}";
                    }
                    catch
                    {
                        text.text = $"- / -";
                    }
                }
            }
        }
    }
}
