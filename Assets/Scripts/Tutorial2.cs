using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tutorial2 : MonoBehaviour
{
    public tutorial tutorial;

    private int[] tutorial2List;

    // Start is called before the first frame update
    void Start(){
        tutorial = GetComponent<tutorial>();
        tutorial2List = tutorial.CreateArray<int>(3, 4);
        Debug.Log("Create Array from tutoria 1 is " + tutorial2List[0]);

        tutorial.OnSpacePressed += When_OnSpacePressed;
        tutorial.OnUpPressed += When_OnSpacePressed;
    }

    void When_OnSpacePressed(object sender, EventArgs e){
        Debug.Log("Space pressed");
    }

    void When_OnUpPressed(object sender, tutorial.OnUpPressedEventArgs e){
        Debug.Log("Up number is " + e.number);
    }

}
