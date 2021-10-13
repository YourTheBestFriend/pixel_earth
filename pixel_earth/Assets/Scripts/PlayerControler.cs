using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
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

        /// Animations
        if (HorizontalMove != 0) // != ������ �� ����� // Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) - ��������� �� �����
        {
            anim.SetBool("is_stay", false);
        }
        else
        {
            anim.SetBool("is_stay", true);
        }
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
}