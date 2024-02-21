using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [Header("Transform Reference")]
    private Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = this.transform;    
    }

    // Update is called once per frame
    void Update()
    {
        WatchMouse();
    }

    /// <summary>
    /// WatchMouse keeps the player character's weapon aimed at the mouse cursor
    /// </summary>
    void WatchMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - thisTransform.position;
        //find the angle the transform needs to rotate
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        thisTransform.rotation = rotation;
    }
}
