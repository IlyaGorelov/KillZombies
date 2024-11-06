using UnityEngine;
using UnityEngine.UI;

public class ShowHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] CharacterHealth health;


    private void Update()
    {
        slider.value = health.health;
    }
}
