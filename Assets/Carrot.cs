using UnityEngine;
using System.Collections;

public class Carrot {
	
	
	private GameObject carrot;
	private tk2dSprite carrotSprite;
	
	public Carrot(GameObject obj , int xPos, int yPos)
	{
		GameObject _carrot  = Object.Instantiate(obj, new Vector3(xPos, yPos, 0.0f), Quaternion.identity) as GameObject;
		carrot = _carrot;
				
	}
	
	
	
	
	public void AnimateCarrot()
	{
		carrotSprite = carrot.GetComponent<tk2dSprite>();
		/// Make Animation hiere///
	}
	
	
	
	
	
	

}
