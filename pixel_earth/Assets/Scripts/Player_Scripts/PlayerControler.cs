using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class PlayerControler : MonoBehaviour
{
    // for ganerate random smoking
    private int rand_player_smoking = 1; // != 0 - ������ smoking
 

    // for animation
    private Animator anim;

    // ��������� ����������
    private Rigidbody2D rb;
    private bool FacingRight = true; // ��� �������� ��������� � �� ������� � ������� �� ����
    private float HorizontalMove = 0f;

    // ��������� ���������� ������� ������������ � ����� unity
    [Header("Player Movement Settings")] // ��� �������� � ����������� ����������� ���������� � unity 
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 100f)] public float jumpForce = 8f;
    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = true; // ��� �������� ������������� �� �������� � ���������
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.12f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;

    void Start()
    {
        //����������� ���������� rb ��������� Rigidbody2D ������� ����� �� ���������
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        /// Animations
        if (HorizontalMove != 0 || !isGrounded) // != ������ �� ����� // Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) - ��������� �� �����
        {
            // anim.SetBool("is_stay", false);
            anim.SetBool("is_stay", false);
        }
        else
        {
            if ((rand_player_smoking == 0) && isGrounded) // ������ �� ����� (��� ������� �������� smoking) 
            {
                anim.SetBool("is_stay_for_smoking", true);
            }
            else
            {
                // ��������� ����� ��� ������� 
                anim.SetBool("is_stay_for_smoking", false);
            }
            anim.SetBool("is_stay", true);
        }
        


        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //������� ����� ������� �� ���� ������
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        //���������� �� ��������� ����������� (���� = -1; �� ����� = 0 ; ����� = 1;)
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        //������� ��� ������ ������� �������� ���������
        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }

        // smoking or don't smoking
        rand_player_smoking = Random.Range(0, 5); // ��� ������ �������� ��� ������ ���� ��� ��������� 0
    }
    private void FixedUpdate()
    {
        //����������� �������� �������� �� ����������� � �� ��������� ��������� �����
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        CheckGround();
    }

    //������� ���������� ������� ���������
    private void Flip()
    {
        //������������ ���������� ��� ��������
        FacingRight = !FacingRight;

        //��������� Scale ��� ��������. ������� Scale �������� �� -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //������� ��� �������� - ����� �� �������� �� �����������
    private void CheckGround()
    {
        //������ ������ �� ����������� = ������ ���������� ������� ����� ��������� ������������ � ������� ������������. 
        //(����� ������2 (X = ������� ������ �� X, Y = ������� ������ �� Y + ������ �� ������ ������� ������ �� ���������), ������ ����������)
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        //���� � ������� colliders ����� ������ ����������, �� ����� �� �����
        //����� ������ ������-��� 1 ��������� ����� �� ������ � ���� �������� � ���� ��������� ����������! 
        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    // ������� ��� �������� ���������� ������� ������������ �������� ����� // � ���� ��� ����� �� ���������
    private void Set_Stay_animation_fasle()
    { 
       anim.SetBool("is_stay", false);
    }
}