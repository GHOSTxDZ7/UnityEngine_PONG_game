using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Resume : MonoBehaviour
{
    bool pause = false;
    public void PauseResume()
    {
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
        else
        {
            Time.timeScale = 0;
            pause = true;
        }
    }
}

/*When timeScale is 1.0, time passes as fast as real time. When timeScale is 0.5 time passes 2x slower than realtime.
When timeScale is set to zero your application acts as if paused if all your functions are frame rate independent. 
Negative values are ignored.*/   
