using UnityEngine;

public class ShowWinUI : MonoBehaviour
{
    public static bool isWin = false;
    [SerializeField] GameObject WinUI;

    private void Start()
    {
        isWin = false;
    }

    private void Update()
    {
        if (isWin)
        {
            WinUI.SetActive(true);
        }
    }
}
