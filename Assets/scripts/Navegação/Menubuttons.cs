using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menubuttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    public void Delleteallkeys()
    {

        PlayerPrefs.DeleteAll();
    }
    public void Qualcenavai(int numerodobotao) // chama cenas dos grupos de palavra e seciona para qual vai
    {
        if (numerodobotao == 1)
        {
            SceneManager.LoadSceneAsync(1);
        }
        if (numerodobotao == 2)
        {
            SceneManager.LoadSceneAsync(2);
        }

    }
    public void navegação(int numerodobotao) // chama cenas dos grupos de palavra e seciona para qual vai
    {

        SceneManager.LoadSceneAsync(numerodobotao);

    }
}
