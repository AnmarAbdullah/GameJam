using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxApplication : MonoBehaviour
{
    public void MaximizeApplication()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("changed screen mode");
    }
}
