//Muestra visualmente si se ha capturado/perdido el target

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionImageUI : MonoBehaviour
{
    [SerializeField][Tooltip("Imagen que indicará si el Image Target está Found o Lost")]
    private Image detectionImage;

    [SerializeField][Tooltip("Colores que indicarán si el Image Tartet está activo o no")]
    private Color foundColor, lostColor;

    
    void Start()
    {
        detectionImage.color = lostColor;
    }

    public void ChangeDetectionStatus(bool newStatus)
    {
        detectionImage.color = newStatus ? foundColor : lostColor;
    }
}
