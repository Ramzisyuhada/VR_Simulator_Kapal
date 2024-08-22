using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Button " + i + " was pressed!");
            }
        }
        float hatHorizontal = Input.GetAxis("Axis5"); 
        float hatVertical = Input.GetAxis("Axis6");
        Debug.Log(hatHorizontal);
        
    }
}
