using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject _columns; //Наши колонны будут храниться в этой переменной
    [SerializeField] //Делает переменную ниже видимой в Inspector, только именно одну переменную
    private float _timer; //Наш таймер, который будет спавнить колоны по-времени
    float _time; //И наш перезагрузчик нашего таймера

    // Start работает один кадр и все
    void Start()
    {
        _time = _timer; //При запуске игры, наш перезагрузчик навсегда будет равняться тому, чему равен таймер
    }

    // Update работает при каждом кадре
    void Update()
    {
        _timer -= Time.deltaTime; //Чтобы таймер не стоял на месте убавляем его

        if (_timer < 0) //И если таймер меньше 0, то
        {
            //Заспавнить(КОЛОННЫ, по X оставить как есть, а по Y случайно от -2 до 4, и не крутить объект)
            Instantiate(_columns, new Vector2(transform.position.x, Random.Range(-2f, 4f)), Quaternion.identity);
            _timer = _time; //Перезагружаем таймер на изначальное значение
        }
    }

}
