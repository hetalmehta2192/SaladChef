using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp:MonoBehaviour
{
  private PowerUpType m_powerType;
  private PlayerName m_pName;
  
  public SetPowerUp(PowerUpType powerType,PlayerName pName)
  {
      m_pName=pName;
      m_powerType=powerType;
  }
  
  	private void OnTriggerStay (Collider colObj)
	  {		
        if (colObj.CompareTag ("Player")) {
        AssignPowerUp(colObj.getComponent<PlayerController>());
			}
	  }
    
    private void AssignPowerUp(PlayerController playerObj)
    {
    if(playerObj.pName==m_pName){
    
          switch(m_powerType)
          {
          case PowerUpType.SpeedUp:
            playerObj.inputObj.moveSpeed+=1f;
            break;
            case PowerUpType.ScoreUp:
            playerObj.scoreObj.m_curScore+=10f;
            break;
            case PowerUpType.TimeUp:
            playerObj.timerObj.timer+=10f;
            break;
          }
      }
    }

public enum PowerUpType
{
SpeedUp,
ScoreUp,
TimeUp
}
