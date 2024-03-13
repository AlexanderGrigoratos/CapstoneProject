using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Skill : Skill
{
    [SerializeField] private GameObject clonePrefab;

    public void CreateClone(Transform _clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefab);

        newClone.GetComponent<Clone_Skill_Controller>().SetupClone(_clonePosition);
    }
}
