//Controla la informaci�n que se mostrar� en la UI principal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using SolarSystem;

public class CanvasSolarSystem : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Panel de informaci�n de los cuerpos celestiales")]
    private GameObject BodyInformation;

    [SerializeField]
    [Tooltip("Campo de texto para el nombre y tipo del cuerpo celestial")]
    private TextMeshProUGUI nameText;

    [SerializeField]
    [Tooltip("Campo para la imagen del cuerpo celestial")]
    private Image bodyImage;

    [SerializeField]
    [Tooltip("Campo de texto para la masa del cuerpo celestial")]
    private TextMeshProUGUI massText;

    [SerializeField]
    [Tooltip("Campo de texto para la densidad del cuerpo celestial")]
    private TextMeshProUGUI densityText;

    [SerializeField]
    [Tooltip("Campo de texto para la gravedad del cuerpo celestial")]
    private TextMeshProUGUI gravityText;

    [SerializeField]
    [Tooltip("Campo de texto para la duraci�n de un d�a del cuerpo celestial")]
    private TextMeshProUGUI dayText;

    [SerializeField]
    [Tooltip("Campo de texto para la duraci�n de un a�o del cuerpo celestial")]
    private TextMeshProUGUI yearText;

    [SerializeField]
    [Tooltip("Campo de texto para la distancia al sol del cuerpo celestial")]
    private TextMeshProUGUI distanceText;

    [SerializeField]
    [Tooltip("Campo de texto para la descripci�n del cuerpo celestial")]
    private TextMeshProUGUI descriptionText;

    //Para controlar si ya se está mostrando la información de un cuerpo celestial
    private bool isShowing = false;

    //Para cargar y almacenar los datos de los cuerpos celestiales desde fichero JSON
    private SolarSystemJSONDataProvider jSONDataProvider;
    private List<CelestialBody> celestialBodies = new List<CelestialBody>();


    private void Start()
    {
        BodyInformation.gameObject.SetActive(false);
        isShowing = false;

        jSONDataProvider = new SolarSystemJSONDataProvider();
        celestialBodies = jSONDataProvider.GetCelestialBodies();
    }


    /// <summary>
    /// Muestra la información de un cuerpo celestial en la UI si no se está ya mostrando alguna
    /// </summary>
    /// <param name="celestialBody">Nombre del cuerpo celestial</param>
    public void ShowCelestialBodyInfo(string celestialBodyName)
    {
        if (!isShowing)//Evita que se muestre nueva informaci�n hasta que no se haya cerrado la actual
        {
            /*Alternativa descartada: obteniendo los datos de los propios objetos CelestialBodyInfo
            nameText.text = string.Format("{0}\n({1})", celestialBody.Name, celestialBody.Type);
            bodyImage.sprite = celestialBody.SpriteUI;
            massText.text = string.Format("MASA: {0} Kgs.", celestialBody.Mass);
            densityText.text = string.Format("DENSIDAD: {0} grs/cm3.", celestialBody.Density);
            gravityText.text = string.Format("GRAVEDAD: {0} m/s2.", celestialBody.Gravity);
            dayText.text = string.Format("DURACIÓN DE UN DÍA: {0}", celestialBody.DayLenght);
            yearText.text = string.Format("DURACIÓN DE UN AÑO: {0}", celestialBody.YearLenght);
            distanceText.text = string.Format("DISTANCIA AL SOL: {0} millones de Kms.", celestialBody.SunDistance);
            descriptionText.text = celestialBody.Description; */

            //nameText.text = celestialBodyName;
            //BodyInformation.gameObject.SetActive(true);
            
            CelestialBody celestialBodyFound = celestialBodies.Find(x => x.Id == celestialBodyName);

            if(celestialBodyFound == null)
            {
                Debug.Log("Not found");
                return;
            }

            
            nameText.text = celestialBodyFound.Name;
            bodyImage.sprite = Resources.Load<Sprite>($"Planets/{celestialBodyFound.Sprite}");
            massText.text = string.Format("MASA: {0} Kgs.", celestialBodyFound.Mass);
            densityText.text = string.Format("DENSIDAD: {0} grs/cm3.", celestialBodyFound.Density);
            gravityText.text = string.Format("GRAVEDAD: {0} m/s2.", celestialBodyFound.Gravity);
            dayText.text = string.Format("DURACIÓN DE UN DÍA: {0}", celestialBodyFound.DayLenght);
            yearText.text = string.Format("DURACIÓN DE UN AÑO: {0}", celestialBodyFound.YearLenght);
            distanceText.text = string.Format("DISTANCIA AL SOL: {0} millones de Kms.", celestialBodyFound.SunDistance);
            descriptionText.text = celestialBodyFound.Description;

            BodyInformation.gameObject.SetActive(true);
            isShowing = true;            
        }
    }

    public void HideCelestialBodyInfo()
    {
        nameText.text = "";
        bodyImage.sprite = null;
        massText.text = "";
        densityText.text = "";
        gravityText.text = "";
        dayText.text = "";
        yearText.text = "";
        distanceText.text = "";
        descriptionText.text = "";

        BodyInformation.gameObject.SetActive(false);
        isShowing = false;
    }

}
