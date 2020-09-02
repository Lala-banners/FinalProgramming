using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    #region PROPERTIES

    public string TowerName //pascal casing (CapitalLetters)
    {
        get => towerName; //Properties
    }

    public string Description
    {
        get => description; //Properties
    }

    public int Cost
    {
        get => cost;
    }

    public string UiDisplayText //multiline format in Unity (tower name, cost, damage)
    {
        get
        {
            //{0}, {1}, {2} denotes values from variables
            //.ToString() is not necessary where they are now - put them within the formats
            //string.Format = Formats a string based on the first parameter, replacing any {x} with the relevant parameter
            string display = string.Format("Name: {0} Cost:{1}\n", TowerName, Cost.ToString()); //\n makes a new line, similar to Enter key
            display += Description + "\n";
            display += string.Format("Min Range: {0}, Max Range: {1}, Damage: {2}", minimumRange.ToString(), maximumRange.ToString(), damage.ToString());
            return display;
        }
    }

    private float MaximumRange
    {
        get
        {
            //Multiplying is faster than dividing
            return maximumRange * (level * 0.5f + 0.5f);
        }
    }

    private float Damage
    {
        get
        {
            return damage * (level * 0.5f + 0.5f);
        }
    }

    private float RequiredXP
    {
        get //can do any kind of logic, similar to function
        {
            if (level == 1)
            {
                return baseRequiredXp; //experience to get to level 1 regardless
            }

            return baseRequiredXp * (level * experienceScaler); //experienceScaler determines how much experince is required and multiplies it 
        }
    }
    #endregion

    #region VARIABLES
    [Header("General Stats")]
    [SerializeField] //Makes variables able to be modified in Inspector and saves changes made
    private string towerName = "";
    [SerializeField, TextArea] //TextArea turns string into box
    private string description = "";
    [SerializeField, Range(1, 10)]
    private int cost = 1;

    [Header("Attack Stats")] //Headers are displayed in Inspector as bold headings
    [SerializeField, Min(0.1f)]
    private float damage = 1;
    [SerializeField, Min(0.1f)]
    private float minimumRange = 1;
    [SerializeField]
    private float maximumRange = 5;
    [SerializeField, Min(0.1f)]
    private float fireRate = 0.1f;

    [Header("Experience Stats")]
    [SerializeField, Range(2,5)]
    private int maxLevel = 3;
    [SerializeField, Min(1)]
    private float baseRequiredXp = 5;
    [SerializeField]
    private float experienceScaler = 1; //multiplied(*) by scaler when player levels up

    private int level = 1;
    private int xp = 0;
    private Enemy target = null; //target the Tower is attacking
    
    #endregion

#if UNITY_EDITOR //Only be availble if Unity is open (Not necessary for OnValidate and OnGizmos but good practice)
    //OnValidate runs whenever a variable is changed within the Inspector of this class
    private void OnValidate() 
    {
        //Mathf = A collection of common math functions
        //Mathf.Clamp = Clamps the given value between the given minimum float and maximum float values. Returns the given value if it is within the min and max range
        maximumRange = Mathf.Clamp(maximumRange, minimumRange + 1, float.MaxValue); 
    }

    //OnDrawGizmosSelected draws helpful visuals only when the object is selected. Gizmos are visual debugs we can draw eg sphere, cube, lines, rays, meshes
    private void OnDrawGizmosSelected()
    {
        //Draw a mostly transparent red sphere indicating the minmum range
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, minimumRange);

        //Draw a mostly transparent blue sphere indicating the maximum range
        Gizmos.color = new Color(0, 0, 1, 0.25f);
        Gizmos.DrawSphere(transform.position, maximumRange);
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
