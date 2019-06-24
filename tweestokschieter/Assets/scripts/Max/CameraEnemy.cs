using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnemy : EnemySight1
{

    public Animator cameraAnim;

    private void Update()
    {
        
    }

    public void PlayerInCameraSight()
    {
        if(isInFov == true)
        {
            cameraAnim.StopPlayback();
        }
    }

}
