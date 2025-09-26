using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelector : MonoBehaviour
{
    DoubleCircularLinkedList<string> listaPersonaje;
    private Node<string> nodoActual;

    private Stack<Node<string>> historial = new Stack<Node<string>>();

    public TMP_Text personajeActualNext;
    public TMP_Text personajeDescrip;

    public Button SiguienteButton;
    public Button AnteriorButton;
    public Button deshacerButton;

    private void Start()
    {
        listaPersonaje = new DoubleCircularLinkedList<string>();
        listaPersonaje.Add("Rey");
        listaPersonaje.Add("Arquero");
        listaPersonaje.Add("Guerrero");
        listaPersonaje.Add("Peon");
        listaPersonaje.Add("Curandero");

        nodoActual = listaPersonaje.Head;

        historial.Push(nodoActual); 

        SiguienteButton.onClick.AddListener(SiguientePersonaje);
        AnteriorButton.onClick.AddListener(AnteriorPersonaje);
        deshacerButton.onClick.AddListener(DeshacerMovimiento);

        ActualizarDisplay();
    }


    public void SiguientePersonaje()
    {
        if (nodoActual != null && nodoActual.Next != null)
        {
            historial.Push(nodoActual);
            nodoActual = nodoActual.Next;
        }
        ActualizarDisplay();
    }

    public void AnteriorPersonaje()
    {
        if (nodoActual != null && nodoActual.Prev != null)
        {
            historial.Push(nodoActual);
            nodoActual = nodoActual.Prev;
        }
        ActualizarDisplay();
    }

    public void DeshacerMovimiento()
    {
        if (historial.Count > 1) 
        {
            historial.Pop(); 
            nodoActual = historial.Peek(); 
        }
        ActualizarDisplay();
    }

    public void ActualizarDisplay()
    {
        if (nodoActual != null)
        {
            personajeActualNext.text = $"Nombre del personaje: {nodoActual.Value}";
            personajeDescrip.text = $"Cantidad de personaje: {listaPersonaje.Count}";
            personajeDescrip.text += $"Historial: {historial.Count} movimientos\n";

            deshacerButton.interactable = historial.Count > 1;
        }
    }
}
