using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 
       Player Controller with that moves and turns faster as it gains XP;
	    Manages moving and rotating the player via the arrow keys.
		Up/down arrow keys to move forward and backward.
		Left/right arrow keys to rotate left and right.
*/

public class PlayerControllerThatLevelsUp : MonoBehaviour
{

    //The base move and turn speed
	public float moveSpeed = 1f;
	public float turnSpeed = 45f;
    public float jumpHeight = 5f;
    
    //The move and turn speed with the buffs you have from leveling up.   
    public float currentMoveSpeed;
    public float currentTurnSpeed;



    public float xp = 0;	// Amount of XP the player has
    public float xpForNextLevel = 10;   //Xp needed to level up, the higher the level, the harder it gets. 
    public int level = 0;   // Level of the player
  




    private void Start()
    {
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
    }
 
    

    // To level up you need to collect an amount of xp;
    // This starts at 10 xp
    // Each level you gain the xp required gets higher exponentially
    // The exponential growth is slowed by scaling it by 10%

    void SetXpForNextLevel()
    {
        xpForNextLevel = (10f + (level * level * 0.1f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }



    // For each level, the player adds 10% to the move speed 
    void SetCurrentMoveSpeed()
    {
        currentMoveSpeed = this.moveSpeed + (this.moveSpeed * 0.1f * level);
        Debug.Log("currentMoveSpeed = " + currentMoveSpeed);
    }

    // For each level, the player adds 10% to the turn speed 
    void SetCurrentTurnSpeed()
    {
        currentTurnSpeed = this.turnSpeed + (this.turnSpeed * (level * 0.1f));
        Debug.Log("currentTurnSpeed = " + currentTurnSpeed);
    }


    void LevelUp()
    {
        xp = 0f;
        level++;
        Debug.Log("level" + level);
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
       
    }

    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
    }
    

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.X) == true) { GainXP(1); }

       
        
        if (xp >= xpForNextLevel)
        {
            LevelUp();
        }

        if (Input.GetKey(KeyCode.W) == true) { this.transform.position += this.transform.forward * currentMoveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S) == true) { this.transform.position -= this.transform.forward * currentMoveSpeed * Time.deltaTime; }

        if ( Input.GetKey( KeyCode.D ) == true ){ this.transform.RotateAround( this.transform.position, Vector3.up, currentTurnSpeed  * Time.deltaTime) ; }
		if ( Input.GetKey( KeyCode.A ) == true ){ this.transform.RotateAround( this.transform.position, Vector3.up, -currentTurnSpeed * Time.deltaTime); }

        if (Input.GetKey(KeyCode.Space) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight;
        }

    }
}
