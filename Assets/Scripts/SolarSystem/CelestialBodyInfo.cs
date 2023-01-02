//Controla la información de un cuerpo celeste

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum TypeOfCelestialBody
{Estrella, Planeta, Satelite, Otro};


public class CelestialBodyInfo : MonoBehaviour
{
    [SerializeField][Tooltip("Tipo de cuerpo celestial")]
    private TypeOfCelestialBody type;
    public TypeOfCelestialBody Type => type;

    [SerializeField][Tooltip("Nombre")]
    private string bodyName;
    public string Name => bodyName;

    [SerializeField][Tooltip("Descripción")]
    private string description;
    public string Description => description;

    [SerializeField][Tooltip("gravedad (m/s2)")]
    private string gravity;
    public string Gravity => gravity;

    [SerializeField][Tooltip("Distancia al sol (millones de km)")]
    private string sunDistance;
    public string SunDistance => sunDistance;

    [SerializeField][Tooltip("Masa (Kg))")]
    private string mass;
    public string Mass => mass;

    [SerializeField][Tooltip("Densidad (g/cm3)")]
    private string density;
    public string Density => density;

    [SerializeField][Tooltip("Duración del día (en días terrestres)")]
    private string dayLenght;
    public string DayLenght => dayLenght;

    [SerializeField][Tooltip("Duración del año (en días terrestres)")]
    private string yearLenght;
    public string YearLenght => yearLenght;    

    [SerializeField][Tooltip("Sprite para representar en la UI")]
    private Sprite spriteUI;
    public Sprite SpriteUI => spriteUI;

    [SerializeField][Tooltip("Puntuación que otorga (si procede)")]
    private int score = 0;
    public int Score => score;

    private GameObject informationCanvas, informationPanel;
    private TextMeshProUGUI descripcionTxt;


    private void Start()
    {
        if(transform.childCount > 0)
        {
            informationCanvas = transform.GetChild(0).gameObject;
            if(informationCanvas.transform.childCount > 0)
            {
                informationPanel = informationCanvas.transform.GetChild(0).gameObject;
                descripcionTxt = informationPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                //TODO: Completar con el resto de elementos del panel
            } 

                     
        }        
    }


    public void ShowBodyInfo()
    {
        if(type != TypeOfCelestialBody.Otro)
        {
            informationCanvas.SetActive(true);        
            
        }
        else
        {
            
        }
    }
}
