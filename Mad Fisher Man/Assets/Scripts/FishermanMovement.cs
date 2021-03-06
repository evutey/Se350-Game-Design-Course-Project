using UnityEngine;

public class FishermanMovement : MonoBehaviour
{
    private float Speed = 0.5f;
    public Animator _animator;
    private bool facingRight = true;
    public GameObject boat;
    private bool isMoving;
    void Start()
    {
        boat = GameObject.Find("Boat");
        isMoving = true;

    }
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * (Speed * Time.deltaTime);
        _animator.SetFloat("speed",Mathf.Abs(movement));
     
        if (movement < 0 && facingRight) { flip();
        }
        if (movement > 0 && !facingRight) {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (isMoving)
                {
                    isMoving = false;
                    Speed = 1f;
                    _animator.SetBool("isMoving",false);
                }
               
                else
                {
                    isMoving = true;
                    Speed = 0.5f;
                    _animator.SetBool("isMoving",true);
                }
                Debug.Log("E is Pressed!");
                boat.GetComponent<BoatControl>().changeControl();
            }
        }
    }
}
