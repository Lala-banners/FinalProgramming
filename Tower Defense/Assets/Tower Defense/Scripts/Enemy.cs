using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /**
     * speed
     * health
     * damage
     * XP given
     * size
     * money given
     * resistance (to certain type of damage) NEXT LESSON
     */

    [Header("General Stats")]
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float health = 1;
    [SerializeField]
    private float damage = 1;
    [SerializeField]
    private float size = 1;
    //RESISTANCE HERE

    [Header("Rewards")]
    [SerializeField]
    private float xp = 1;
    [SerializeField]
    private float money = 1;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
