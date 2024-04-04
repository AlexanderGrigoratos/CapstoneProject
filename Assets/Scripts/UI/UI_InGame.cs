using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_InGame : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Slider slider;

    [SerializeField] private Image dashImage;
    [SerializeField] private float dashCooldown;
   

    [SerializeField] private TextMeshProUGUI currentSouls;
    private SkillManager skills;

    void Start()
    {
        if (playerStats != null)
            playerStats.onHealthChanged += UpdateHealthUI;

        dashCooldown = SkillManager.instance.dash.cooldown;

        skills = SkillManager.instance;
    }

    void Update()
    {

        currentSouls.text = PlayerManager.instance.GetCurrency().ToString("#,#");

        if (Input.GetKeyDown(KeyCode.LeftShift))
            SetCooldownOf(dashImage);

      

    }

    private void UpdateHealthUI()
    {
        slider.maxValue = playerStats.GetMaxHealthValue();
        slider.value = playerStats.currentHealth;
    }

    private void SetCooldownOf(Image _image)
    {
        if (_image.fillAmount <= 0)
            _image.fillAmount = 1;
    }

    private void CheckCooldownOf(Image _image, float _cooldown)
    {
        if (_image.fillAmount > 0)
            _image.fillAmount -= 1 / _cooldown * Time.deltaTime;
    }

}