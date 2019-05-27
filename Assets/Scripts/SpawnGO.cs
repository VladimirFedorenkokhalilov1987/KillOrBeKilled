using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnGO : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider _ObjectToSpawn;

    public List<GameObject> _ObjectsToSpawnList;
    public Vector3 _offset;
    public bool spawned;
    public Transform _setToThisParent;
    private GameObject[] _randomizeGameObjects;
    private Camera cam;
    private UIManager _kilsCount;
void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
    private void Start()
    {
        cam = Camera.main;
        Spawn();
        _ObjectToSpawn = this.GetComponentInChildren<Collider>();;
    }
    private void Update()
    {
        if (_kilsCount == null)
        {
            _kilsCount = FindObjectOfType<UIManager>();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //suppose i have two objects here named obj1 and obj2.. how do i select obj1 to be transformed 
                if (hit.transform != null)
                {
                   DeleteSpawnedGO();
                   Spawn();
                }
            }
        }
    }
    public void Spawn()
    {
        _offset = new Vector3(Random.Range(-5,5),Random.Range(-5,5),0);
            _randomizeGameObjects = Resources.LoadAll<GameObject>("Prefabs");
            GameObject _killItVaries = _ObjectsToSpawnList [Random.Range (0, _ObjectsToSpawnList.Count)];
            GameObject _newKillIn = Instantiate (_killItVaries, transform.position+_offset, Quaternion.identity) as GameObject;
            _ObjectToSpawn = _newKillIn.GetComponent<Collider>();
            _newKillIn.gameObject.transform.SetParent(_setToThisParent);
            _newKillIn.transform.localScale =_setToThisParent.transform.localScale;
            spawned = true;
    }

    public void DeleteSpawnedGO()
    {
        _kilsCount._kills++;
        if (_ObjectToSpawn.gameObject)
        {
            Destroy(_ObjectToSpawn.gameObject);
            spawned = false;
        }
    }
}
