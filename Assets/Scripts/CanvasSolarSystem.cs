//Controla la interfaz e información que se mostrarán en la UI principal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using SolarSystem;

public class CanvasSolarSystem : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Panel de información de los cuerpos celestiales")]
    private GameObject panelBodyInformation;

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
    [Tooltip("Campo de texto para la duración de un día del cuerpo celestial")]
    private TextMeshProUGUI dayText;

    [SerializeField]
    [Tooltip("Campo de texto para la duración de un año del cuerpo celestial")]
    private TextMeshProUGUI yearText;

    [SerializeField]
    [Tooltip("Campo de texto para la distancia al sol del cuerpo celestial")]
    private TextMeshProUGUI distanceText;

    [SerializeField]
    [Tooltip("Campo de texto para la descripción del cuerpo celestial")]
    private TextMeshProUGUI descriptionText;

    [SerializeField]
    [Tooltip("Panel de botones de interacción")]
    private GameObject panelAppButtons;

    [SerializeField]
    [Tooltip("Panel de inicio")]
    private GameObject mainScreen;

    [SerializeField]
    [Tooltip("Botón que activa el panel de botones de interacción")]
    private GameObject activatePanelButton;

    //Para controlar cuándo se está mostrando el panel de información de un cuerpo celestial
    private bool panelInfoIsShowing = false;

    //Para cargar y almacenar los datos de los cuerpos celestiales desde un fichero JSON
    private SolarSystemJSONDataProvider jSONDataProvider;
    private List<CelestialBody> celestialBodies = new List<CelestialBody>();


    private void Start()
    {
        panelBodyInformation.gameObject.SetActive(false);
        panelInfoIsShowing = false;

        jSONDataProvider = new SolarSystemJSONDataProvider();
        celestialBodies = jSONDataProvider.GetCelestialBodies();
    }


    /// <summary>
    /// Muestra un panel de información de un cuerpo celestial en la UI
    /// </summary>
    /// <param name="celestialBody">Nombre del cuerpo celestial</param>
    public void ShowCelestialBodyInfo(string celestialBodyName)
    {
        if (!panelInfoIsShowing)//Evita que se muestre nueva informaci�n hasta que no se haya cerrado la actual
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
            //panelBodyInformation.gameObject.SetActive(true);
            
            CelestialBody celestialBodyFound = celestialBodies.Find(x => x.Id == celestialBodyName);

            if(celestialBodyFound == null)
            {
                Debug.LogError("Celestial body not found");
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

            panelBodyInformation.gameObject.SetActive(true);
            panelInfoIsShowing = true;            
        }
    }

    //Reinicia y desactiva el panel de información de un cuerpo celestial
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

        panelBodyInformation.gameObject.SetActive(false);
        panelInfoIsShowing = false;
    }

    //Activa el panel de botones de interacción de la UI
    public void ActivatePanelAppButtons()
    {
        panelAppButtons.SetActive(true);
        activatePanelButton.SetActive(false);
    }

    //Desactiva el panel de botones de interacción de la UI
    public void DeactivatePanelAppButtons()
    {
        panelAppButtons.SetActive(false);
        activatePanelButton.SetActive(true);
    }

    public void ReturnToMainScreen()
    {
        HideCelestialBodyInfo();
        DeactivatePanelAppButtons();
        mainScreen.SetActive(true);        
    }

}
