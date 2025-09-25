using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    DoubleCircularLinkedList<string> listaPersonaje;
    private Node<string> nodoActual;

    public TMP_Text personajeActualNext;
    public TMP_Text personajeDescrip;

    public Button SiguienteButton;
    public Button AnteriorButton;

    private void Start()
    {
        listaPersonaje = new DoubleCircularLinkedList<string>();
        listaPersonaje.Add("Rey");
        listaPersonaje.Add("Arquero");
        listaPersonaje.Add("Guerrero");
        listaPersonaje.Add("Peon");
        listaPersonaje.Add("Curandero");

        nodoActual = listaPersonaje.Head;

        SiguienteButton.onClick.AddListener(SiguientePersonaje);
        AnteriorButton.onClick.AddListener(AnteriorPersonaje);

        ActualizarDisplay();
    }


    public void SiguientePersonaje()
    {
        if (nodoActual != null && nodoActual.Next != null)
        {
            nodoActual = nodoActual.Next;
        }
        ActualizarDisplay();
    }

    public void AnteriorPersonaje()
    {
        if (nodoActual != null && nodoActual.Prev != null)
        {
            nodoActual = nodoActual.Prev;
        }
        ActualizarDisplay();
    }

    public void ActualizarDisplay()
    {
        if (nodoActual != null)
        {
            personajeActualNext.text = $"Nombre del personaje: {nodoActual.Value}";
            personajeDescrip.text = $"Cantidad de personaje: {listaPersonaje.Count}";
        }
    }
}
