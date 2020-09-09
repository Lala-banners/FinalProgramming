using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // singleton - only instance of happening once
    /// <summary>
    /// The reference to the only player gameObject in the game.
    /// </summary>
    public static Player instance = null;

    [SerializeField, Tooltip("This sets the inital amount of money the player has.")]
    private int money = 100;

    /// <summary>
    /// Gives the player the passed amount of money
    /// </summary>
    public void AddMoney(int _money)
    {
        money += _money;
    }

    /// <summary>
    /// Handles the removal of money when purchasing a tower and
    /// notifies the TowerManager to place the tower
    /// </summary>
    /// <param name="_tower">The tower being purchased.</param>
    public void PurchaseTower(Tower _tower)
    {
        money -= _tower.Cost;
    }

    void Awake()
    {
        //if instance doesn't already exist, make it me
        if (instance = null)
        {
            instance = this;
        }
        // is instance already set? and not me?
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //this should only happen to the instance
        //takes gameObject to separate scene to keep it
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
