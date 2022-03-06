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
  public void Enviarnotifica�ao(string titulo, string mensagem)
    {
        
        var notification = new AndroidNotification();
        notification.Title = titulo;
        notification.Text = mensagem;
        notification.LargeIcon = "icon_0";
        notification.FireTime = System.DateTime.Now.AddDays(1);
        

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
        
    }
    public void Enviarnotifica�ao12(string titulo, string mensagem)
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
            Enviarnotifica�ao(Application.productName, "Venha estudar um pouco mais de ingl�s");
            Enviarnotifica�ao12(Application.productName, "O sistema de Repeti��o espa�ada � uma das melhores t�cnicas para adquirir vocabul�rio");

        }
    }
}
