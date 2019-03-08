using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class SingletonB
{
    public static readonly SingletonB _instance = new SingletonB();

    public void Test()
    {
        // Code runs.
        Debug.Log("Test");
    }

    SingletonB()
    {
    }
}
