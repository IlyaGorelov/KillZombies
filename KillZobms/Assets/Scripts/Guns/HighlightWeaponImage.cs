using UnityEngine;
using UnityEngine.UI;

public class HighlightWeaponImage : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] ChangeGuns changeGuns;
    Image image;
    private bool canChange = true;

    private void OnEnable()
    {
        image = GetComponent<Image>();
    }

    public void Update()
    {
        if (id == changeGuns.gunId&&canChange)
        {
            canChange = false;
            image.color += new Color(0,0,0, 0.4f);
        }else if (id!= changeGuns.gunId && image.color.a==1f)
        {
            canChange=true;
            image.color -= new Color(0, 0, 0, 0.4f);
        }

    }

}
