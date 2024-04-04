using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar_UI : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private CharacterStats myStats;

    private RectTransform myTransform;
    private Slider slider;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        slider = GetComponentInChildren<Slider>();
        entity.onFlipped += FlipUI;
        myStats.onHealthChanged += UpdateHealthUI;
        UpdateHealthUI();
    }

    private void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = myStats.GetMaxHealthValue();
        slider.value = myStats.currentHealth;
    }

    private void FlipUI()
    {
        myTransform.Rotate(0, 180, 0);
    }

    private void OnDisable()
    {
        entity.onFlipped -= FlipUI;
        myStats.onHealthChanged -= UpdateHealthUI;
    }
}