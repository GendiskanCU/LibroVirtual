//Define el espacio de nombres y la interfaz que se utilizará en la
//alternativa con la que se obtienen los datos de un fichero externo JSON
using System.Collections.Generic;

namespace SolarSystem{
    
public interface SolarSystemDataProvider
{
    public string GetMainInformation();//Obtiene la información de créditos de la app
    public List<CelestialBody> GetCelestialBodies();//Obtiene los datos de los cuerpos celestes
}

    }
