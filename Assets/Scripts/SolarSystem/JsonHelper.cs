//Clase para extraer un array de un fichero JSON
using System;
using UnityEngine;

namespace SolarSystem{
public class JsonHelper : MonoBehaviour
{
    public static T[] GetJsonArray<T>(string json)
        {
            string newJson = "{ \"Array\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.Array;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Array;
        }
}
    }
