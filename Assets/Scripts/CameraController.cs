using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 93.8f;
    public float scrollSpeed = 6.54f;
    public float minX = 0f;
    public float maxX = 100f;
    public float minY = 20;
    public float maxY = 80;
    public float minZ = -70f;
    public float maxZ = -10f;
    public float panBorderThickness = 10f;

    void Update()
    {
        if (GameManager.GameOver) { this.enabled = false; return; }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
            return;
        //mouseposition 
        if (Input.GetKey("w")
        //|| Input.mousePosition.y >= Screen.height - panBorderThickness
        )
        {
            //Vector3.forward is the same as writing new Vector3 (0,0,1)
            //we want to add a pan speed so
            //time.deltaTime = amount of time that passed since last frame drawn
            //space.world ignore the rotation of the camera
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a")
        //|| Input.mousePosition.x <= panBorderThickness
        )
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s")
        //|| Input.mousePosition.y <= panBorderThickness
        )
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d")
        //|| Input.mousePosition.x >= Screen.width - panBorderThickness
        )
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;
    }
}
