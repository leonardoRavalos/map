 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject eventPanelUserInRange;
    [SerializeField] private GameObject eventPanelUserNotInRange;
    [SerializeField] private GameObject evento_logro;
    [SerializeField] private GameObject EventoAjustes;
    [SerializeField] private GameObject user;
    [SerializeField] private GameObject filro_mapas;
    [SerializeField] private GameObject filro_valoracion;
    [SerializeField] private SpawnOnMap spawnOnMap;
 

    bool isUIPanelActive;
    bool isUILogroActivate;
    bool isUIAjustesActivate;
    bool isUIUser;
    bool isMapas;
    bool isfiltro;
    bool isfilval;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiplayStartEventPanel()
    {
        if(isUIPanelActive == false && isUILogroActivate == false && isUIAjustesActivate==false)
        {
            eventPanelUserInRange.SetActive(true);
            isUIPanelActive = true;
        }
    }


    public void DisplayUserNotInRangePanel()
    {
        if(isUIPanelActive == false)
        {
            eventPanelUserNotInRange.SetActive(true);
            isUIPanelActive = true;
        }
         
    }

    public void CloseButtonClick()
    {
        eventPanelUserInRange.SetActive(false);
        eventPanelUserNotInRange.SetActive(false);
        isUIPanelActive = false;
    }

    public void DisplayStartEventologro()
    {
        if(isUILogroActivate == false && isUIAjustesActivate==false && isUIPanelActive==false)
        {
            evento_logro.SetActive(true);
            isUILogroActivate = true;
            eventPanelUserInRange.SetActive(false);
            eventPanelUserNotInRange.SetActive(false);
            isUIPanelActive = false; 
            isUIAjustesActivate = false; 
        }
        else
        {
            evento_logro.SetActive(false); 
            isUILogroActivate = false; 
                
        }
    }

    public void DisplayStartEventoAjustes()
    {
        if(isUIAjustesActivate == false && isUILogroActivate==false && isUIPanelActive==false)
        
        {
            EventoAjustes.SetActive(true);
            isUIAjustesActivate = true;
            eventPanelUserInRange.SetActive(false);
            eventPanelUserNotInRange.SetActive(false);
            isUIPanelActive = false; 
            isUILogroActivate = false; 
        }
        else
        {
            EventoAjustes.SetActive(false); 
            isUIAjustesActivate = false; 
                
        }
    }

    public void Uservisible()
    {
        if(isUIUser == false && isUIAjustesActivate==false)
        
        {
            user.SetActive(false);
            isUIUser = true;
        }
        else
        {
            user.SetActive(true); 
            isUIUser = false; 
                
        }
    }
    public void Displayfiltros()
    {
        if(isfiltro == false && isfilval==false)
        {
            eventPanelUserNotInRange.SetActive(false);
            filro_mapas.SetActive(false);
            isfilval = false;
            isfiltro = true;

            // Desactivar la función EventShow de SpawnOnMap
            spawnOnMap.DisableEventShow();
        }
        else
        {
            filro_mapas.SetActive(true); 
            isfiltro = false; 
        }
    }

    public void DisplayfiltrosValoracion()
    {
        if(isfiltro == false && isfilval==false)
        
        {
            eventPanelUserNotInRange.SetActive(false);
            filro_valoracion.SetActive(false);
            isfilval = true;
            isfiltro = false;
        }
        else
        {
            filro_valoracion.SetActive(true); 
            isfilval = false; 
                
        }
    }

}