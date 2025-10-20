using UnityEngine;
using UnityEngine.UI;
using static GelenİşlerEkranı;

public class YapımSüreci : MonoBehaviour
{
    public GameObject[] Paneller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonrakiPaneleGeç(GameObject SonrakiPanel)
    {
        for (int i = 0; i < Paneller.Length; i++)
        {
            if(Paneller[i] == SonrakiPanel)
            {
                Paneller[i].gameObject.SetActive(true);
            }
            else
            {
                Paneller[i].gameObject.SetActive(false);
            }
        }
    }

    public void KontratıYapmayaBaşla()
    {
        print("Fonksiyon tetiklendi ama içi boş");

        for (int i = 0; i < Paneller.Length; i++)
        {
        Paneller[i].gameObject.SetActive(false);
        }
    }
}
