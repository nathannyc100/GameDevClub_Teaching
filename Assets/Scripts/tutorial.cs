using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class tutorial : MonoBehaviour
{

    public int a = 3;                           //Integer, numbers with no decimal
    float b = 0.1f;                     //Float, numbers with decimal, remember to add f  
    double c = 1.1;                     //Double, bigger numbers with decimal
    bool d = false;                     //Bool, true or false
    string e = "sdlfkjsdlkjf";          //String, a string of characters, use ""
    Vector3 f = new Vector3(1, 2, 3);   //Vector3, saves a vector, or coordinates, being x, y, and z
    GameObject g;                       //GameObject, saves a GameObject

    Enum testEnum;

    public int test = 3;
  
    public static int statInt = 0;

    [SerializeField]
    private Tutorial2 tutorial2;

    private int privInt;
    public int pubInt;

    public event EventHandler OnSpacePressed;
    
    public event EventHandler<OnUpPressedEventArgs> OnUpPressed;

    public class OnUpPressedEventArgs : EventArgs {
        public int number;
    }

    
    
    NewClass newClass;

    int[] array = new int[] {1, 2, 3};

    List<int> list = new List<int>() {1, 2, 3};
    
    enum Enum {
        One,        //0
        Two,        //1
        Three,      //2
        Four = 4,   //4

    }

    class NewClass {
        public int one;
        public int two;
    };

    

    
    // Start is called before the first frame update
    void Start(){
        NewClass newClass = new NewClass{ one = 1, two = 2};

        tutorial.statInt = 1;

        tutorial2 = FindObjectOfType<Tutorial2>();

        tutorial2 = GetComponent<Tutorial2>();

        int a, b;
        int i;

        a = 1;
        b = 2;

        testEnum = Enum.One;

        int S = 1;
        func();
        //J ++;

        void func(){
            int J = 0;
            S += 1;
        }

        newClass.one = 2;

        // Debug.Log("newClass.one is " + newClass.one);
        // Debug.Log("array[1] is " + array[1]);
        // Debug.Log("list[1] is" + list[1]);

        //LoopTesting();
        ConditionTesting();

    }

    // Update is called once per frame
    void Update(){

        // sldkfjldskfjklsdjf
        
        /*  sdlkfjsdlkfjksd
            sdlkfjsdlkfjsdf
            dsfkljsdklf
        */

        

        
        
        
        if (Input.GetKeyDown(KeyCode.Space)){
            //if (OnSpacePressed != null) OnSpacePressed(this, EventArgs.Empty);

            OnSpacePressed?.Invoke(this, EventArgs.Empty);

            
        }

        if (Input.GetKeyDown(KeyCode.A)){
            OnUpPressed?.Invoke(this, new OnUpPressedEventArgs { number = 1 });
        }

    }

    int ReturnMax(int a, int b){
        if (a > b){
            return a;
        } else {
            return b;
        }
    }

    public T[] CreateArray<T>(T index1, T index2){
        return new T[] {index1, index2};
    }

    int[] CreateArrayInt(int index1, int index2){
        return new int[] {index1, index2};
    }

    void LoopTesting(){
        int i;
        for (i = 0; i < 100; i ++){
            //Sets a integer i to 0, run it till i < 100 is false, and increment i every loop
            //
            Debug.Log("For I is " + i);
        }

        foreach (int j in array){
            //Runs every thing in a array or list once
            Debug.Log("array: " + j);
        }

        while (i < 200){
            //Runs loop till i < 200 is false
            //"While" i < 200 is true
            Debug.Log("While I is " + i);
            
            i ++;
            //Remember to change i, or else the loop will run forever
        }

        do {
            Debug.Log("Do while I is " + i);

            i ++;
            //Same as while loop, but runs code before checking
        } while (i < 300);
    }

    void ConditionTesting(){


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

        switch (a){
            case 1:
                //Run when a is 1
                Debug.Log("A is 1");
                break;
            case 2:
                //Run when a is 2
                Debug.Log("A is 2");
                break;
            default:
                //Run when reached 
                Debug.Log("A is neither 1 nor 2");
                break;
        }

        switch (testEnum){
            case Enum.One:
                Debug.Log("C is One");
                break;
            case Enum.Two:
                Debug.Log("C is Two");
                break;
            case Enum.Three:
                Debug.Log("C is Three");
                break;
            case Enum.Four:
                Debug.Log("C is Four");
                break;
            default :
                break;
        }

        Debug.Log((int)testEnum);
    }



}
