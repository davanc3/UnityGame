using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public bool full = true;

    public void fullScreen()
    {
        full = !full;
        Screen.fullScreen = full;
    }
}
