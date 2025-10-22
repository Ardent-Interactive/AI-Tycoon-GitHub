using UnityEngine;
using UnityEngine.UI;

public class Aşama3UI : MonoBehaviour
{
    private YapımSüreci yapımSüreci;

    public Slider ZamanSlider;
    public Text ZamanText;
    public Text ÖzelliklerText;

    private void Awake()
    {
        yapımSüreci = FindFirstObjectByType<YapımSüreci>();
        print(yapımSüreci);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var özellik in yapımSüreci.özellikler)
        {
            if (özellik.AçıkMı)
            {
                ÖzelliklerText.text += "-" + özellik.ÖzellikAdı + " : " + "Var" + "\n";
            }
            else
            {
                ÖzelliklerText.text += "-" + özellik.ÖzellikAdı + " : " + "Yok" + "\n";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
