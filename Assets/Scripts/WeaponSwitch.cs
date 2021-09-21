using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject cinor;
    public GameObject dubina;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (cinor.activeInHierarchy == true)
            {
                cinor.SetActive(false);
                dubina.SetActive(true);
            }
            else
            {
                cinor.SetActive(true);
                dubina.SetActive(false);
            }
        }
        
    }
}
