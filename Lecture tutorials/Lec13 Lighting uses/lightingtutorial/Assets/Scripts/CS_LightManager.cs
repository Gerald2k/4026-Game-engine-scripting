using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_LightManager : MonoBehaviour
{

    [SerializeField]
    private List<Light> m_lPointLightRef = new List<Light>();
    [SerializeField]
    private Slider m_sIntensitySlider;
    [SerializeField]
    private Slider m_sColourRSlider;
    [SerializeField]
    private Slider m_sColourGSlider;
    [SerializeField]
    private Slider m_sColourBSlider;

    // Start is called before the first frame update
    void Start()
    {
        m_sIntensitySlider.onValueChanged.AddListener(delegate { SliderDelegateFunction(); });
        m_sColourBSlider.onValueChanged.AddListener(delegate { SliderDelegateFunction(); });
        m_sColourGSlider.onValueChanged.AddListener(delegate { SliderDelegateFunction(); });
        m_sColourRSlider.onValueChanged.AddListener(delegate { SliderDelegateFunction(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderDelegateFunction()
    {
        foreach(Light lLight in m_lPointLightRef)
        {
            lLight.intensity = m_sIntensitySlider.value; // Intensity value

            // Colour variable with RGB values
            lLight.color = new Vector4(m_sColourRSlider.value, m_sColourGSlider.value, m_sColourBSlider.value);
        }
        
    }
}
