using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class PlayerControler : MonoBehaviour
{
    // for ganerate random smoking
    private int rand_player_smoking = 1; // != 0 - значит smoking
 

    // for animation
    private Animator anim;

    // Приватные переменные
    private Rigidbody2D rb;
    private bool FacingRight = true; // Для поворота персонажа в ту сторону в которую он идет
    private float HorizontalMove = 0f;

    // Публичные переменные которые отображаются в самой unity
    [Header("Player Movement Settings")] // Для названия и дальнейшего отображения перемынных в unity 
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 100f)] public float jumpForce = 8f;
    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = true; // Для проверки соприкасается ли персонаж с объектами
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.12f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;

    void Start()
    {
        //Присваиваем переменной rb компонент Rigidbody2D который висит на персонаже
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        /// Animations
        if (HorizontalMove != 0 || !isGrounded) // != значит не стоит // Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) - стрелочки на клаве
        {
            // anim.SetBool("is_stay", false);
            anim.SetBool("is_stay", false);
        }
        else
        {
            if ((rand_player_smoking == 0) && isGrounded) // Значит он стоит (Для рандома анимации smoking) 
            {
                anim.SetBool("is_stay_for_smoking", true);
            }
            else
            {
                // Зануление можно так сказать 
                anim.SetBool("is_stay_for_smoking", false);
            }
            anim.SetBool("is_stay", true);
        }
        


        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //Импульс вверх умножая на силу прыжка
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        //Переменная со значением горизонтали (лево = -1; на месте = 0 ; право = 1;)
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        //Условие для вызова функции поворота персонажа
        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }

        // smoking or don't smoking
        rand_player_smoking = Random.Range(0, 5); // чем больше значение тем меньше шанс что попадется 0
    }
    private void FixedUpdate()
    {
        //Настраиваем скорость движения по горизонтали а по вертикали оставляем также
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        CheckGround();
    }

    //Функция переворота спрайта персонажа
    private void Flip()
    {
        //Переключение переменной при повороте
        FacingRight = !FacingRight;

        //Изменение Scale при повороте. Текущий Scale умножаем на -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Функция для проверки - стоит ли персонаж на поверхности
    private void CheckGround()
    {
        //Создаём массив из коллайдеров = создаём окружность которая будет проверять столкновение с другими коллайдерами. 
        //(новый Вектор2 (X = Позиция игрока по X, Y = Позиция игрока по Y + Отступ от центра спрайта игрока по вертикали), радиус окружности)
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        //Если в массиве colliders более одного коллайдера, то игрок на земле
        //Более одного потому-что 1 коллайдер висит на игроке и тоже попадает в зону видимости окружности! 
        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    // Функция для контроля переменной которая контралирует анимацию пакоя // Я ПОКА ЭТО НИКДЕ НЕ ИСПОЛЬЗУЮ
    private void Set_Stay_animation_fasle()
    { 
       anim.SetBool("is_stay", false);
    }
}