using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teaching : MonoBehaviour
{
    int[] temp = new int[] {1, 3, 5, 7, 9};

    int a = 1;
    float b = 0.1f;

    int[] array;
    List<int> list;

    enum Gamemode {
        creative,
        survival,
        adventure,
        hardcore,
        spectator
    }

    Gamemode NowGameMode = Gamemode.creative;

    public class Car {
        public int HP;
        public int Torque;
        public int topSpeed;
    }

    Car BMW = new Car { HP = 1000, Torque = 100, topSpeed = 300 };


    // Start is called before the first frame update
    void Start()
    {
        
        array = CreateArray<int>(1, 2);
        list = CreateList<int>(1, 2, 3);

        Debug.Log(list[0]);

        //Debug.Log(array[0] + array[1]);


        if (a > b){
            //Runs when a is bigger than b
            Debug.Log("A is bigger than B");

        } else if (a < b){
            //Runs when b is bigger than a
            Debug.Log("B is bigger than A");

        } else {
            //Runs when neither a is bigger than b and b is bigger than a (which means a is equal to b)
            Debug.Log("A is equal to B");

        }

        // switch (testEnum){
        //     case Number.One:
        //         Debug.Log("C is One");
        //         break;
        //     case Number.Two:
        //         Debug.Log("C is Two");
        //         break;
        //     case Number.Three:
        //         Debug.Log("C is Three");
        //         break;
        //     case Number.Four:
        //         Debug.Log("C is Four");
        //         break;
        //     default :
        //         break;
        // }

        // Debug.Log((int)testEnum);

        Debug.Log(BMW.HP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    T[] CreateArray<T>(T index1, T index2){
        return new T[] {index1, index2};
    }

    List<T> CreateList<T>(T index1, T index2, T index3){
        return new List<T> { index1, index2, index3 };
    }
}
