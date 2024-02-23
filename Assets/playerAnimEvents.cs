using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimEvents : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GetComponentInParent<Player>();    
        
    }

    private void AnimationTrigger()
    {
        player.AttackOver();
    }
}
