//Implementación de la interfaz SolarSystemDataProvider para obtener los datos
//de los cuerpos celestes desde un fichero JSON

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SolarSystem{

public class SolarSystemJSONDataProvider : SolarSystemDataProvider
{
    public string GetMainInformation()
    {
        /*
        string filePath = "Assets/AppData/info.json";
        if(!File.Exists(filePath))
            return null;
        
        StreamReader reader = new StreamReader(filePath);
        var fileContent = reader.ReadToEnd();
        reader.Close(); */

        TextAsset fileWithMainInformation = Resources.Load<TextAsset>("AppData/info");
        string fileContent = fileWithMainInformation.text;

        var jsonInf = JsonUtility.FromJson<MainInfo>(fileContent);
        return jsonInf.Info;
    }


    public List<CelestialBody> GetCelestialBodies()
    {
        /*
        string filePath = "Assets/AppData/planetas.json";
        if(!File.Exists(filePath))
            return null;
        
        StreamReader reader = new StreamReader(filePath);
        var fileContent = reader.ReadToEnd();
        reader.Close(); */

        TextAsset fileWithMainInformation = Resources.Load<TextAsset>("AppData/planetas");
        string fileContent = fileWithMainInformation.text;

        CelestialBody[] jsonInf = JsonHelper.GetJsonArray<CelestialBody>(fileContent);
        return jsonInf.ToList();
    }
}
    }
