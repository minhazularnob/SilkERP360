using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
namespace PIMS.Codes
{
    public class PIMSMailer
    {
        private void SendMailMessage(string IP_str_From, string[] IP_str_To, string[] IP_str_Bcc, string[] IP_str_Cc, string IP_str_Subject, string IP_str_Body)
        {
            // Instantiate a new instance of MailMessage
            System.Net.Mail.MailMessage mMailMessage = new System.Net.Mail.MailMessage();

            // Set the sender address of the mail message
            mMailMessage.From = new System.Net.Mail.MailAddress(IP_str_From,"Silkways Job Master v.1.0");
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
                mMailMessage.From = new System.Net.Mail.MailAddress(IP_str_From, "Silkways Job Master v.1.0");
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

                mMailMessage.Subject = IP_str_Subject;
                // Set the body of the mail message
                mMailMessage.Body = IP_str_Body;

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;
                // Set the priority of the mail message to normal
                mMailMessage.Priority = System.Net.Mail.MailPriority.High;

                // Instantiate a new instance of SmtpClient
                System.Net.Mail.SmtpClient mSmtpClient = new System.Net.Mail.SmtpClient();
                //mSmtpClient.
                // Send the mail message

                mSmtpClient.Host = "192.168.49.11";// "192.168.49.11";// "mail.silkways.net";
                mSmtpClient.Port = 25;
                mSmtpClient.Send(mMailMessage);
                PIMS.Codes.DebugErrorLog.LogError("Mail Sent Successfully");
            }
            catch (System.Exception Ex)
            {
                PIMS.Codes.DebugErrorLog.LogError(Ex.Message);
            }
            
        }

