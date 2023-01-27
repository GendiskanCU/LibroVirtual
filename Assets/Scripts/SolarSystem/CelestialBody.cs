//Información de un cuerpo celeste
//Se utilizará en la alternativa con la que se obtienen los datos de un fichero externo JSON

using System;


[Serializable]
public class CelestialBody
{
   public string Id;
   public string Name;
   public string Type;
   public string Description;
   public string Gravity;
   public string SunDistance;
   public string Mass;
   public string Density;
   public string DayLenght;
   public string YearLenght;
   public string Sprite;
   public string LeadTime;
   public string Score;
}
