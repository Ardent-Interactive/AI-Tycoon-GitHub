using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class AlınanİşÖzet : MonoBehaviour
{
    private AlınanKontrat alınanKontrat;
    private Aşama1 aşama1;
    private Aşama1UI aşama1UI;
    private YapımSüreciUI yapımSüreciUI;

    [Header("Genel Bilgiler")]
    [InfoBox("Bu kısım sadece turuncu kutuda görünecek.")]
    public GameObject Panel;
    public Text ŞirketİsmiText;
    public Text VerilecekParaMiktarı;
    public Slider KalanZamanSlider;

    void Awake()
    {
        alınanKontrat = FindFirstObjectByType<AlınanKontrat>();
        aşama1 = FindFirstObjectByType<Aşama1>();
        aşama1UI = FindAnyObjectByType<Aşama1UI>();
        yapımSüreciUI = FindAnyObjectByType<YapımSüreciUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alınanKontrat.İşverenİsmi != "") 
        {
            Panel.SetActive(true);
            if (yapımSüreciUI.Paneller[0].activeInHierarchy)
            {
                alınanKontrat = FindFirstObjectByType<AlınanKontrat>();
                aşama1 = FindFirstObjectByType<Aşama1>();
                aşama1UI = FindAnyObjectByType<Aşama1UI>();
                yapımSüreciUI = FindAnyObjectByType<YapımSüreciUI>();
                aşama1UI.SliderDeğerleriniAyarla();
            }
            ŞirketİsmiText.text = alınanKontrat.İşverenİsmi;
            VerilecekParaMiktarı.text = alınanKontrat.VerilecekPara + "$";
            KalanZamanSlider.maxValue = alınanKontrat.VerilenGünSüresi;
            KalanZamanSlider.value = alınanKontrat.KalanGünSüresi;
            aşama1.KaynaklarıAyarla();
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
