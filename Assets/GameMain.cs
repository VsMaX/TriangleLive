using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {
	
	private GameObject sellection ;
	
	
	
	
	private bool isOkToTouch;
	private bool isDraging;
	
	
	void Update()
	{
		if(Input.touchCount == 1 )
		{
			
			Touch touch = Input.GetTouch(0);
			
			switch (touch.phase)
			{
			case TouchPhase.Began:
				sellection = CheckObject(Input.touches[0].position);
				
				
				break;
			case TouchPhase.Moved:
				
				sellection.transform.position = touchPos();
				
				break;
				
			case TouchPhase.Canceled:
				
				
				break;
			}
			
			
			
			
		}
	}
	

	
	private GameObject CheckObject (Vector2 pos)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(pos);
		
		if ( Physics.Raycast(ray , out hit))
		{
			return hit.collider.gameObject;
		}
		
		return null;
	}
	
	
	private Vector3 touchPos()
	{
		return Camera.main.ScreenToWorldPoint( new Vector3( Input.touches[0].position.x ,  Input.touches[0].position.y , 20.0f));
	}
	

	
}
