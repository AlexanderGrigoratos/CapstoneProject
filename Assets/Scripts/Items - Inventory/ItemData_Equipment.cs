using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Amulet,
    Flask
}

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Equipment")]

public class ItemData_Equipment : ItemData
{
    public EquipmentType equipmentType;


    public float itemCooldown;
    public ItemEffect[] itemEffects;



    [Header("Major Stats")]
    public int strength;
    public int agility;
    public int intelligence;
    public int vitality;

    [Header("Offensive Stats")]
    public int damage;
    public int critChance;
    public int critPower;

    [Header("Defensive Stats")]
    public int maxHealth;
    public int armor;
    public int evasion;
    public int magicResistance;

    [Header("Magic Stats")]
    public int fireDamage;
    public int iceDamage;
    public int lightningDamage;

    [Header("Craft Requirements")]
    public List<InventoryItem> craftingMaterials;

    private int descriptionLength;

    public void Effect(Transform _enemyPosition)
    {
        foreach (var item in itemEffects)
        {
            item.ExecuteEffect(_enemyPosition);
        }
    }

    public void AddModifiers()
    {
        PlayerStats playerstats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        playerstats.strength.AddModifier(strength);
        playerstats.agility.AddModifier(agility);
        playerstats.intelligence.AddModifier(intelligence);
        playerstats.vitality.AddModifier(vitality);

        playerstats.damage.AddModifier(damage);
        playerstats.critChance.AddModifier(critChance);
        playerstats.critPower.AddModifier(critPower);

        playerstats.maxHealth.AddModifier(maxHealth);
        playerstats.armor.AddModifier(armor);
        playerstats.evasion.AddModifier(evasion);
        playerstats.magicResistance.AddModifier(magicResistance);

        playerstats.fireDamage.AddModifier(fireDamage);
        playerstats.iceDamage.AddModifier(iceDamage);
        playerstats.lightningDamage.AddModifier(lightningDamage);
    }

    public void RemoveModifiers()
    {
        PlayerStats playerstats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        playerstats.strength.RemoveModifier(strength);
        playerstats.agility.RemoveModifier(agility);
        playerstats.intelligence.RemoveModifier(intelligence);
        playerstats.vitality.RemoveModifier(vitality);

        playerstats.damage.RemoveModifier(damage);
        playerstats.critChance.RemoveModifier(critChance);
        playerstats.critPower.RemoveModifier(critPower);

        playerstats.maxHealth.RemoveModifier(maxHealth);
        playerstats.armor.RemoveModifier(armor);
        playerstats.evasion.RemoveModifier(evasion);
        playerstats.magicResistance.RemoveModifier(magicResistance);

        playerstats.fireDamage.RemoveModifier(fireDamage);
        playerstats.iceDamage.RemoveModifier(iceDamage);
        playerstats.lightningDamage.RemoveModifier(lightningDamage);
    }

    public override string GetDescription()
    {
        sb.Length = 0;
        descriptionLength = 0;

        AddItemDescription(strength, "Strength");
        AddItemDescription(agility, "Agility");
        AddItemDescription(intelligence, "Intelligence");
        AddItemDescription(vitality, "Vitality");

        AddItemDescription(damage, "Damage");
        AddItemDescription(critChance, "Crit Chance");
        AddItemDescription(critPower, "Crit Power");

        AddItemDescription(maxHealth, "Health");
        AddItemDescription(armor, "Armor");
        AddItemDescription(evasion, "Evasion");
        AddItemDescription(magicResistance, "Magic Resistance");

        AddItemDescription(fireDamage, "Fire Damage");
        AddItemDescription(iceDamage, "Ice Damage");
        AddItemDescription(lightningDamage, "Lightning Damage");

        if (descriptionLength < 5)
        {
            for (int i = 0; i < 5 - descriptionLength; i++)
            {
                sb.AppendLine();
                sb.Append("");
            }
        }

        return sb.ToString();


    }

    private void AddItemDescription (int _value, string _name)
    {
        if (_value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (_value > 0)
                sb.Append("+ " + _value + " " + _name);

            descriptionLength++;
        }

    }

}
