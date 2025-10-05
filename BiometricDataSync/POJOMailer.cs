using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    public class POJOMailer
    {
        public System.String GetPOHtml()
        {
            try
            {
                System.String lcl_str_HTMLReport = "";
                //SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                //lcl_obj_CompanyManager.Initialize();
                ////this.m_obj_DBManager.Open();
                //SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = lcl_obj_CompanyManager.Get(IP_ui64_CompanyCode, this.m_obj_DBManager);

                /***********************************************************************************************************************/
                //AutoBot Remarks


                lcl_str_HTMLReport = @"<style type='text/css'>
        .report_head
        {
            width:100%;
            font-size:12px;
        }
        
        .report_head tr
        {
            
        }
        
        .report_head tr td
        {
            border:1px solid #cccccc  ;
        }
        
        .report_header_label
        {
            text-align:left;
            /*border:1px solid #F8F8F8  ;*/
            font-weight:bold;
            font-family:Verdana;
            color: #ffffff;
            background-color:#66cc33;
            border:1px solid #cccccc;

        }

        .report_header_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;

        }

        
        .report_summery_label
        {
            text-align:right;
            color: #ffffff;
            background-color:#66cc33;
            font-weight:bold;
            border:1px solid #cccccc;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_summery_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_grid_text
        {
            text-align:center;
             border:1px solid #cccccc  ;
            background-color:#FFFFFF;
            color: #000;
            font-weight:normal;
            font-family:Verdana;
        }
        .report_grid_header
        {
            line-height:25px;
            text-align:center;
             border:1px solid #F8F8F8  ;
            background-color:#3399FF;
            color: #ffffff;
            font-weight:bold;
            font-size:14px;
            border:1px solid black;
            font-family:Verdana;
        }
        .report_body
        {
            width:100%;
            font-size:10px;
             font-family:Verdana;
            
        }
        
    </style>";

                lcl_str_HTMLReport += System.String.Format(@"
                                                            <div>
                                                                <div id='dvBody' style=' width:100%; border:1px solid gray; font-size:12px; font-family:Arial;'>
                                                                    <table id='tblReportHead' class='report_head' style='width:100%;'>
                                                                        <tr style=''>    
                                                                            <td class='report_header_label' style='width:25%'>
                                                                                System :
                                                                            </td>
                                                                            <td class='report_header_text'  style='width:75%;'>
                                                                                Production Management System (P.M.S)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Title : 
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                                Purchase Order (Scratch Card)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                               P.O Date
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                                {0}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Customer :
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            Grameen Phone Ltd.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id='tblReportSummer' class='report_summery' style='width:100%; margin:0 auto;'>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                P.O No :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                300008676
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                P.O Issue Date :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                August 13, 2015
                                                                            </td>
                                                                        </tr>
                                                                        </table>", System.DateTime.Today.ToLongDateString());
                lcl_str_HTMLReport += @"<br />
                                        <table id='GridTableStyle' class='report_body'>
                                            <tr style=''>    
                                                <td class='report_grid_header' style='width:5%'>
                                                    SL
                                                </td>
                                                <td class='report_grid_header' style='width:30%'>
                                                    Item
                                                </td>
                                                <td class='report_grid_header' style='width:15%'>
                                                    Delivery Date
                                                </td>
                                                <td class='report_grid_header' style='width:10%'>
                                                    Quantity
                                                </td>
                                                <td class='report_grid_header' style='width:20%'>
                                                    Remarks
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class='report_grid_text' style=''>
                                                    01
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    50 Tk. Scratch Card 4 in 1
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    September 30, 2015
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    3100000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    M.Unit: Piece
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class='report_grid_text' style=''>
                                                    02
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    20 Tk. Scratch Card 5 in 1
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    September 30, 2015
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    22000000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    M.Unit: Piece
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class='report_grid_text' style=''>
                                                    03
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    10 Tk. Scratch Card 5 in 1
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    September 30, 2015
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    15000000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    M.Unit: Piece
                                                </td>
                                            </tr>";
                lcl_str_HTMLReport += "</table></div></div>";
                return lcl_str_HTMLReport;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.String GetJOHtml()
        {
            try
            {
                System.String lcl_str_HTMLReport = "";
                //SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                //lcl_obj_CompanyManager.Initialize();
                ////this.m_obj_DBManager.Open();
                //SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = lcl_obj_CompanyManager.Get(IP_ui64_CompanyCode, this.m_obj_DBManager);

                /***********************************************************************************************************************/
                //AutoBot Remarks


                lcl_str_HTMLReport = @"<style type='text/css'>
        .report_head
        {
            width:100%;
            font-size:12px;
        }
        
        .report_head tr
        {
            
        }
        
        .report_head tr td
        {
            border:1px solid #cccccc  ;
        }
        
        .report_header_label
        {
            text-align:left;
            /*border:1px solid #F8F8F8  ;*/
            font-weight:bold;
            font-family:Verdana;
            color: #ffffff;
            background-color:#66cc33;
            border:1px solid #cccccc;

        }

        .report_header_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;

        }

        
        .report_summery_label
        {
            text-align:right;
            color: #ffffff;
            background-color:#66cc33;
            font-weight:bold;
            border:1px solid #cccccc;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_summery_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_grid_text
        {
            text-align:center;
             border:1px solid #cccccc  ;
            background-color:#FFFFFF;
            color: #000;
            font-weight:normal;
            font-family:Verdana;
        }
        .report_grid_header
        {
            line-height:25px;
            text-align:center;
             border:1px solid #F8F8F8  ;
            background-color:#3399FF;
            color: #ffffff;
            font-weight:bold;
            font-size:14px;
            border:1px solid black;
            font-family:Verdana;
        }
        .report_body
        {
            width:100%;
            font-size:10px;
             font-family:Verdana;
            
        }
        
    </style>";

                lcl_str_HTMLReport += System.String.Format(@"
                                                            <div>
                                                                <div id='dvBody' style=' width:100%; border:1px solid gray; font-size:12px; font-family:Arial;'>
                                                                    <table id='tblReportHead' class='report_head' style='width:100%;'>
                                                                        <tr style=''>    
                                                                            <td class='report_header_label' style='width:25%'>
                                                                                System :
                                                                            </td>
                                                                            <td class='report_header_text'  style='width:75%;'>
                                                                                SilkERP360-Production Management System (P.M.S)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Title : 
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                                Job Order (Scratch Card)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                               J.O Date
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                                {0}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Customer :
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            Grameen Phone Ltd.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id='tblReportSummer' class='report_summery' style='width:100%; margin:0 auto;'>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                J.O No :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                02SCGPSC0615
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                J.O Issue Date :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                August 18, 2015
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Validity
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                30-09-2015
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Ref. P.O
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                300008676
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Paper
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                300 gsm
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Design
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                As approved before
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Version
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                01/15
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Expiry Date :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                31/12/2019
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                HRN Cover :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                Label
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Overprint
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                Yes
                                                                            </td>
                                                                            <td colspan='2' class='report_summery_label' style='width:25%'>
                                                                                Packaging As per Customer Spec.
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Packaging 4x1
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                Inner Box = 1250 | Outer Box : 6250
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Packaging 5x1
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:25%;'>
                                                                                Inner Box = 1000 | Outer Box : 5000
                                                                            </td>
                                                                        </tr>
                                                                        </table>", System.DateTime.Today.ToLongDateString());
                lcl_str_HTMLReport += @"<br />
                                        <table id='GridTableStyle' class='report_body'>
                                            <tr style=''>    
                                                <td class='report_grid_header' style='width:5%'>
                                                    SL
                                                </td>
                                                <td class='report_grid_header' style='width:30%'>
                                                    Item
                                                </td>
                                                <td class='report_grid_header' style='width:15%'>
                                                    D.Date
                                                </td>
                                                <td class='report_grid_header' style='width:10%'>
                                                    Quantity (PIN)
                                                </td>
                                                <td class='report_grid_header' style='width:10%'>
                                                    Quantity (Card)
                                                </td>
                                                <td class='report_grid_header' style='width:10%'>
                                                    Remarks
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class='report_grid_text' style=''>
                                                    01
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    50 Tk. Scratch Card 4 in 1
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    September 30, 2015
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    3100000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    775000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    M.Unit: Piece
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class='report_grid_text' style=''>
                                                    02
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    20 Tk. Scratch Card 5 in 1
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    September 30, 2015
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    22000000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    4400000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    M.Unit: Piece
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class='report_grid_text' style=''>
                                                    03
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    10 Tk. Scratch Card 5 in 1
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    September 30, 2015
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    15000000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    3000000
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    M.Unit: Piece
                                                </td>
                                            </tr>";
                lcl_str_HTMLReport += "</table></div></div>";
                return lcl_str_HTMLReport;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
