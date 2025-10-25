using UnityEngine;
using UnityEngine.UI;

public class KaynaklarButtons : MonoBehaviour
{
    private Aþama1 aþama1;
    private GeliþtirilenYapayZeka GeliþtirilenYapayZeka;

    private void Awake()
    {
        aþama1 = FindFirstObjectByType<Aþama1>(FindObjectsInactive.Include);  
        GeliþtirilenYapayZeka = FindAnyObjectByType<GeliþtirilenYapayZeka>(FindObjectsInactive.Include);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Seç_SeçimiKaldýr(int indeks)
    {
        aþama1.SeçilebilecekKaynaklar[indeks].SeçildiMi = !aþama1.SeçilebilecekKaynaklar[indeks].SeçildiMi;
        SeçilenKaynakLarýGüncelle();
    }
    public void SeçilenKaynakLarýGüncelle()
    {
        foreach (var kaynak in aþama1.SeçilebilecekKaynaklar)
        {
            if (kaynak.SeçildiMi)
            {
                if (!aþama1.SeçilenKaynaklar.Contains(kaynak))
                {
                    aþama1.SeçilenKaynaklar.Add(kaynak);
                }
            }
            else if (!kaynak.SeçildiMi)
            {
                aþama1.SeçilenKaynaklar.Remove(kaynak);
            }
        }
    }

    public void UslübuHesapla()
    {
        foreach (var kaynak in aþama1.SeçilenKaynaklar)
        {
            GeliþtirilenYapayZeka.Resmiyet_Samimiyet += kaynak.Samimi_Resmi;
        }
        if(aþama1.SeçilenKaynaklar.Count != 0)
        {
            GeliþtirilenYapayZeka.Resmiyet_Samimiyet /= aþama1.SeçilenKaynaklar.Count;
        }
    }

    public void AraþtýrmacýlýðýHesapla()
    {
        foreach (var kaynak in aþama1.SeçilenKaynaklar)
        {
            GeliþtirilenYapayZeka.Araþtýrmacý += kaynak.Araþtýrmacý;
        }
        if (aþama1.SeçilenKaynaklar.Count != 0)
        {
            GeliþtirilenYapayZeka.Araþtýrmacý /= aþama1.SeçilenKaynaklar.Count;
        }
    }

    public void EðitimselliðiHesapla()
    {
        foreach (var kaynak in aþama1.SeçilenKaynaklar)
        {
            GeliþtirilenYapayZeka.Eðitimsel += kaynak.Eðitimsel;
        }
        if (aþama1.SeçilenKaynaklar.Count != 0)
        {
            GeliþtirilenYapayZeka.Eðitimsel /= aþama1.SeçilenKaynaklar.Count;
        }
    }
}
