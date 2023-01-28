//Controla la información de un cuerpo celeste
//Solo se utilizaría en la alternativa con la que se obtienen los datos de los propios objetos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using SolarSystem;


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

    
    /*Alternativa obteniendo los datos de los propios objetos
    //Canvas que mostrará la información del cuerpo celestial.
    private CanvasSolarSystem informationCanvas; */
    


    private void Start()
    {
        /*Opción utilizando un canvas hijo del objeto, de tipo Word Space (mirar el prefab MiniSolarSystem)
        if(transform.childCount > 0)
        {
            informationCanvas = transform.GetChild(0).gameObject;
            if(informationCanvas.transform.childCount > 0)
            {
                informationPanel = informationCanvas.transform.GetChild(0).gameObject;
                descriptionText = informationPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                //TODO: Completar con el resto de elementos del panel
            } 

                     
        }*/

        /*Alternativa obteniendo los datos de los propios objetos
        informationCanvas = GameObject.FindObjectOfType<CanvasSolarSystem>(); */
        
    }



    /*Alternativa obteniendo los datos de los propios objetos
    /// <summary>
    /// Envía la información a mostrar en la UI
    /// </summary>
    public void ShowBodyInfo()
    {
        informationCanvas.ShowCelestialBodyInfo(this);
    } */

    //Para testear funcionalidades sin necesidad de compilar a Android
    private void OnMouseDown() {
        Debug.Log(this.gameObject.name);

        SolarSystemJSONDataProvider jSONDataProvider = new SolarSystemJSONDataProvider();
        List<CelestialBody> celestialBodies = jSONDataProvider.GetCelestialBodies();

        CelestialBody celestialBodyFound = celestialBodies.Find(x => x.Id == this.gameObject.name);
            if (celestialBodyFound != null)
            {
                Debug.Log(string.Format("{0} ({1})", celestialBodyFound.Name, celestialBodyFound.Type));
            }
            else
            {
                Debug.Log("Not found");
            }
    }
}
