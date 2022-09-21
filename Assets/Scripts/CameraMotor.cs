using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookat;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // Update is called once per frame
    private void LateUpdate()
    {
        // This is to check if we are inside the bounds on the X axis
        Vector3 delta = Vector3.zero;
        float deltaX = lookat.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookat.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // This is to check if we are inside the bounds on the Y axis
        
        float deltaY = lookat.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookat.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
