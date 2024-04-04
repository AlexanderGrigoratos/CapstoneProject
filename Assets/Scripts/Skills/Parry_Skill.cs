using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parry_Skill : Skill
{
    [Header("Parry")]
    [SerializeField] private Ui_SkillTreeSlot parryUnlockButton;
    public bool parryUnlocked { get; private set; }

    [Header("Parry Restore")]
    [SerializeField] private Ui_SkillTreeSlot restoreUnlockButton;
    [Range(0f, 1f)]
    [SerializeField] private float restoreHealthPercentage;
    public bool restoreUnlocked { get; private set; }

    [Header("Parry Mirage")]
    [SerializeField] private Ui_SkillTreeSlot parryMirageUnlockButton;
    public bool parryMirageUnlocked {  get; private set; }
    public override void UseSkill()
    {
        base.UseSkill();

        if (restoreUnlocked)

        {
            int restoreAmount = Mathf.RoundToInt(player.stats.GetMaxHealthValue() * restoreHealthPercentage);
            player.stats.IncreaseHealthBy(restoreAmount);
        }
    }

    protected override void Start()
    {
        base.Start();

        parryUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParry);
        restoreUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParryRestore);
        parryMirageUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParryMirage);
    }
    protected override void CheckUnlock()
    {
        UnlockParry();
        UnlockParryRestore();
        UnlockParryMirage();
    }

    private void UnlockParry()
    {
        if (parryUnlockButton.unlocked)
            parryUnlocked = true;

    }

    private void UnlockParryRestore()
    {
        if (restoreUnlockButton.unlocked)
            restoreUnlocked = true;
    }

    private void UnlockParryMirage()
    {
        if (parryMirageUnlockButton.unlocked)
            parryMirageUnlocked = true;
    }

    public void MakeMirageOnParry(Transform _respawnTransform)
    {
        if (parryMirageUnlocked)
            SkillManager.instance.clone.CreateCloneWithDelay(_respawnTransform);
    }
}
