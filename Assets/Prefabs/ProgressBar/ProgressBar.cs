using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Image _bar;
    private Text _txt;
    private float _val;

    public Color alerteColor = Color.red;
    private Color _startColor;

    public float alerteLevel = 25f;

    public float Val
    {
        get
        {
            return _val;
        }

        set
        {
            _val = value;
            // bloquer la valeur entre 0 et 100
            _val = Mathf.Clamp(_val, 0, 100);
            // modifier la valeur de notre UI
            UpdateValue();
        }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        _bar = transform.Find("Bar").GetComponent<Image>();
        _txt = _bar.transform.Find("Text").GetComponent<Text>();
        // definit la couleur de demarrage
        _startColor = _bar.color;
        // val = 100 au demarrage
        Val = 100;
    }

    public void UpdateValue()
    {
        _txt.text = (int)_val + "%";
        _bar.fillAmount = _val / 100;

        if (_val <= alerteLevel)
        {
            _bar.color = alerteColor;
        }
        else
        {
            _bar.color = _startColor;
        }
    }
    
}
