using UnityEngine;
using UnityEngine.UI;

public class showlinks : MonoBehaviour
{
    [SerializeField]Canvas C_avaliação, C_principal;
    int Iniciouapp_contagem,verificabool = 0;
    bool jaavaliou = false;

    private void Start()
    {
        verificabool = PlayerPrefs.GetInt("Verificaçãoboo");
        if (verificabool ==1)
        {
            jaavaliou = true;
        }
        if(!jaavaliou)
        {
            Iniciouapp_contagem = PlayerPrefs.GetInt("contagementrouapp");
            contagemesalvamento();
        }
    }
    // Start is called before the first frame update
    public void showapppage()//quando o usuario clica em avaliar abre o link (pagina do app na goodle play)
    {
        usuarioavaliou();
       Application.OpenURL("https://play.google.com/store/apps/details?id=com.PercTechnology.MyEnglishProject");
        
    }
    void contagemesalvamento()
    {
        Iniciouapp_contagem++;
        PlayerPrefs.SetInt("contagementrouapp", Iniciouapp_contagem);
        verificaçãodepedidodeavaliação();
    }
    void salvaposcancelamento()
    {
        PlayerPrefs.SetInt("contagementrouapp", Iniciouapp_contagem);
    }
    void verificaçãodepedidodeavaliação()
    {
        int VerificaçãoQuant = 4; // essa variavel define quantas vezes o usuario terá que entrar no app antes de pedir para que ele avalie o app;
        if (Iniciouapp_contagem >= VerificaçãoQuant)
        {
            C_avaliação.gameObject.SetActive(true);
            C_principal.gameObject.SetActive(false);
            
        }
    }

    public void usuariocancelou()
    {
        C_avaliação.gameObject.SetActive(false);
        C_principal.gameObject.SetActive(true);
     
        Iniciouapp_contagem = 0;
        salvaposcancelamento();
    }
    void usuarioavaliou()
    {
        C_avaliação.gameObject.SetActive(false);
        C_principal.gameObject.SetActive(true);
        verificabool = 1;
        PlayerPrefs.SetInt("Verificaçãoboo", verificabool);
    }
}
