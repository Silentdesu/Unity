using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will not allow you to delete this component
//Этот скрипт вам не позволит удалить этот компонент
[RequireComponent(typeof(Rigidbody2D))]
public class MovementWithAnimation : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;

    [SerializeField] float movementSpeed = 10;
    [SerializeField] float jumpForceSpeed = 20;

    float moveX = 0;
    bool isJump = false;

    //Variables for checking is player on ground
    //Переменные для проверки стоит ли игрок на земле
    [SerializeField] Transform groundPosition;
    [SerializeField] float circleRadius = 0.3f;
    [SerializeField] LayerMask groundLayerMask;

    private void Awake()
    {
        //First statement will check if Rigidbody2D is existing
        //Первое условие будет проверять, есть ли Rigidbody2D
        if (GetComponent<Rigidbody2D>() == null)
            rb2D = gameObject.AddComponent<Rigidbody2D>();

        //If it's already existed, then variables will asign the RB2D
        //Если уже существует, то переменная RB2D присвоит ее
        else
            rb2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        //Variable "Speed" I called it inside of animator
        //Your variable may have other name

        //Переменная "Speed", я ее так назвал в аниматоре
        //Ваша переменная может называться совсем по-другому

        //Mathf.Abs() это функция модуля в математике
        //делает вашу переменную moveX всегда позитивной
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (Input.GetKeyDown(KeyCode.Space) && isGround() == true)
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        //Functions that will do
        //movement of our player
        //will flip sprite of our player
        //jump of our player

        //------------------------------//

        //Функция, которые отвечают за
        //Передвижение нашего персонажа
        //Поворот нашего спрайта, при повороте персонажа
        //Прыжок нашего игрока
        Move();
        FlipSprite();
        Jump();
    }

    void Move()
    {
        rb2D.velocity = new Vector2(moveX * movementSpeed, rb2D.velocity.y);
    }

    void Jump()
    {
        if (isJump == true)
        {
            rb2D.AddForce(Vector2.up * jumpForceSpeed, ForceMode2D.Impulse);
            isJump = false;
        }
    }

    void FlipSprite()
    {
        if (moveX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        else if (moveX < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    bool isGround()
    {
        return Physics2D.OverlapCircle(groundPosition.position, circleRadius, groundLayerMask);
    }
}
