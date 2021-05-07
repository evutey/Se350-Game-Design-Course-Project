using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    // Start is called before the first frame update
    private int luckyNumber;
    Dictionary<int, string> drop = new Dictionary<int, string>();
    void Start()
    {
        drop.Add(1,"bash");
        drop.Add(2,"bash");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            luckyNumber = Random.Range(0, 100);
        }

        if (luckyNumber <= 25)
        {
            
        }
        if (luckyNumber <= 45 && luckyNumber > 25)
        {
            
        }
        if (luckyNumber <= 60 && luckyNumber > 45)
        {
            
        }
        if (luckyNumber <= 70 && luckyNumber > 60)
        {
            
        }
        if (luckyNumber <= 79 && luckyNumber > 70)
        {
            
        }
        if (luckyNumber <= 87 && luckyNumber > 79)
        {
            
        }
        if (luckyNumber <= 94 && luckyNumber > 87)
        {
            
        }
        if (luckyNumber <= 100 && luckyNumber > 94)
        {
            
        }
    }
}
