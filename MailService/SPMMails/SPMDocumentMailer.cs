using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailService.SPMMails
{
    /// <summary>
    /// Mails PurchaseOrders,JobOrders related documents
    /// for SIM,SC & BankCard
    /// </summary>
    public class SPMDocumentMailer : MailService.Mailer
    {
        public void MailSCPurchaseOrder(System.UInt64 IP_ui64_SCPurchaseOrderCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
        }
    }
}
