using UnityEngine;
using UnityEngine.UI;

public class Aşama2UI : MonoBehaviour
{
    public Toggle HafızaToggle;
    public GameObject HafızaSliderGroup;

    public Toggle[] DiğerTogglelar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideSlider()
    {
        HafızaSliderGroup.SetActive(HafızaToggle.isOn);
    }
}
