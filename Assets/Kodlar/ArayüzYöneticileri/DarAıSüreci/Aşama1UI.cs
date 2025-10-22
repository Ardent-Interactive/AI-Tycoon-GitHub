using UnityEngine;
using UnityEngine.UI;

public class Aşama1UI : MonoBehaviour
{
    #region DiğerKodlar
    private Aşama1 aşama1;
    #endregion

    public Slider VeriSetiBoyutuSlider;
    public Text VeriSetiBoyutuText;

    public Slider ParametreSlider;
    public Text ParametreText;

    public Slider BatchBoyutuSlider;
    public Text BatchBoyutuText;

    public Slider RastgelelikSlider;
    public Text RastgelelikText;

    //Ad bilgisi KontratListesi değişkenlerinde mevcut
    public Text KilitliKaynakText;

    private void Awake()
    {
        aşama1 = gameObject.GetComponent<Aşama1>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aşama1.MaxBatchBoyutu = aşama1.MaxVeriSetiBoyutu / 2;
    }

    // Update is called once per frame
    void Update()
    {
        YazıveDeğerleriAyarla();
    }

    public void SliderDeğerleriniAyarla()
    {
        VeriSetiBoyutuSlider.maxValue = aşama1.MaxVeriSetiBoyutu;
        ParametreSlider.maxValue = aşama1.MaxParametreSayısı;
        BatchBoyutuSlider.maxValue = aşama1.MaxBatchBoyutu;
        RastgelelikSlider.maxValue = aşama1.MaxRastgelelik;
    }

    public void YazıveDeğerleriAyarla()
    {
        VeriSetiBoyutuText.text = VeriSetiBoyutuSlider.value.ToString(string.Format("0.0")) + " MB";
        ParametreText.text = ParametreSlider.value + "";
        BatchBoyutuText.text = BatchBoyutuSlider.value + "";
        RastgelelikText.text = "%" + RastgelelikSlider.value;

        aşama1.VeriSetiBoyutu = (int)VeriSetiBoyutuSlider.value;
        aşama1.ParametreSayısı = (int)ParametreSlider.value;
        aşama1.BatchBoyutu = (int)BatchBoyutuSlider.value;
        aşama1.Rastgelelik = (int)RastgelelikSlider.value;
    }
}
