using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GelenİşlerEkranı : MonoBehaviour
{ 
    private KontratListesi kontratListesi;
    private AlınanKontrat alınanKontrat;
    private YapımSüreci yapımSüreci;

    public GameObject İşPanel;
    public GameObject YapımSüreciAşama1;

    #region Yazılar
    [System.Serializable]
    public class ŞirketPanel
    {
        public Text ŞirketİsmiText;
        public Text AçıklamaText;
        public Text VerilecekParaText;
        public Text VerilecekGünText;
        public Button KontratıİmzalaDüğmesi;

        public Image LogoImajı;
    }
    #endregion

    public ŞirketPanel[] ŞirketPanels;

    public void PaneliAçKapa()
    {
        İşPanel.SetActive(!İşPanel.activeSelf);
        KontratPaneliniGüncelle();
    }

    public void KontratPaneliniGüncelle()
    {
        if (kontratListesi.kontratList.Count > 0) 
        {
            for (int i = 0; i < ŞirketPanels.Length; i++) 
            {
                if(i < kontratListesi.kontratList.Count)
                {
                    ŞirketPanels[i].ŞirketİsmiText.text = kontratListesi.kontratList[i].İşverenİsmi;
                    ŞirketPanels[i].AçıklamaText.text = kontratListesi.kontratList[i].Açıklama;
                    ŞirketPanels[i].VerilecekParaText.text = kontratListesi.kontratList[i].VerilecekPara + "$";
                    ŞirketPanels[i].VerilecekGünText.text = kontratListesi.kontratList[i].VerilenGünSüresi + "gün";
                    ŞirketPanels[i].LogoImajı.sprite = kontratListesi.kontratList[i].ŞirketLogosu;
                    ŞirketPanels[i].KontratıİmzalaDüğmesi.gameObject.SetActive(true);
                }
                else
                {
                    ŞirketPanels[i].ŞirketİsmiText.text = "-";
                    ŞirketPanels[i].AçıklamaText.text = "-";
                    ŞirketPanels[i].VerilecekParaText.text = "- $";
                    ŞirketPanels[i].VerilecekGünText.text = "- gün";
                    ŞirketPanels[i].LogoImajı.sprite = null;
                    ŞirketPanels[i].KontratıİmzalaDüğmesi.gameObject.SetActive(false);
                }
            }
        }
        if(alınanKontrat.İşverenİsmi != "")
        {
            for (int i = 0; i < ŞirketPanels.Length; i++)
            {
                ŞirketPanels[i].KontratıİmzalaDüğmesi.gameObject.SetActive(false);

            }
        }
        else
        {
            for (int i = 0; i < ŞirketPanels.Length; i++)
            {
                ŞirketPanels[i].KontratıİmzalaDüğmesi.gameObject.SetActive(true);

            }
        }
    }

    public void Kontratıİmzala(int indeks)
    {
        alınanKontrat.İşverenİsmi = kontratListesi.kontratList[indeks].İşverenİsmi;
        alınanKontrat.VerilenGünSüresi = kontratListesi.kontratList[indeks].VerilenGünSüresi;
        alınanKontrat.KalanGünSüresi = kontratListesi.kontratList[indeks].KalanGünSüresi;
        alınanKontrat.VerilecekPara = kontratListesi.kontratList[indeks].VerilecekPara;;
        alınanKontrat.KalanGeçerlilikGünü = kontratListesi.kontratList[indeks].KalanGeçerlilikGünü;
        alınanKontrat.indeks = indeks;
        alınanKontrat.AlındıMı = true;
        yapımSüreci.Paneller[0].SetActive(true);
    }

    private void Awake()
    {
        kontratListesi = FindFirstObjectByType<KontratListesi>();
        alınanKontrat = FindAnyObjectByType<AlınanKontrat>();
        yapımSüreci = FindAnyObjectByType<YapımSüreci>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KontratPaneliniGüncelle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
