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
    [Tooltip("Image Target que activará el sistema solar")]
    private GameObject imageTarget;
    
    [SerializeField]
    [Tooltip("Objeto que alberga el sistema solar")]
    private GameObject theSolarSystem;

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

    [SerializeField]
    [Tooltip("Botón que activa/desactiva el tiempo acelerado")]
    private GameObject acceleratedSpeedButton;

    [SerializeField]
    [Tooltip("Botón que activa/desactiva el tiempo reducido")]
    private GameObject reducedSpeedButton;

    [SerializeField]
    [Tooltip("Botón que activa/desactiva silenciar sonido")]
    private GameObject soundButton;    

     [SerializeField]
     [Tooltip("Velocidad a la que se irán mostrando la información, en caracteres/segundo")]
    private int charactersPerSecond = 5;

    //Para controlar cuándo se está mostrando el panel de información de un cuerpo celestial
    private bool panelInfoIsShowing = false;

    //Para cargar y almacenar los datos de los cuerpos celestiales desde un fichero JSON
    private SolarSystemJSONDataProvider jSONDataProvider;
    private List<CelestialBody> celestialBodies = new List<CelestialBody>();

    //Para controlar si el usuario ha rotado el sistema solar para adaptarlo a un target en horizontal
    private bool solarSystemRotated;

    //Para controlar la escala de tiempo
    private float normalTimeScale = 1.0f;
    private float acceleratedTimeScale = 4.0f;
    private float reducedTimeScale = 0.1f;

    //Para controlar la corutina que mostrará la información de manera progresiva
    private IEnumerator infoCoroutine;

    //Para controlar la posición del contenedor de información de los cuerpos celestiales
    private GameObject infoContent;

    private void Start()
    {
        panelBodyInformation.gameObject.SetActive(false);
        panelInfoIsShowing = false;

        jSONDataProvider = new SolarSystemJSONDataProvider();
        celestialBodies = jSONDataProvider.GetCelestialBodies();

        infoContent = descriptionText.gameObject.transform.parent.gameObject;        

        
        //El botón de sonido mostrará el icono adecuado a la configuración 
        Toggle toggleSoundButton = soundButton.GetComponentInChildren(typeof(Toggle), true) as Toggle;        
        if(SettingsManager.SharedInstance.CheckIfSettingActivated(TypeOfSetting.VOLUME_ON) == StatusOfSetting.NO)
        {            
            if(toggleSoundButton != null)
                toggleSoundButton.isOn = true;
        }
        else
        {
            SoundManager.SharedInstance.ChangeVolumeSounds();//Fuerza en todo caso la primera ejecución de este método
        }

        //El sistema solar rotará confirme a la configuración guardada
        if(SettingsManager.SharedInstance.CheckIfSettingActivated(TypeOfSetting.ROTATION_ON) == StatusOfSetting.YES)        
            solarSystemRotated = false;                    
        else        
            solarSystemRotated = true;                    
        RotateSolarSystem();
    }


    /// <summary>
    /// Muestra un panel de información de un cuerpo celestial en la UI
    /// </summary>
    /// <param name="celestialBody">Nombre del cuerpo celestial</param>
    public void ShowCelestialBodyInfo(string celestialBodyName)
    {
        if (!panelInfoIsShowing)//Evita que se muestre nueva información hasta que no se haya cerrado la actual
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

            SoundManager.SharedInstance.PlayCelestialBodyFoundSound();
                        
            nameText.text = celestialBodyFound.Name;
            bodyImage.sprite = Resources.Load<Sprite>($"Planets/{celestialBodyFound.Sprite}");
            massText.text = string.Format("MASA: {0} Kgs.", celestialBodyFound.Mass);
            densityText.text = string.Format("DENSIDAD: {0} grs/cm3.", celestialBodyFound.Density);
            gravityText.text = string.Format("GRAVEDAD: {0} m/s2.", celestialBodyFound.Gravity);
            dayText.text = string.Format("DURACIÓN DE UN DÍA: {0}", celestialBodyFound.DayLenght);
            yearText.text = string.Format("DURACIÓN DE UN AÑO: {0}", celestialBodyFound.YearLenght);
            distanceText.text = string.Format("DISTANCIA AL SOL: {0} millones de Kms.", celestialBodyFound.SunDistance);
            //descriptionText.text = celestialBodyFound.Description;

            panelBodyInformation.gameObject.SetActive(true);
            panelInfoIsShowing = true;

            
            //Alternativa utilizando una corutina para mostrar el texto carácter a carácter
            SoundManager.SharedInstance.PlayWritingInfoSound();
            descriptionText.text = "";
            infoCoroutine = SetInfoText(celestialBodyFound.Description);
            StartCoroutine(infoCoroutine);
        }
    }

    private IEnumerator SetInfoText(string info)
    {        
        foreach(char character in info)
        {            
            descriptionText.text += character;
            yield return new WaitForSeconds(1.0f / (charactersPerSecond / Time.timeScale));
        }

        Debug.Log("Fin de la información");
        SoundManager.SharedInstance.StopAllSFX();
    }

    //Reinicia y desactiva el panel de información de un cuerpo celestial
    public void HideCelestialBodyInfo()
    {
        StopCoroutine(infoCoroutine);

        infoContent.GetComponent<RectTransform>().localPosition =
            new Vector3(0, 0, 0) ;        

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

    public void ActivateDeactivateAcceleratedSpeed()
    {
        if(Time.timeScale != acceleratedTimeScale)
        {
            Time.timeScale = acceleratedTimeScale;
            acceleratedSpeedButton.GetComponent<Image>().color = Color.red;
            reducedSpeedButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            ActivateNormalSpeed();
        }
    }

    public void ActivateDeactivateReducedSpeed()
    {
        if(Time.timeScale != reducedTimeScale)
        {
            Time.timeScale = reducedTimeScale;
            acceleratedSpeedButton.GetComponent<Image>().color = Color.white;
            reducedSpeedButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            ActivateNormalSpeed();
        }            
    }

    private void ActivateNormalSpeed()
    {        
        Time.timeScale = normalTimeScale;
        acceleratedSpeedButton.GetComponent<Image>().color = Color.white;
        reducedSpeedButton.GetComponent<Image>().color = Color.white;
    }    

    public void RotateSolarSystem()
    {
        if(solarSystemRotated)
        {
            theSolarSystem.transform.localRotation = Quaternion.Euler(90f, theSolarSystem.transform.localRotation.y,
            theSolarSystem.transform.localRotation.z);
        }
        else
        {
            theSolarSystem.transform.localRotation = Quaternion.Euler(0f, theSolarSystem.transform.localRotation.y,
            theSolarSystem.transform.localRotation.z);
        }

        solarSystemRotated = !solarSystemRotated;

        if(solarSystemRotated)
            SettingsManager.SharedInstance.SetSettingStatus(TypeOfSetting.ROTATION_ON, StatusOfSetting.YES);
        else
            SettingsManager.SharedInstance.SetSettingStatus(TypeOfSetting.ROTATION_ON, StatusOfSetting.NO);
    }

    public void ReturnToMainScreen()
    {
        if(Time.timeScale != normalTimeScale)
        {
            ActivateNormalSpeed();
        }
        imageTarget.SetActive(false);
        HideCelestialBodyInfo();
        DeactivatePanelAppButtons();        
        mainScreen.SetActive(true);

        SoundManager.SharedInstance.PlayMainMusic();        
    }

}
