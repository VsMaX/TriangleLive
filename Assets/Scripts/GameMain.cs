using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameMain : MonoBehaviour {
	
	private GameObject sellection ;
	
	private List<Vector3> startPositions = new List<Vector3>();
	
	private Dictionary<GameObject,Vector3> animalPos = new Dictionary<GameObject, Vector3>();
	
	
	
	public GameObject carrot;
	public GameObject wolf;
	public GameObject bear;
	public GameObject rabbit;
	

	
	private GameObject test;
	
	
	private bool isOkToTouch;
	private bool isDraging;
	
	void Awake()
	{
		startPositions = GameObject.FindObjectsOfType(typeof(GameObject)).Cast<GameObject>().Where(go => go.name == "pos").Select(go => go.transform.position).ToList();
		animalPos = GameObject.FindObjectsOfType(typeof(GameObject)).Cast<GameObject>().Where(go => go.name == "item").ToDictionary(go => go, go => go.transform.position);
		
	}
	
	void Start()
	{
		
	}

	
	void Update()
	{
		if(Input.touchCount == 1 )
		{
			
			Touch touch = Input.GetTouch(0);
			
			switch (touch.phase)
			{
			case TouchPhase.Began:
				
				sellection = CheckObject(Input.touches[0].position);
				if (sellection != null)
				{
				}
				
				break;
			case TouchPhase.Moved:
				if ( sellection != null)
				{
					sellection.transform.position = touchPos();
					sellection.transform.localScale = new Vector3(0.5f, 0.5f,0.5f);
				}
				break;
				
			case TouchPhase.Ended:
				
				if (sellection != null)
				{
					Vector2 currentPos = new Vector2(sellection.transform.position.x, sellection.transform.position.y);
					print (currentPos);	
					sellection.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
			
				
				break;
			}
			
			
			
			
		}
	}
	

	private GameObject CheckObject(Vector2 Pos)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Pos);
		if ( Physics.Raycast( ray , out hit))
		{
			return hit.collider.gameObject;
		}
		return null;
	}
	
	
	private Vector3 touchPos()
	{
		return Camera.main.ScreenToWorldPoint( new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 17.5f));
		
	}

	
}
