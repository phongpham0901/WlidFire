using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact
}

public enum PlayerFace
{
    Up,
    Down,
    Left,
    Right
}

public class PlayerMovement : MonoBehaviour
{
    // set up a public variable for the PlayerFace
    public PlayerFace currentFace;

    // set up references to the hitboxes and attach them in the GUI
    public GameObject HitBoxDown;
    public GameObject HitBoxUp;
    public GameObject HitBoxLeft;
    public GameObject HitBoxRight;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    [SerializeField] float moveSpeed = 5f;
    public PlayerState currentState;
    Rigidbody2D rb;
    Animator animator;
    Vector2 movement = Vector2.zero;
    void Start()
    {
        currentFace = PlayerFace.Down;
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        CheckPosition();
        //Input
        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        movement.y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.fixedDeltaTime;
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(AttackCO());
        }
        else if(currentState == PlayerState.walk)
        {
            MoveChange();
        }
    }

    private void MoveChange()
    {
        if (movement != Vector2.zero)
        {
            UpdateFace();
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void UpdateFace()
    {
        if (movement.x > 0)
        {
            currentFace = PlayerFace.Right;
        }
        else if (movement.x < 0)
        {
            currentFace = PlayerFace.Left;
        }
        if (movement.y > 0)
        {
            currentFace = PlayerFace.Up;
        }
        else if (movement.y < 0)
        {
            currentFace = PlayerFace.Down;
        }
    }

    IEnumerator AttackCO()
    {
        switch (currentFace)
        {
            case PlayerFace.Down:
                HitBoxDown.SetActive(true);
                AudioGame.instance.PlayShootingClip();
                break;
            case PlayerFace.Up:
                HitBoxUp.SetActive(true);
                AudioGame.instance.PlayShootingClip();
                break;
            case PlayerFace.Left:
                HitBoxLeft.SetActive(true);
                AudioGame.instance.PlayShootingClip();
                break;
            case PlayerFace.Right:
                HitBoxRight.SetActive(true);
                AudioGame.instance.PlayShootingClip();
                break;
        }
        animator.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.1f);
        currentState = PlayerState.walk;

        HitBoxDown.SetActive(false);
        HitBoxUp.SetActive(false);
        HitBoxLeft.SetActive(false);
        HitBoxRight.SetActive(false);

    }

    private void FixedUpdate()
    {
        //movement
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(movement.x, movement.y);
    }

    void CheckPosition()
    {
        if(transform.position.x < -0.95f)
        {
            transform.position = new Vector2(-0.95f, transform.position.y);
        }
        else if (transform.position.x > 1.94f)
        {
            transform.position = new Vector2(1.94f, transform.position.y);
        }
        else if (transform.position.y < -1.21f)
        {
            transform.position = new Vector2(transform.position.x, -1.21f);
        }
        else if (transform.position.y > 0.73f)
        {
            transform.position = new Vector2(transform.position.x, 0.73f);
        }
    }

}
