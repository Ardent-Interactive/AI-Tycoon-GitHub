using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class AlınanİşÖzet : MonoBehaviour
{
    private AlınanKontrat alınanKontrat;

    [Header("Genel Bilgiler")]
    [InfoBox("Bu kısım sadece turuncu kutuda görünecek.")]
    public GameObject Panel;
    public Text ŞirketİsmiText;
    public Text VerilecekParaMiktarı;
    public Slider KalanZamanSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alınanKontrat = FindFirstObjectByType<AlınanKontrat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alınanKontrat.İşverenİsmi != "") 
        {
            Panel.SetActive(true);
            ŞirketİsmiText.text = alınanKontrat.İşverenİsmi;
            VerilecekParaMiktarı.text = alınanKontrat.VerilecekPara + "$";
            KalanZamanSlider.maxValue = alınanKontrat.VerilenGünSüresi;
            KalanZamanSlider.value = alınanKontrat.KalanGünSüresi;
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
