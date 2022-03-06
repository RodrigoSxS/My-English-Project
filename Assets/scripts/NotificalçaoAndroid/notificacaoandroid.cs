using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class notificacaoandroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    // Update is called once per frame
  public void Enviarnotificaçao(string titulo, string mensagem)
    {
        
        var notification = new AndroidNotification();
        notification.Title = titulo;
        notification.Text = mensagem;
        notification.LargeIcon = "icon_0";
        notification.FireTime = System.DateTime.Now.AddDays(1);
        

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
        
    }
    public void Enviarnotificaçao12(string titulo, string mensagem)
    {

        var notification = new AndroidNotification();
        notification.Title = titulo;
        notification.Text = mensagem;
        notification.LargeIcon = "icon_0";
        notification.FireTime = System.DateTime.Now.AddHours(12);
        

        AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }


    private void OnApplicationFocus(bool focus)
    {
        if(focus == false)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            Enviarnotificaçao(Application.productName, "Venha estudar um pouco mais de inglês");
            Enviarnotificaçao12(Application.productName, "O sistema de Repetição espaçada é uma das melhores técnicas para adquirir vocabulário");

        }
    }
}
