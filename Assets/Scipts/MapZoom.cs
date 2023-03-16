using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class MapZoom : MonoBehaviour
{
    public AbstractMap map;
    public float minZoom = 0f;
    public float maxZoom = 20f;
    public UnityEngine.UI.Slider zoomSlider;

    void Start()
    {
        // Set the initial value of the slider to the current zoom level of the map
        zoomSlider.value = map.Zoom;
    }

    public void OnZoomSliderChanged()
    {
        // Get the value of the slider and convert it to a zoom level
        float zoom = Mathf.Lerp(minZoom, maxZoom, zoomSlider.value);
        
        // Set the new zoom level of the map
        map.UpdateMap(zoom);
    }
}