using UnityEngine;

public class BoatControl : MonoBehaviour
{
    private float boatSpeed = 1f;
    public bool isControl;

    public GameObject fisherman;
    void Start()
    {
        isControl = false;
        fisherman = GameObject.Find("Fisherman");
    }
    void Update()
    {
        if (isControl)
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement,0,0) * (boatSpeed * Time.deltaTime);
        }
    }
    public void changeControl()
    {
        if (isControl == false)
        {
            isControl = true;
            fisherman.GetComponent<Animator>().Play("Idle");
        }
        else
        {
            isControl = false;
            fisherman.GetComponent<Animator>().Play("Idle");
        }
    }
}
