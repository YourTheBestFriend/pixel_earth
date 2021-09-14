using UnityEngine;
public class PlayerControler : MonoBehaviour
{
    public float speed = 80f;
    private Rigidbody2D rb;
<<<<<<< HEAD
    private bool FacingRight = true; // ��� �������� ��������� � �� ������� � ������� �� ����
    private float HorizontalMove = 0f;
    public Animator animator;

    //��������� ����������
    [Header("Player Movement Settings")] // ��� �������� � ����������� ����������� ���������� � unity 
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float jumpForce = 8f;
    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = true; // ��� �������� ������������� �� �������� � ���������
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.12f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;

=======
    // Start is called before the first frame update
>>>>>>> parent of e4f2f54 (update player script)
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);

<<<<<<< HEAD
        //�������� �������� ��� ��������� ��������
        animator.SetFloat("Speeed", Mathf.Abs(HorizontalMove));

        //������� ��� ������ ������� �������� ���������
        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
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
=======
        if (Input.GetKeyDown(KeyCode.Space))
>>>>>>> parent of e4f2f54 (update player script)
        {
            rb.AddForce(Vector2.up * 8000);
        }
    }
}
