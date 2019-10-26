using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Чтобы использовать UI элементы
using UnityEngine.SceneManagement; //Чтобы загружать сцену(Рестарт)

public class Fly : MonoBehaviour
{
    [SerializeField] //Делает переменную ниже видимой в Inspector, только именно одну переменную
    private float _jumpForce; //Переменная для силы прыжка

    Rigidbody2D _rb2D; //Перменная для хранения физики птицы
    Animator _animator; //Переменная для хранения анимации птицы
    bool _IsJump; //Переменная для проверки нажатия SPACE
    
    public Text _scoreText;
    int _score = 0;

    void Awake()//Работает на загрузке Unity при нажатии кнопки PLAY
    {
        _rb2D = GetComponent<Rigidbody2D>(); //Передаем физику в переменную
        _animator = GetComponent<Animator>(); //Передаем анимацию в переменную
    }

    // Update работает каждый кадр
    void Update()
    {
        if (Input.GetButtonDown("Jump")) //Если пользователь нажмет пробел, то
        {
            _IsJump = true; //И переменная подтверждает это, что пробел нажат
            _animator.SetBool("IsFlying", _IsJump); //Переключаемся на анимацию полета
        } else if (Input.GetButtonUp("Jump")) //И если SPACE отпущена
        {
            _animator.SetBool("IsFlying", false); //Снова возвращаемся к анимации Idle
        }
        
        _scoreText.text = "Score: " + _score.ToString() //Отображаем в Text счет
    }

    void FixedUpdate() //Работает только тогда, когда кадр отрисовался
    {
        if (_IsJump) //И если _IsJump = true, то
        {
            //Добавляем силу по Y * на скорость, которую мы зададим в Inspector * на время, когда отрисовался кадр, Игнорим массу
            _rb2D.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            _IsJump = false; //И чтобы _IsJump не была бесконечна true, делаем ее false
        }
    }
    
        //Эта функция работает при соприкосновении двух Collider
    void OnCollisionEnter2D(Collision2D col)
    {
        //И при соприкосновении с землей или колонной, включается анимация смерти
        _animator.SetTrigger("Death");
    }
    
    void OnTriggerEnter2D(Collider2D col) 
    {
        //Если в зону птицы зашел Collider и у него есть тэг "Ground" или "Column", то
        if (col.tag == "Ground" || col.tag == "Column")
            SceneManager.LoadScene(0); //Загрузка первой сцены(Рестарт)
        if (col.tag == "Score")// Если "Score", то
            _score++;
    }
}