        public void Send_P_O_Mail(PIMS.Codes.P_O IP_obj_P_O, DataAccessLayer.DBManager IP_obj_DBManager,System.Data.OracleClient.OracleTransaction IP_obj_Transaction)
        {
            try
            {
                /****************************************************************************************************************************************************/
                //SEND P_O NOTIFICATION MAIL
                System.UInt64 lcl_ui64_TotalSimQuantity = 0;
                System.Text.StringBuilder lcl_obj_MailBody = new System.Text.StringBuilder();
                lcl_obj_MailBody.Append("<center><b><u>NEW PURCHASE ORDER (P.O) FOR SIM</u></b></center><br/>");
                lcl_obj_MailBody.Append("<b>Telco :</b>" + PIMS.Codes.Customer.getCustomerNameFromCode(IP_obj_P_O.CustomerCode, IP_obj_DBManager, IP_obj_Transaction) + "<br/>");
                lcl_obj_MailBody.Append("<b>P.O Number :</b>" + IP_obj_P_O.P_O_Number + "<br/>");
                lcl_obj_MailBody.Append("<br/><br/>");
                lcl_obj_MailBody.Append("<center><table cellspacing='2px' style='width:100%;border:1px;border-color:#000000;border-style:solid;'><caption style='background-color:#0167af;color:#ffffff'><b>P.O (SIM) DETAILS</b></caption><tr><td align='center'  style='width:75%;border:1px;border-style:solid;background-color:#95c615;'><b>Item</b></td><td align='center' style='width:90%;border:1px;border-style:solid;background-color:#95c615;'><b>Quantity</b></td></tr>");
                for (System.Int32 j = 0; j < IP_obj_P_O.SM_P_O.SM_P_O_DET.Length; j++)
                {
                    lcl_obj_MailBody.Append("<tr><td align='center' style='width:75%;border:1px;border-style:solid;'>" + PIMS.Codes.SMProduct.getProductNameFromCode(IP_obj_P_O.SM_P_O.SM_P_O_DET[j].ProductCode, IP_obj_DBManager, IP_obj_Transaction) + "("+ IP_obj_P_O.SM_P_O.SM_P_O_DET[j].HLR + ")" + "</td>");
                    lcl_obj_MailBody.Append("<td align='right' style='width:25%;border:1px;border-style:solid;'>" + IP_obj_P_O.SM_P_O.SM_P_O_DET[j].Quantity.ToString() + "</td></tr>");
                    lcl_ui64_TotalSimQuantity += (System.UInt64)IP_obj_P_O.SM_P_O.SM_P_O_DET[j].Quantity;
                }
                //add the total quantity field
                lcl_obj_MailBody.Append("<tr><td align='right' style='width:75%;border:1px;border-style:solid;'><b>Grand Total :</b></td>");
                lcl_obj_MailBody.Append("<td align='right' style='width:25%;border:1px;border-style:solid;'><b>" + lcl_ui64_TotalSimQuantity.ToString() + "</b></td></tr>");
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //lcl_obj_MailBody.Append("</table></center><br/><b>N.B:</b>This mail is automatically generated from Silkways Job Master (SJM) v.1.0");
                lcl_obj_MailBody.Append("</table></center><br/><b><i>N.B:This mail is automatically generated from Silkways Job Master (SJM) v.1.0.Please Do not reply to this email.</i></b>");
                //lcl_obj_MailBody.Append("</table>");
                System.Collections.Generic.List<System.String> lcl_lst_Mail_TO = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_CC = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_BCC = new System.Collections.Generic.List<System.String>();
                System.String lcl_str_Query = System.String.Format("SELECT * FROM p_o_mail_list WHERE status = 1");
                System.Data.OracleClient.OracleDataReader lcl_obj_MailingListReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_Query);
                while (lcl_obj_MailingListReader.Read())
                {
                    if (lcl_obj_MailingListReader.HasRows)
                    {
                        if (lcl_obj_MailingListReader.GetInt32(1) == 1)
                        {
                            //this email is in TO list
                            System.String lcl_str_Mail_TO = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_TO.Add(lcl_str_Mail_TO);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(2) == 1)
                        {
                            //this email is in CC list
                            System.String lcl_str_Mail_CC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_CC.Add(lcl_str_Mail_CC);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(3) == 1)
                        {
                            //this email is in BCC list
                            System.String lcl_str_Mail_BCC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_BCC.Add(lcl_str_Mail_BCC);
                        }
                    }

                }

                this.SendMailMessage("sjm@silkways.net", lcl_lst_Mail_TO, lcl_lst_Mail_CC, lcl_lst_Mail_BCC, "New P.O (SIM)", lcl_obj_MailBody.ToString());

                /****************************************************************************************************************************************************/
            }
            catch (System.Exception Ex1)
            {
                throw new System.Exception("Automated P.O notification could not be sent due to problem with the mailing system!!!");
            }
        }

        public void Send_P_O_Complete_Mail(System.String IP_str_P_O_C, DataAccessLayer.DBManager IP_obj_DBManager, System.Data.OracleClient.OracleTransaction IP_obj_Transaction)
        {
            try
            {
                //get P.O Summery reports
                PIMS.Codes.Report_Classes.Report_P_O_Summery.P_O_Summery lcl_obj_p_o_summery = new PIMS.Codes.Report_Classes.Report_P_O_Summery.P_O_Summery();
                lcl_obj_p_o_summery.getDetails(IP_str_P_O_C);
                /****************************************************************************************************************************************************/
                //SEND P_O NOTIFICATION MAIL
                System.Text.StringBuilder lcl_obj_MailBody = new System.Text.StringBuilder();
                //lcl_obj_MailBody.Append("<center><b><u>NEW PURCHASE ORDER (P.O) FOR SIM</u></b></center><br/>");
                lcl_obj_MailBody.Append("<p>Dear Concern,<br/> Please be informed that the following P.O (SIM) has been Completed.<br/></p>");
                lcl_obj_MailBody.Append("<b>Telco :</b>" + lcl_obj_p_o_summery.CustomerName + "<br/>");
                lcl_obj_MailBody.Append("<b>P.O Number :</b>" + lcl_obj_p_o_summery.P_O_Number + "<br/>");
                lcl_obj_MailBody.Append("<br/><br/>");
                lcl_obj_MailBody.Append("<center><table cellspacing='2px' style='width:100%;border:1px;border-color:#000000;border-style:solid;'><caption style='background-color:#0167af;color:#ffffff'><b>P.O (SIM) DETAILS</b></caption><tr><td align='center'  style='width:75%;border:1px;border-style:solid;background-color:#95c615;'><b>Item</b></td><td align='center' style='width:90%;border:1px;border-style:solid;background-color:#95c615;'><b>Quantity</b></td></tr>");
                for (System.Int32 j = 0; j < lcl_obj_p_o_summery.ReportSummeryDetailList.Count; j++)
                {
                    lcl_obj_MailBody.Append("<tr><td align='center' style='width:75%;border:1px;border-style:solid;'>" + lcl_obj_p_o_summery.ReportSummeryDetailList[j].ProductName + "</td>");
                    lcl_obj_MailBody.Append("<td align='center' style='width:25%;border:1px;border-style:solid;'>" + lcl_obj_p_o_summery.ReportSummeryDetailList[j].OrderedQuantity.ToString() + "</td></tr>");
                }
                //lcl_obj_MailBody.Append("</table></center><br/><b>N.B:</b>This mail is automatically generated from Silkways Job Master (SJM) v.1.0");
                lcl_obj_MailBody.Append("</table></center><br/><b><i>N.B:This mail is automatically generated from Silkways Job Master (SJM) v.1.0.Please Do not reply to this email.</i></b>");
                //lcl_obj_MailBody.Append("</table>");
                System.Collections.Generic.List<System.String> lcl_lst_Mail_TO = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_CC = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_BCC = new System.Collections.Generic.List<System.String>();
                System.String lcl_str_Query = System.String.Format("SELECT * FROM p_o_complete_mail_list WHERE status = 1");
                System.Data.OracleClient.OracleDataReader lcl_obj_MailingListReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_Query);
                while (lcl_obj_MailingListReader.Read())
                {
                    if (lcl_obj_MailingListReader.HasRows)
                    {
                        if (lcl_obj_MailingListReader.GetInt32(1) == 1)
                        {
                            //this email is in TO list
                            System.String lcl_str_Mail_TO = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_TO.Add(lcl_str_Mail_TO);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(2) == 1)
                        {
                            //this email is in CC list
                            System.String lcl_str_Mail_CC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_CC.Add(lcl_str_Mail_CC);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(3) == 1)
                        {
                            //this email is in BCC list
                            System.String lcl_str_Mail_BCC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_BCC.Add(lcl_str_Mail_BCC);
                        }
                    }

                }

                this.SendMailMessage("sjm@silkways.net", lcl_lst_Mail_TO, lcl_lst_Mail_CC, lcl_lst_Mail_BCC, "P.O Completion Notification", lcl_obj_MailBody.ToString());

                /****************************************************************************************************************************************************/
            }
            catch (System.Exception Ex1)
            {
                throw new System.Exception("Automated P.O notification could not be sent due to problem with the mailing system!!!");
            }
        }


        public void Send_SM_J_O_Mail(PIMS.Codes.J_O IP_obj_J_O, DataAccessLayer.DBManager IP_obj_DBManager, System.Data.OracleClient.OracleTransaction IP_obj_Transaction)
        {
            try
            {
                /****************************************************************************************************************************************************/
                //SEND P_O NOTIFICATION MAIL
                System.Text.StringBuilder lcl_obj_MailBody = new System.Text.StringBuilder();
                lcl_obj_MailBody.Append("<center><b><u>NEW JOB ORDER (J.O) FOR SIM</u></b></center><br/>");
                lcl_obj_MailBody.Append("<b>Telco :</b>" + PIMS.Codes.Customer.getCustomerNameFromCode(IP_obj_J_O.CustomerCode, IP_obj_DBManager, IP_obj_Transaction) + "<br/>");
                lcl_obj_MailBody.Append("<b>J.O Number :</b>" + IP_obj_J_O.SM_J_O.J_O_Number + "<br/>");
                lcl_obj_MailBody.Append("<b>P.O Ref :</b>" + PIMS.Codes.P_O.getP_O_Num_From_P_O_C(IP_obj_J_O.P_O_C,IP_obj_DBManager,IP_obj_Transaction) + "<br/>");
                lcl_obj_MailBody.Append("<br/><br/>");
                lcl_obj_MailBody.Append("<center><table cellspacing='2px' style='width:100%;border:1px;border-color:#000000;border-style:solid;'><caption style='background-color:#0167af;color:#ffffff'><b>J.O (SIM) DETAILS</b></caption><tr><td align='center'  style='width:50%;border:1px;border-style:solid;background-color:#95c615;'><b>Item</b></td><td align='center' style='width:25%;border:1px;border-style:solid;background-color:#95c615;'><b>Quantity</b></td><td align='center' style='width:25%;border:1px;border-style:solid;background-color:#95c615;'><b>Del. Date</b></td></tr>");
                for (System.Int32 j = 0; j < IP_obj_J_O.SM_J_O.SM_J_O_DET.Length; j++)
                {
                    lcl_obj_MailBody.Append("<tr><td align='center' style='width:50%;border:1px;border-style:solid;'>" + PIMS.Codes.SMProduct.getProductNameFromCode(IP_obj_J_O.SM_J_O.SM_J_O_DET[j].ProductCode, IP_obj_DBManager, IP_obj_Transaction) + " (" + IP_obj_J_O.SM_J_O.SM_J_O_DET[j].HLR + " )" + "</td>");
                    lcl_obj_MailBody.Append("<td align='center' style='width:25%;border:1px;border-style:solid;'>" + IP_obj_J_O.SM_J_O.SM_J_O_DET[j].Quantity.ToString() + "</td>");
                    lcl_obj_MailBody.Append("<td align='center' style='width:25%;border:1px;border-style:solid;'>" + IP_obj_J_O.SM_J_O.SM_J_O_DET[j].DeliveryDate.ToString() + "</td></tr>");
                }
                lcl_obj_MailBody.Append("</table></center><br/><b><i>N.B:This mail is automatically generated from Silkways Job Master (SJM) v.1.0.Please Do not reply to this email.</i></b>");
                //lcl_obj_MailBody.Append("</table>");
                System.Collections.Generic.List<System.String> lcl_lst_Mail_TO = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_CC = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_BCC = new System.Collections.Generic.List<System.String>();
                System.String lcl_str_Query = System.String.Format("SELECT * FROM j_o_mail_list WHERE status = 1");
                System.Data.OracleClient.OracleDataReader lcl_obj_MailingListReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_Query);
                while (lcl_obj_MailingListReader.Read())
                {
                    if (lcl_obj_MailingListReader.HasRows)
                    {
                        if (lcl_obj_MailingListReader.GetInt32(1) == 1)
                        {
                            //this email is in TO list
                            System.String lcl_str_Mail_TO = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_TO.Add(lcl_str_Mail_TO);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(2) == 1)
                        {
                            //this email is in CC list
                            System.String lcl_str_Mail_CC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_CC.Add(lcl_str_Mail_CC);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(3) == 1)
                        {
                            //this email is in BCC list
                            System.String lcl_str_Mail_BCC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_BCC.Add(lcl_str_Mail_BCC);
                        }
                    }

                }

                this.SendMailMessage("sjm@silkways.net", lcl_lst_Mail_TO, lcl_lst_Mail_CC, lcl_lst_Mail_BCC, "New J.O (SIM)", lcl_obj_MailBody.ToString());

                /****************************************************************************************************************************************************/
            }
            catch (System.Exception Ex1)
            {
                throw new System.Exception("Automated J.O notification could not be sent due to problem with the mailing system!!!");
            }
        }

        public void SendDeliveryNotificationMail(PIMS.Codes.SM_ISO_DELIVERY IP_obj_SM_ISO_DELIVERY, DataAccessLayer.DBManager IP_obj_DBManager, System.Data.OracleClient.OracleTransaction IP_obj_Transaction)
        {
            try
            {
                /****************************************************************************************************************************************************/
                //SEND P_O NOTIFICATION MAIL
                System.Text.StringBuilder lcl_obj_MailBody = new System.Text.StringBuilder();
                lcl_obj_MailBody.Append("<p>Dear Concern,<br/> Please be informed that the following Item was delivered today.<br/><br/></p>");
                lcl_obj_MailBody.Append("<b>Telco :</b>" + PIMS.Codes.Customer.getCustomerNameFromCode(IP_obj_SM_ISO_DELIVERY.CustomerCode, IP_obj_DBManager, IP_obj_Transaction) + "<br/>");
                //lcl_obj_MailBody.Append("<b>J.O Number :</b>" + IP_obj_J_O.SM_J_O.J_O_Number + "<br/>");
                lcl_obj_MailBody.Append("<b>P.O Ref :</b>" + IP_obj_SM_ISO_DELIVERY.POCode + "<br/>");
                lcl_obj_MailBody.Append("<br/><br/>");
                lcl_obj_MailBody.Append("<center><table cellspacing='2px' style='width:100%;border:1px;border-color:#000000;border-style:solid;'><caption style='background-color:#0167af;color:#ffffff'><b>Delivered SIM</b></caption><tr><td align='center'  style='width:50%;border:1px;border-style:solid;background-color:#95c615;'><b>Item</b></td><td align='center' style='width:25%;border:1px;border-style:solid;background-color:#95c615;'><b>Quantity</b></td><td align='center' style='width:25%;border:1px;border-style:solid;background-color:#95c615;'><b>Del. Date</b></td></tr>");
                ///////////Get delivered Project Code///////////////////////////////////////////////
                System.String lcl_str_DBQuery = System.String.Format("SELECT smjodet.Prdt_c,smjodet.HLR from SM_J_O_DET smjodet JOIN SM_Projects smp " +
                                                                     "on smjodet.SM_J_O_DET_C = smp.SM_J_O_DET_C WHERE smp.prj_c = {0}", IP_obj_SM_ISO_DELIVERY.ProjectCode);
                System.Data.OracleClient.OracleDataReader lcl_obj_sm_j_o_det_reader = IP_obj_DBManager.ExecuteDataReader(lcl_str_DBQuery);
                lcl_obj_sm_j_o_det_reader.Read();
                PIMS.Codes.SMProduct lcl_obj_Product = new PIMS.Codes.SMProduct();
                lcl_obj_Product.Init();
                System.String lcl_str_ProductName = lcl_obj_Product.getProductNameFromCode(lcl_obj_sm_j_o_det_reader["prdt_c"].ToString()) + " (" + lcl_obj_sm_j_o_det_reader["hlr"].ToString() + ")";
                lcl_obj_sm_j_o_det_reader.Close();
                ////////////////////////////////////////////////////////////////////////////////////
                
                lcl_obj_MailBody.Append("<tr><td align='center' style='width:50%;border:1px;border-style:solid;'>" + lcl_str_ProductName + "</td>");
                lcl_obj_MailBody.Append("<td align='center' style='width:25%;border:1px;border-style:solid;'>" + IP_obj_SM_ISO_DELIVERY.Quantity.ToString() + "</td>");
                lcl_obj_MailBody.Append("<td align='center' style='width:25%;border:1px;border-style:solid;'>" + IP_obj_SM_ISO_DELIVERY.DeliveryDate + "</td></tr>");
                
                //lcl_obj_MailBody.Append("</table></center><br/><b>N.B:</b>This mail is automatically generated from Silkways Job Master (SJM) v.1.0");
                lcl_obj_MailBody.Append("</table></center><br/><b><i>N.B:This mail is automatically generated from Silkways Job Master (SJM) v.1.0.Please Do not reply to this email.</i></b>");
                //lcl_obj_MailBody.Append("</table>");
                System.Collections.Generic.List<System.String> lcl_lst_Mail_TO = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_CC = new System.Collections.Generic.List<System.String>();
                System.Collections.Generic.List<System.String> lcl_lst_Mail_BCC = new System.Collections.Generic.List<System.String>();
                System.String lcl_str_Query = System.String.Format("SELECT * FROM DELIVERY_MAIL_LIST WHERE status = 1");
                System.Data.OracleClient.OracleDataReader lcl_obj_MailingListReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_Query);
                while (lcl_obj_MailingListReader.Read())
                {
                    if (lcl_obj_MailingListReader.HasRows)
                    {
                        if (lcl_obj_MailingListReader.GetInt32(1) == 1)
                        {
                            //this email is in TO list
                            System.String lcl_str_Mail_TO = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_TO.Add(lcl_str_Mail_TO);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(2) == 1)
                        {
                            //this email is in CC list
                            System.String lcl_str_Mail_CC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_CC.Add(lcl_str_Mail_CC);
                        }
                        if (lcl_obj_MailingListReader.GetInt32(3) == 1)
                        {
                            //this email is in BCC list
                            System.String lcl_str_Mail_BCC = lcl_obj_MailingListReader.GetString(0);
                            lcl_lst_Mail_BCC.Add(lcl_str_Mail_BCC);
                        }
                    }

                }

                this.SendMailMessage("sjm@silkways.net", lcl_lst_Mail_TO, lcl_lst_Mail_CC, lcl_lst_Mail_BCC, "SIM Delivery Notification", lcl_obj_MailBody.ToString());

                /****************************************************************************************************************************************************/
            }
            catch (System.Exception Ex1)
            {
                throw new System.Exception("Automated Delivery notification could not be sent due to problem with the mailing system!!!");
            }
        }
    }
}