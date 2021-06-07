using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;
using UnityEngine.SceneManagement;

public class JUB_Cheatcodes : MonoBehaviour
{
    JUB_Maeve maeve;
    public string nomSceneBoss, nomSceneDonjon;

    Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        controller.Enable();

        controller.Menu.LifePlus.performed += ctx => MoreLife();
        controller.Menu.MoneyPlus.performed += ctx => MoreMoney();
        controller.Menu.Donjon.performed += ctx => GoDonjon();
        controller.Menu.Boss.performed += ctx => GoBoss();
        controller.Menu.TPHome.performed += ctx => Home();

        maeve = GetComponent<JUB_Maeve>();
    }

    void MoreMoney()
    {
        maeve.GainBonbons(100);
    }

    void MoreLife()
    {
        maeve.Heal(maeve.maxLife);
    }

    void GoDonjon()
    {
        SceneManager.LoadScene(nomSceneDonjon);
    }

    void GoBoss()
    {
        SceneManager.LoadScene(nomSceneBoss);
    }

    void Home()
    {
        maeve.transform.position = maeve.actualCheckpoint.position;
    }
}
