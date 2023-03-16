using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mapbox Library
using Mapbox.Examples;
using Mapbox.Utils;
using UnityEngine.UI;
using System.Text;

public class EventPointer : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] float amplitude = 2.0f;
    [SerializeField] float frequency = 0.50f;
    [SerializeField] Text _name;
    [SerializeField] Text _description;
    

    LocationStatus playerLocation;
    public Vector2d eventPos;
    public int eventID;
    public string eventName;
    public string eventDescription;

    MenuUIManager menuUIManager;

    // Start is called before the first frame update
    void Start()
    {
        menuUIManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
        
        // Find all objects with tag "spawneable" and set the _name text on each object
        GameObject[] spawnables = GameObject.FindGameObjectsWithTag("Spawnable");
        foreach (GameObject spawnable in spawnables) {
            spawnable.GetComponent<EventPointer>()._name = _name;
            spawnable.GetComponent<EventPointer>()._description = _description;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotatePointer();
    }

    void FloatAndRotatePointer()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + 15, transform.position.z);
    }

    private void OnMouseDown()
    {

        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLon());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = currentPlayerLocation.GetDistanceTo(eventLocation);
        Debug.Log("Distance is: " + distance);
        if(distance < 70)
    {
        menuUIManager.DisplayUserNotInRangePanel();

        _name.text = "eventName";
        _description.text = "eventDescription";
    }
    else
    {
        menuUIManager.DiplayStartEventPanel();
        _description.text = eventDescription;

        // Crea un objeto StringBuilder
        StringBuilder sb = new StringBuilder();

        // Agrega cada oración de eventName al objeto StringBuilder con un espacio al final.
        string[] sentences = eventName.Split('.');
        foreach (string sentence in sentences)
        {
            sb.Append(sentence.Trim());
            sb.Append(". ");
        }

        // Convierte el objeto StringBuilder en una cadena usando el método ToString().
        string eventNameWithSpaces = sb.ToString();

        // Asigna la cadena resultante al Text _name.
        _name.text = eventNameWithSpaces;
        }
    }
}


        
