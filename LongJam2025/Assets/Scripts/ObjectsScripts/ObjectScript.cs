using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectScript : MonoBehaviour
{
    public UnityEvent click;
    private void OnMouseDown()
    {
        //minha logica foi por meio desse script criar a funcao de click que todo objeto vai ter
        //mas como cada objeto faz algo ao clicar nele, achei melhor ela so dar invoke nesse evento que o script individual vai definir o que faz
        click.Invoke();
    }
}
