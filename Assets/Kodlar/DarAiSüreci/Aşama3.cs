using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Aşama3 : MonoBehaviour
{
    private Aşama3UI aşama3ui;

    [InfoBox("Aşamanın tamamlanması için kazanılması gereken tasarım puanı. Zamanı belirler.")]
    public int GerekenToplamTasarımPuanı;

    private void Awake()
    {
        aşama3ui = FindFirstObjectByType<Aşama3UI>(FindObjectsInactive.Include);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GerekenToplamTasarımPuanı = (int)aşama3ui.ZamanSlider.value;
    }
}
