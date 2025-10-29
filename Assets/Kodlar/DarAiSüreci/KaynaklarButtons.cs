using System.Linq;
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
        //print(FindFirstObjectByType<GeliþtirilenYapayZeka>(FindObjectsInactive.Include).gameObject.name);
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


}
