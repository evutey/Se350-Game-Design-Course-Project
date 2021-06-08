using UnityEngine;

public class PalaShop : MonoBehaviour
{
    public GameObject bazaar;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pala Detected.");
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
