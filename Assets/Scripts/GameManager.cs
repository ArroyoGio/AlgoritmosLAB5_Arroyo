using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private DoubleCircularLinkedList<string> Estudiantes = new();
    void Start()
    {
        Estudiantes.Add("Villena");
        Estudiantes.Add("Naser");
        Estudiantes.Add("Gio");
        Estudiantes.Add("Erwin");

        //Estudiantes.Remove(0);
        Estudiantes.Remove(3);

        Estudiantes.ReadForward(Estudiantes.Head);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MyMethod()
    {

    }
}

