using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RowBarcos : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [HideInInspector]
    public Barcos barco;
    CustomButton button;
    [HideInInspector]
    public HooverView hooverView;
    [HideInInspector]
    public Atarazanas atarazanas;
    private void Start()
    {
        button = GetComponentInChildren<CustomButton>();
        if (hooverView != null)
        {
            hooverView.gameObject.SetActive(false);
        }

    }

    public void Comprar()
    {
        atarazanas.ComprarBarco(barco);
    }

    public void Alquilar()
    {
        atarazanas.AlquilarBarco(barco);
    }
    public void Reparar()
    {
        atarazanas.RepararBarco(barco);
    }
    public void Vender()
    {
        atarazanas.VenderBarco(barco);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        showHoover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exitHoover();
    }

    public void showHoover()
    {
        TextMeshProUGUI[] texts = hooverView.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = "Descripción: " + barco.descripcion.ToString();

        texts[1].text = "Capacidad: " + barco.capacity + " barriles";

        texts[2].text = "Vida máxima: " + barco.vidaTotal;
        hooverView.transform.position = new Vector3(button.transform.position.x + 350, button.transform.position.y + 200, hooverView.transform.position.z);
        hooverView.gameObject.SetActive(true);
    }

    public void exitHoover()
    {
        hooverView.gameObject.SetActive(false);
    }
}
