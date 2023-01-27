//Controla la informaci�n que se mostrar� en la UI principal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private bool isShowing;


    private void Start()
    {
        BodyInformation.gameObject.SetActive(false);
        isShowing = false;
    }


    /// <summary>
    /// Muestra la información de un cuerpo celestial en la UI si no se está ya mostrando alguna
    /// </summary>
    /// <param name="celestialBody">Nombre del cuerpo celestial</param>
    public void ShowCelestialBodyInfo(string celestialBody)
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
