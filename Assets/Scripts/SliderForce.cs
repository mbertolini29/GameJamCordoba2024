using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderForce : MonoBehaviour
{
    enum estadoBarra
    {
        quieto,
        llenando,
        vaciandose
    }

    //private int POWER_MULTIPLIER = 100;

    estadoBarra estadoActual = estadoBarra.vaciandose;

    [SerializeField] Slider slider;
    [SerializeField] GrandmotherProjectile grandmother;
    [SerializeField] AnimationCurve power;

    //public float x = 0;
    //public float y;

    public float fillSpeed = 5f;
    float targetProgress = 1;

    //abuela
    public GrandmotherProjectile grandmotherProjectile;

    private void Start()
    {
        Debug.Log($"valor en 0 {power.Evaluate(0)}");
        Debug.Log($"valor en 0,1 {power.Evaluate(0.1f)}");
        Debug.Log($"valor en 0.5 {power.Evaluate(0.5f)}");
        Debug.Log($"valor en 0.9 {power.Evaluate(0.9f)}");
        Debug.Log($"valor en 1 {power.Evaluate(1)}");
    }

    private void FixedUpdate()   
    {
        //
        //x += 2 * Time.deltaTime;
        //y = Mathf.Sin(x);
        //slider.value = y;

        if (estadoActual == estadoBarra.llenando)
        {
            slider.value += fillSpeed * Time.deltaTime;
            IncrementProfess(slider.value);

            if (slider.value >= 1)
            {
                estadoActual = estadoBarra.vaciandose;
            }
        }
        else if (estadoActual == estadoBarra.vaciandose)
        {
            slider.value -= fillSpeed * Time.deltaTime;
            IncrementProfess(slider.value);

            if (slider.value <= 0)
            {
                estadoActual = estadoBarra.llenando;
            }
        }

        if (Input.GetButtonDown("Fire1")) //(Input.GetMouseButtonDown(0))
        {
            var forceAtClick = power.Evaluate(slider.value);// * POWER_MULTIPLIER;

            Debug.Log($"hice click en el valor {forceAtClick}");

            grandmother.MovePlayer(forceAtClick);

            //estadoActual = estadoBarra.quieto;
        }
    }

    public void IncrementProfess(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
