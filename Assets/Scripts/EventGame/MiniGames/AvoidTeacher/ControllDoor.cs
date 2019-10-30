using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllDoor : MonoBehaviour
{
    public bool open = false;
    private float doorOpenAngle;
    private float doorCloseAngle;
    private float smoot = 2f;
    private float smoot1 = 1.5f;
    public bool rock = false;

    public void ChangeDoor()
    {
        open = !open;
    }

    void Start()
    {
        if(transform.tag == "odd")
        {
            doorOpenAngle = -118.017f;
            doorCloseAngle = -198.017f;
        } else if(transform.tag == "even")
        {
            doorOpenAngle = 60.43f;
            doorCloseAngle = -20.43f;
        }
    }

    void Update()
    {
        if (rock == false)
        {
            if (open)
            {
                Quaternion targetRotation = Quaternion.Euler(80.012f, doorCloseAngle, 54.88f);
                transform.localRotation = Quaternion.Slerp(this.transform.localRotation, targetRotation, smoot * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation2 = Quaternion.Euler(80.012f, doorOpenAngle, 54.88f);
                transform.localRotation = Quaternion.Slerp(this.transform.localRotation, targetRotation2, smoot1 * Time.deltaTime);//서서히 문이 돌아감
            }
        }
    }
}
