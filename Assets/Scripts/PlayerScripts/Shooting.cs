using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [Header("GameObjects")]
    public Transform staff;
    public Transform staffShootPoint;
    public Projectile projectile;

    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        staff.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
    }

    public void HandleShootingInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && time > projectile.fireRate)
        {
            Instantiate(projectile, staffShootPoint.transform.position, staff.rotation);
            time = 0;
        }
    }

}
