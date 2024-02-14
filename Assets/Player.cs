using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float xInput;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start was called.");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            xInput = Input.GetAxisRaw("Horizontal");
            Debug.Log("Jump");
        }
    }
}
