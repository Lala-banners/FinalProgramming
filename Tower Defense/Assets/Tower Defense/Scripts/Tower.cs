using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //public is anyone can see it
    //variables no capitals
    //properties is capitals
    //[] is attribute 

    public string towerName = "Bob";
    [Multiline] //creates big box to write description 
    public string description = "Some Description";

    [Space] //puts space

    [Header("Properties")] //only applies to next variable

    [SerializeField] //only serialises next attribute
    [Range(-3, 3)]
    [Tooltip("This variable controls how fast the object moves up and down.")] //This can be used for reminders of what variables do.
    private float speed;
    [Min(0)] //prevents number going past 0
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Transform = class, transform = component
        transform.position += transform.up * Time.deltaTime * speed * Input.GetAxis("Vertical"); //deltaTime converts to 1m/s
    }

    private void OnDrawGizmos() //Create own cube Gizmo and change properties for funzies
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.up, Vector3.one);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + transform.right, Vector3.one);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position + transform.up, transform.position + transform.right); 
    }
}
