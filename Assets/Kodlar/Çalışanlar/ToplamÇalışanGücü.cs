using UnityEngine;
using UnityEngine.UI;

public class ToplamÇalışanGücü : MonoBehaviour
{
    public int ToplamAraştırmaGücü,ToplamKodlamaGücü, ToplamTasarımGücü;

    public Araştırmacı[] araştırmacılar;
    public Kodlamacı[] kodlamacılar;
    public Tasarımcı[] tasarımcılar;

    public void Awake()
    {
        araştırmacılar = FindObjectsByType<Araştırmacı>(FindObjectsSortMode.None);
        kodlamacılar = FindObjectsByType<Kodlamacı>(FindObjectsSortMode.None);
        tasarımcılar = FindObjectsByType<Tasarımcı>(FindObjectsSortMode.None);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hesapla();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hesapla()
    {
        ToplamAraştırmaGücü = 0;
        ToplamKodlamaGücü = 0;
        ToplamTasarımGücü = 0;

        //AraştırmaGücü hesabı
        foreach (var araştırmacı in araştırmacılar)
        {
            ToplamAraştırmaGücü += araştırmacı.AraştırmaBecerisi;
        }
        foreach (var kodlamacı in kodlamacılar)
        {
            ToplamAraştırmaGücü += kodlamacı.AraştırmaBecerisi;
        }

        //KodlamaGücü hesabı
        foreach (var araştırmacı in araştırmacılar)
        {
            ToplamKodlamaGücü += araştırmacı.KodlamaBecerisi;
        }
        foreach (var kodlamacı in kodlamacılar)
        {
            ToplamKodlamaGücü += kodlamacı.KodlamaBecerisi;
        }

        //TasarımGücü hesabı
        foreach (var tasarımcı in tasarımcılar)
        {
            ToplamTasarımGücü += tasarımcı.TasarımBecerisi;
        }
        foreach (var kodlamacı in kodlamacılar)
        {
            ToplamTasarımGücü += kodlamacı.TasarımBecerisi;
        }
    }
}
