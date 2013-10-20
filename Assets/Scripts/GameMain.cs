using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TriangleLive;

public class GameMain : MonoBehaviour {
	
	private GameObject sellection ;
	
	private List<Vector3> startPositions = new List<Vector3>();
	
	private Dictionary<GameObject,Vector3> animalPos = new Dictionary<GameObject, Vector3>();
	
	private Dictionary<Monster, GameObject> animals = new Dictionary<Monster, GameObject>();
	
	
	
	
	public GameObject carrot;
	public GameObject wolf;
	public GameObject bear;
	public GameObject rabbit;
	public GameObject panel;
	private TriangleEngine _engine;
	

	
	
	
	private Vector3 _currentStartPosition;
	
	
	private bool isOkToTouch;
	private bool isDraging;
	private int objCountCarrot = 0;
	private int objCountBear = 0;
	private int objCountRabbit = 0;
	private int objCountWolf = 0;
	private bool gameStart = false;
	
	void Awake()
	{
		startPositions = GameObject.FindObjectsOfType(typeof(GameObject)).Cast<GameObject>().Where(go => go.name == "pos").Select(go => go.transform.position).ToList();
		animalPos = GameObject.FindObjectsOfType(typeof(GameObject)).Cast<GameObject>().Where(go => go.name == "item").ToDictionary(go => go, go => go.transform.position);
		
		
	}
	
	void Start()
	{
		 _engine = new TriangleEngine();
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
					_currentStartPosition = animalPos[sellection];
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
			case TouchPhase.Canceled:	
				if (sellection != null)
				{
					Vector2 currentPos = new Vector2(sellection.transform.position.x, sellection.transform.position.y);
					sellection.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					CreateNewObject(sellection, currentPos, sellection.tag);
					sellection = null;
				}
				
				
				break;
			}
			
			
		}
	}
	
			

	
	
	public void CreateNewObject(GameObject obj , Vector3 pos, string objTag)
	{
		
		//poprawic !!!!!
		obj.collider.enabled = false;
		int xPos = (int)Mathf.Floor(pos.x);
		print (xPos);
		int yPos = (int)Mathf.Floor(pos.y);
		print (yPos);
			
		
		

			if ( obj.tag == "carrot" && objCountCarrot < 2)
			{	
				GameObject _carrot = GameObject.Instantiate(obj, new Vector3(_currentStartPosition.x, _currentStartPosition.y, 0.0f),Quaternion.identity) as GameObject;
				
				_carrot.collider.enabled = true;
				animalPos.Remove(obj);
				animalPos.Add(_carrot,_currentStartPosition);
				objCountCarrot ++;
				Carrot _carrotMonster = new Carrot(xPos,yPos);
				animals.Add(_carrotMonster, _carrot);
				_engine.PutMonsterOnBoard(_carrotMonster);
				RemovePanel();
			}
			
			if ( obj.tag == "wolf" && objCountWolf < 2)
			{
				GameObject _wolf = GameObject.Instantiate(obj, new Vector3(_currentStartPosition.x, _currentStartPosition.y, 0.0f),Quaternion.identity) as GameObject;
				_wolf.collider.enabled = true;
				animalPos.Remove(obj);
				animalPos.Add(_wolf,_currentStartPosition);
				objCountWolf++; 
				Wolf _wolfMonster = new Wolf(xPos, yPos);
				animals.Add(_wolfMonster, _wolf);
				_engine.PutMonsterOnBoard(_wolfMonster);
				RemovePanel();
			}
			
			if ( obj.tag == "rabbit" && objCountRabbit < 2)
			{
				GameObject _rabit = GameObject.Instantiate(obj, new Vector3(_currentStartPosition.x, _currentStartPosition.y, 0.0f),Quaternion.identity) as GameObject;
				_rabit.collider.enabled = true;
				animalPos.Remove(obj);
				animalPos.Add(_rabit,_currentStartPosition);
				objCountRabbit++;
				Rabbit _rabbitMonster = new Rabbit(xPos, yPos);
				animals.Add(_rabbitMonster, _rabit);
				_engine.PutMonsterOnBoard(_rabbitMonster);
				RemovePanel();
			}
		
			if ( obj.tag == "bear" && objCountBear < 2)
			{
				GameObject _bear = GameObject.Instantiate(obj, new Vector3(_currentStartPosition.x, _currentStartPosition.y, 0.0f),Quaternion.identity) as GameObject;
				
				print("TWORZE OBJEKT");
				
				_bear.collider.enabled = true;
				animalPos.Remove(obj);
				animalPos.Add(_bear,_currentStartPosition);
				objCountBear++;
				Bear _bearMonster = new Bear(xPos, yPos);
				animals.Add(_bearMonster, _bear);
				_engine.PutMonsterOnBoard(_bearMonster);
				RemovePanel();
			}
		
		
			
		
		
	}
	
	
	private void GameStart()
	{
		Debug.Log ( _engine.Monsters.Count() + "monsters Przed TURA!!!!!");
		_engine.Turn();
		Debug.Log( animals.Count() + " animals");
		Debug.Log ( _engine.Monsters.Count() + "monsters");
		UpdateMosters();
	
	}
	
	
	private void UpdateMosters()
	{
		foreach( var monster in _engine.Monsters)
		{
			int x = monster.Pos.X ;
			int y = monster.Pos.Y;
			iTween.MoveTo(animals[monster].gameObject,iTween.Hash("x", x, "y", y, "time", 2));
			
		}
	}
	
	
	private void RemovePanel()
	{
		if (objCountBear == 2 && objCountWolf == 2 && objCountRabbit == 2 && objCountCarrot == 2)
		{
			Destroy(panel);
			Invoke("GameStart", 2.0f);
		}
	}
	
	
	private void RestartAllCounters()
	{
		objCountCarrot = 0;
		objCountRabbit = 0;
		objCountWolf = 0;
		objCountBear = 0;
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
