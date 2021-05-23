using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TekcanBazaar : MonoBehaviour
{
    public GameObject bazaar;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sila Detected.");
            if (Input.GetKey(KeyCode.T))
            {
                Debug.Log("T is pressed!");
                Debug.Log("Bazaar is opened!");
                bazaar.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bazaar.SetActive(false);
        }
    }
}
