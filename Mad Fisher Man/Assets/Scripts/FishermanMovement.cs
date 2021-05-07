using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishermanMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float Speed = 0.5f;
    public Animator _animator;
    private bool facingRight = true;
    void Start()
    {
        gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * (Speed * Time.deltaTime);
        _animator.SetFloat("speed",Mathf.Abs(movement));
        _animator.Play("Fishing");
        if (movement < 0 && facingRight)
        {
            flip();
        }
        if (movement > 0 && !facingRight)
        {
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
}
