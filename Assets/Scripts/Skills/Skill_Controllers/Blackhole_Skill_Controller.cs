using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole_Skill_Controller : MonoBehaviour
{
    [SerializeField] private GameObject hotKeyPrefab;
    [SerializeField] private List<KeyCode> keyCodeList;

    public float maxSize;
    public float growSpeed;
    public bool canGrow;

    private bool canAttack;
    public int amountOfAttacks = 4;
    public float cloneAttackCooldown = .3f;
    private float cloneAttackTimer;

    private List<Transform> targets = new List<Transform>();
    private List<GameObject> createdHotKey = new List<GameObject>();

    private void Update()
    {
        cloneAttackTimer -= Time.deltaTime;


        if(Input.GetKeyDown(KeyCode.R))
        {
            DestroyHotKeys();
            canAttack = true;
        }

        if(cloneAttackTimer < 0 && canAttack)
        {
            cloneAttackTimer = cloneAttackCooldown;

            int randomIndex = Random.Range(0, targets.Count);

            float xOffset;

            if (Random.Range(0, 100) > 500)
                xOffset = 1;
            else
                xOffset = -1;

            SkillManager.instance.clone.CreateClone(targets[randomIndex], new Vector3(xOffset, 0));
            amountOfAttacks--;

            if(amountOfAttacks <= 0)
            {
                canAttack = false;
            }
        }


        if (canGrow)
        {
            transform.localScale = Vector2.Lerp(transform.localScale , new Vector2 (maxSize, maxSize), growSpeed * Time.deltaTime);
        }

    }

    private void DestroyHotKeys()
    {
        if(createdHotKey.Count <= 0)
            return;
        {
            for(int i = 0; i < createdHotKey.Count; i++)
            {
                Destroy(createdHotKey[i]);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTime(true);
            CreateHotKey(collision);

        }
    }

    private void CreateHotKey(Collider2D collision)
    {
        if (keyCodeList.Count <= 0)
        {
            Debug.Log("Not enough hotkeys in keycode list");
            return;
        }

        GameObject newHotKey = Instantiate(hotKeyPrefab, collision.transform.position + new Vector3(0, 1), Quaternion.identity);
        createdHotKey.Add(newHotKey);

        KeyCode chosenKey = keyCodeList[Random.Range(0, keyCodeList.Count)];
        keyCodeList.Remove(chosenKey);

        Blackhole_HotKey_Controller newHotKeyScript = newHotKey.GetComponent<Blackhole_HotKey_Controller>();

        newHotKeyScript.SetupHotKey(chosenKey, collision.transform, this);
    }

    public void AddEnemyToList(Transform _enemyTransform) => targets.Add(_enemyTransform);
}
