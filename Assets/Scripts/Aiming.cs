using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Transform staff;
    public CameraController camController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion quaternion = Quaternion.Euler(camController.mousePos.x, camController.mousePos.y, 0);
        //Debug.Log(quaternion);
        //staff.transform.rotation = quaternion;
        //Debug.Log(staff.transform.rotation);

        Vector2 staffPosition = staff.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - staffPosition;
        staff.transform.right = direction;
    }
}
