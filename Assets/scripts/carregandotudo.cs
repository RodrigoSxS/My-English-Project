
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class carregandotudo : MonoBehaviour
{
    public CartasTips CartaDicas;
    public GameObject canvamenufrases, Canvatips;
    public Text recebetexto;
    public int tempocarregamento;

    void Start()
    {


    
            StartCoroutine("Iniciamenu");
       

        int selcTips;
        selcTips = Random.Range(0, 9);

        if (selcTips == 0)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[0];
        if (selcTips == 1)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[1];
        if (selcTips == 2)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[2];
        if (selcTips == 3)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[3];
        if (selcTips == 4)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[4];
        if (selcTips == 5)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[5];
        if (selcTips == 6)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[6];
        if (selcTips == 7)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[7];
        if (selcTips == 8)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[8];
        if (selcTips == 9)
            recebetexto.GetComponent<Text>().text = CartaDicas.Tips_[9];


    }

    IEnumerator Iniciamenu()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(tempocarregamento);
        canvamenufrases.gameObject.SetActive(true);
        Canvatips.gameObject.SetActive(false);
        
    }
}
