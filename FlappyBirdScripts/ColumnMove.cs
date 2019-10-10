using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMove : MonoBehaviour
{
    [SerializeField]//Делает переменную ниже видимой в Inspector, только именно одну переменную
    private float _speed;//Переменная для добавки скорости к колоннам

    // Update работает каждый кадр
    void Update()
    {
        //Передвигаем колонны(Влево * скорость * на время отрисованного одного кадра
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    void OnEnable() //При появлении объекта в игре т.е., когда он заспавнится, то
    {
        Destroy(gameObject, 8f);//Удалить объект через 8 секунд
    }
}
