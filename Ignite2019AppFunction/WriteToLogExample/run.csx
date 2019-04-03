#r "Newtonsoft.Json"
#r "SendGrid"
using System;
using SendGrid.Helpers.Mail;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public  static  void  Run(string myQueueItem,  out dynamic outputDocument,out SendGridMessage message,ILogger log)
{
    LogModel log_model = (LogModel) JsonConvert.DeserializeObject<LogModel>(myQueueItem);
    outputDocument = new {  
    id=log_model.id,
    particion =log_model.transaction_name,
    severity=log_model.severity,
    log_date=log_model.log_date,
    nlog_date=log_model.nlog_date
    };
    message=CreateEmail(log_model);
}

private static SendGridMessage CreateEmail(LogModel logModel)
{
    var email = new SendGridMessage();
    if (logModel.severity>7){
    email.AddTo("hassan.arteaga@gmail.com");
    email.AddContent("text/html", $"Alerta!!! Recibimos un evento del Log con las siguientes características:<br/><br/>Severidad: {logModel.severity}<br/>Transacción: {logModel.transaction_name} <br/>Fecha del Evento: {logModel.log_date}");
    email.SetFrom(new EmailAddress("hassan.arteaga@mysuitemex.com"));
    email.SetSubject($"Demo Ignite Tour Mexico 2019. Notificación de Evento de Log con Severidad={logModel.severity}");
    }
    else
    email=null;
    return email;
}

 public class LogModel
    {
        public string id { get; set; }
        public string transaction_name { get; set; }
        public int severity { get; set; }
        public string log_date { get; set; }
        public long nlog_date { get; set; }

    }
