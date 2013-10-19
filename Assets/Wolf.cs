using UnityEngine;
using System.Collections;

public class Wolf  {

		private GameObject wolf;
		private tk2dSprite wolfSprite;
	
	public Wolf(GameObject obj, int xPos , int yPos)
	{
		GameObject _wolf = Object.Instantiate(obj, new Vector3(xPos, yPos, 0.0f), Quaternion.identity) as GameObject;
		wolf = _wolf;
	}
	
	public void AnimateWolf()
	{
		wolfSprite = wolf.GetComponent<tk2dSprite>();
		///Make Animation //
		
	}
	
	
	
}
