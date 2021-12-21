using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
  public static Transform[] waypoints;

  void Awake()// começa mais cedo que o Start; antes que qualquer coisa
  {
    waypoints = new Transform[transform.childCount]; //numero de waypoints/ filhos
    for (int i = 0; i < waypoints.Length; i++)
    {
        waypoints[i] = transform.GetChild(i); //pega o filho de cada waypoint e assim sucessivamente
    }
  }
}
