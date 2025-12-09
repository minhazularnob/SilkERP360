using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;

    namespace SilkERP360.FL.WPMS
    {

        public class Mailer
        {
            
               #region
        protected List<String> m_lst_CC;

        protected List<String> m_lst_BCC;
        #endregion

        #region
        public List<String> CC
        {
            get { return m_lst_CC; }
            set { this.m_lst_CC = value; }
        }

        public List<String> BCC
        {
            get { return m_lst_BCC; }
            set { this.m_lst_BCC = value; }
        }
        
        #endregion

        public Mailer()
        {
            this.CC = new List<String>();
        this.BCC = new List<String>();
        //this.CC.Add("amitav.sc@silkways.net");
        //this.CC.Add("manik@silkways.net");
        
        }
            
            private void SendMailMessage(string IP_str_From, string[] IP_str_To, string[] IP_str_Bcc, string[] IP_str_Cc, string IP_str_Subject, string IP_str_Body)
            {
                // Instantiate a new instance of MailMessage
                
                
                
                System.Net.Mail.MailMessage mMailMessage = new System.Net.Mail.MailMessage();

                // Set the sender address of the mail message
                mMailMessage.From = new System.Net.Mail.MailAddress(IP_str_From, "Silkways Job Master v.1.0");
                // Set the recepient address of the mail message
                for (System.Int32 i = 0; i < IP_str_To.Length; i++)
                {
                    mMailMessage.To.Add(new System.Net.Mail.MailAddress(IP_str_To[i]));
                }

                // Check if the bcc value is null or an empty string
                if (IP_str_Bcc != null)
                {
                    // Set the Bcc address of the mail message
                    for (System.Int32 j = 0; j < IP_str_Bcc.Length; j++)
                    {
                        if (IP_str_Bcc[j] != System.String.Empty)
                        {
                            mMailMessage.Bcc.Add(new System.Net.Mail.MailAddress(IP_str_Bcc[j]));
                        }      // Check if the cc value is null or an empty value
                    }
                }
                if (IP_str_Cc != null)
                {
                    for (System.Int32 k = 0; k < IP_str_Cc.Length; k++)
                    {
                        if (IP_str_Cc[k] != System.String.Empty)
                        {
                            // Set the CC address of the mail message
                            mMailMessage.CC.Add(new System.Net.Mail.MailAddress(IP_str_Cc[k]));
                        }
                    }
                }       // Set the subject of the mail message
                mMailMessage.Subject = IP_str_Subject;
                // Set the body of the mail message
                mMailMessage.Body = IP_str_Body;

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;
                // Set the priority of the mail message to normal
                mMailMessage.Priority = System.Net.Mail.MailPriority.High;

                // Instantiate a new instance of SmtpClient
                System.Net.Mail.SmtpClient mSmtpClient = new System.Net.Mail.SmtpClient();
                // Send the mail message
                mSmtpClient.Send(mMailMessage);
            }

            private void SendMailMessage(string IP_str_From, System.Collections.Generic.List<System.String> IP_str_lst_TO, System.Collections.Generic.List<System.String> IP_str_lst_CC, System.Collections.Generic.List<System.String> IP_str_lst_BCC, string IP_str_Subject, string IP_str_Body)
        {
            try
            {
                // Instantiate a new instance of MailMessage
                System.Net.Mail.MailMessage mMailMessage = new System.Net.Mail.MailMessage();

                // Set the sender address of the mail message
                mMailMessage.From = new System.Net.Mail.MailAddress("info@apps.silkways.net", "Wellpac Polymers Limited");
                // Set the recepient address of the mail message
                foreach (System.String lcl_str_TO in IP_str_lst_TO)
                {
                    mMailMessage.To.Add(new System.Net.Mail.MailAddress(lcl_str_TO));
                }

                foreach (System.String lcl_str_CC in IP_str_lst_CC)
                {
                    mMailMessage.CC.Add(new System.Net.Mail.MailAddress(lcl_str_CC));
                }

                foreach (System.String lcl_str_BCC in IP_str_lst_BCC)
                {
                    mMailMessage.Bcc.Add(new System.Net.Mail.MailAddress(lcl_str_BCC));
                }

                mMailMessage.Subject = "Price Quotation";
                // Set the body of the mail message
                mMailMessage.Body = "Test";

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;
                // Set the priority of the mail message to normal
                mMailMessage.Priority = System.Net.Mail.MailPriority.High;

                // Instantiate a new instance of SmtpClient
                System.Net.Mail.SmtpClient mSmtpClient = new System.Net.Mail.SmtpClient();
                //mSmtpClient.
                // Send the mail message

                mSmtpClient.Host = "192.168.200.3";// "192.168.49.11";// "mail.silkways.net";
                mSmtpClient.Port = 25;
                mSmtpClient.Send(mMailMessage);
               
            }
            catch (System.Exception Ex)
            {
               
            }
            
        }

            //public void Send_P_O_Mail(SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation)
            //{
            //    SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            //    System.String lcl_str_SqlQueryBuyerName = System.String.Empty;
            //    lcl_str_SqlQueryBuyerName = System.String.Format("select Company_Name from wpms_buyer where buyer_code='" + lcl_obj_Quotation.BuyerCode + "'", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            //    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReaderBuyerName = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryBuyerName);

            //    lcl_obj_WorkGroupReaderBuyerName.Read();
               

         
            //    System.String lcl_str_SqlQueryContactPerson = System.String.Empty;
            //    lcl_str_SqlQueryContactPerson = System.String.Format("select CONTACT_PERSON from wpms_buyer where buyer_code='" + lcl_obj_Quotation.BuyerCode + "'", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            //    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReaderContactperson = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryContactPerson);

            //    lcl_obj_WorkGroupReaderContactperson.Read();
               

            //    System.String lcl_str_SqlQueryEmail = System.String.Empty;
            //    lcl_str_SqlQueryEmail = System.String.Format("select Email from wpms_buyer where buyer_code='" + lcl_obj_Quotation.BuyerCode + "'", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            //    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReaderEmail = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryEmail);

            //    lcl_obj_WorkGroupReaderEmail.Read();
                

            //    System.String lcl_str_SqlQueryAddress = System.String.Empty;
            //    lcl_str_SqlQueryAddress = System.String.Format("select ADDRESS from wpms_buyer where buyer_code='" + lcl_obj_Quotation.BuyerCode + "'", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            //    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReaderAddress = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryAddress);

            //    lcl_obj_WorkGroupReaderAddress.Read();
              
                

            //                        /****************************************************************************************************************************************************/
            //        //SEND P_O NOTIFICATION MAIL
            //    System.String lcl_obj_MailBody;
            //    lcl_obj_MailBody = "<div align=center style=width:100%>" + "<h1 style=color:#066A75>" + "Wellpac Polymers Limited" + "</h1>" + "</div>" +
                    
            //        "<div>" + "Company Name : " + lcl_obj_WorkGroupReaderBuyerName["Company_Name"].ToString() +
            //        "<div>" + "Contact Person : " + lcl_obj_WorkGroupReaderContactperson["CONTACT_PERSON"].ToString() +
            //        "<div>" + "Email : " + lcl_obj_WorkGroupReaderEmail["EMAIL"].ToString() +
            //        "<div>" + "Address : " + lcl_obj_WorkGroupReaderAddress["ADDRESS"].ToString() +"<br/>"+
            //        "<div align=center>" +
            //      "<table border=1 style=width:100%" +
            //           "<tr>" +
            //           "<th style=color:#003300>" +
            //           "Item No" +
            //           "</th>" +
            //           "<th style=color:#003300>" +
            //           "Description" +
            //           "</th>" +
            //           "<th style=color:#003300>" +
            //           "Quantity" +
            //           "</th>" +
            //           "<th style=color:#003300>" +
            //           "FOB Unit price" +
            //           "</th>" +
            //           "<th style=color:#003300>" +
            //           "Total Amount " +
            //           "</th>" +
            //           "</tr>";

            //        foreach (SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_Quotationkend in lcl_obj_Quotation.QuotationDetails)
            //        {
            //            lcl_obj_MailBody+="<tr>" +"<td align=center>" + lcl_obj_Quotationkend.Itemno +

            //                  "</td>" +

            //                  "<td>" +
            //                  "Product ref " + lcl_obj_Quotationkend.ProductRef + "<br/>" + lcl_obj_Quotationkend.ProductCode + "<br/>" + lcl_obj_Quotationkend.ProductDesc + "<br/>" + " Size : " +
            //                  "( " + lcl_obj_Quotationkend.ProductSize + " + " + lcl_obj_Quotationkend.Gusset + ")" + " x " + lcl_obj_Quotationkend.Length + " CM, " + lcl_obj_Quotationkend.Thickness + " Micron" + "<br/>" + "Per Carton " + lcl_obj_Quotationkend.PcsPerCarton +
            //                  "<br/>" + lcl_obj_Quotationkend.PPB + " pcs/block." + "<br>" + lcl_obj_Quotationkend.BPC + " block/Carton." +
            //                  "</td>" +
            //                  "<td>" +
            //                  "Total Quantity " + lcl_obj_Quotationkend.Quantity + "<br/>" + " Total Carton " + lcl_obj_Quotationkend.Carton + "<br/>" + " Total Weight " + lcl_obj_Quotationkend.Weight + " kgs" +
            //                                        "</td>" +

            //                  "<td align=right>" +
            //                 " USD " + lcl_obj_Quotationkend.UnitPriceCifFos + "/1000 pcs" +
            //                  "</td>" +
            //                  "<td align=right>" +
            //                  "USD " + lcl_obj_Quotationkend.TotalAmountCifFos +
            //                  "</td>" +
            //                  "</tr>";

            //        }

            //        lcl_obj_MailBody+="</table>" + "<br/>" + "<br/>";
            //        lcl_obj_MailBody+="<table style=width:50%>" + "<tr>" + "<td>" + "Authorized Signature:" + "</td>" + "<td>" + "Accepted by:" + "</td>" + "</tr>" + "</table>";

                
            //                    //this email is in TO list
            //                    //System.String lcl_str_Mail_TO = lcl_obj_Quotation.GetString(0);
            //                    //cl_lst_Mail_TO.Add(lcl_str_Mail_TO);
              
            //        System.String str_To = "safaet.ss@silkways.net";

            //     System.Net.Mail.MailMessage mMailMessage = new System.Net.Mail.MailMessage();
            //     System.Net.Mail.SmtpClient mSmtpClient = new System.Net.Mail.SmtpClient();
                
               
            //     mMailMessage.From = new System.Net.Mail.MailAddress("info@apps.silkways.net", "Wellpac Polymers Limited");
            //     mMailMessage.To.Add(str_To);
            //     mMailMessage.Subject = "Quotation";
            //     mMailMessage.Body = lcl_obj_MailBody.ToString();
            //     mMailMessage.IsBodyHtml = true;
            //     foreach (System.String str_CC in this.CC)
            //        {
            //                    //this email is in CC list
            //            mMailMessage.CC.Add(str_CC);
                                
            //        }
            //                    //this email is in BCC list

            //     foreach (System.String str_BCC in this.BCC)
            //     {
            //         //this email is in CC list
            //         mMailMessage.Bcc.Add(str_BCC);

            //     }

            //     try
            //     {
            //         mSmtpClient.Host = "192.168.200.3";// "192.168.49.11";// "mail.silkways.net";
            //         mSmtpClient.Port = 25;
            //         mSmtpClient.Send(mMailMessage);
            //     }
            //     catch (System.Exception e1)
            //     {
            //         throw e1;
            //     }
            // }
         }
    }
