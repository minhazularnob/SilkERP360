<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDesigner.aspx.cs" Inherits="SilkERP360.ReportDesigner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
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
            border:1px solid #F8F8F8  ;
        }
        
        .report_header_label
        {
            text-align:left;
            border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #3333FF;
            font-weight:bold;
        }
        
        .report_summery_label
        {
            text-align:right;
            border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #3333FF;
            font-weight:bold;
        }
        
        .report_summery_text
        {
            text-align:left;
            border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #000;
            font-weight:normal;
        }
        
        .report_grid_header
        {
            text-align:center;
             border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #3333FF;
            font-weight:bold;
        }
        .report_body
        {
            width:100%;
            font-size:10px;
             font-family:Arial;
        }
        
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <style type="text/css">
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
            border:1px solid #F8F8F8  ;
        }
        
        .report_header_label
        {
            text-align:left;
            border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #3333FF;
            font-weight:bold;
        }
        
        .report_summery_label
        {
            text-align:right;
            border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #3333FF;
            font-weight:bold;
        }
        
        .report_summery_text
        {
            text-align:left;
            border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #000;
            font-weight:normal;
        }
        
        .report_grid_header
        {
            text-align:center;
                border:1px solid #F8F8F8  ;
            background-color:#FFFFFF;
            color: #3333FF;
            font-weight:bold;
        }
        .report_body
        {
            width:100%;
            font-size:10px;
                font-family:Arial;
        }
    </style>
    <div>
       
        <div id='dvBody' style=' width:100%; border:1px solid gray; font-size:12px; font-family:Arial;'>
            <table id='tblReportHead' class='report_head' style='width:100%;'>
                <tr style=''>    
                    <td class='report_header_label' style='width:10%'>
                        System :
                    </td>
                    <td class='report_header_text'  style='width:90%;'>
                        SilkERP360-Human Resource Information System (H.R.I.S)
                    </td>
                </tr>
                <tr>    
                    <td class='report_header_label'>
                        Report Title : 
                    </td>
                    <td style='text-align:left;'>
                        Daily Attendance Report
                    </td>
                </tr>
                <tr>    
                    <td class='report_header_label'>
                        Report Date
                    </td>
                    <td style='text-align:left;'>
                        Sunday, January 01, 2015
                    </td>
                </tr>
                <tr>    
                    <td class='report_header_label'>
                        Company :
                    </td>
                    <td style='text-align:left;'>
                        Silkways Card & Printing Ltd
                    </td>
                </tr>
            </table>
            <br />
            <table id='tblReportSummer' class='report_summery' style='width:100%; margin:0 auto;'>
                <tr style=''>    
                    <td class='report_summery_label' style='width:13%'>
                        Total Processed :
                    </td>
                    <td class='report_summery_text'  style='width:20%;'>
                        Human Resource Information System (H.R.I.S)
                    </td>
                    <td class='report_summery_label' style='width:13%'>
                        Total Leave :
                    </td>
                    <td class='report_summery_text'  style='width:20%;'>
                        123
                    </td>
                    <td class='report_summery_label' style='width:13%'>
                        Total Holiday :
                    </td>
                    <td class='report_summery_text'  style='width:20%;'>
                        Human Resource Information System (H.R.I.S)
                    </td>
                </tr>
                <tr style=''>    
                    <td class='report_summery_label'>
                        Total Present :
                    </td>
                    <td class='report_summery_text'>
                        Human Resource Information System (H.R.I.S)
                    </td>
                    <td class='report_summery_label'>
                        Total Absent :
                    </td>
                    <td class='report_summery_text'  style='width:20%;'>
                        123
                    </td>
                    <td class='report_summery_label'>
                        Total Holiday :
                    </td>
                    <td class='report_summery_text'  style='width:20%;'>
                        Human Resource Information System (H.R.I.S)
                    </td>
                </tr>
                <tr style=''>    
                    <td class='report_summery_label'>
                        Total Overtime :
                    </td>
                    <td class='report_summery_text'>
                        Human Resource Information System (H.R.I.S)
                    </td>
                    <td class='report_summery_label' style='width:10%'>
                        Man. Hr. Expected :
                    </td>
                    <td class='report_summery_text'>
                        123
                    </td>
                    <td class='report_summery_label'>
                        Man Hr. Served :
                    </td>
                    <td class=''>
                        Human Resource Information System (H.R.I.S)
                    </td>
                </tr>
                <tr style=''>   
                    <td class='report_summery_label' style='width:10%'>
                        Man. Hr. Expected (Non-O.T) :
                    </td>
                    <td class='report_summery_text'>
                        123
                    </td> 
                    <td class='report_summery_label' style='width:10%'>
                        Man Hr. Served (Non-O.T):
                    </td>
                    <td class='report_summery_text'>
                        Human Resource Information System (H.R.I.S)
                    </td>
                    
                </tr>
            </table>
            <br />
            <table id='tblReportGrid' class='report_body'>
                <tr style=''>    
                    <td class='report_grid_header' style='width:5%'>
                        ID
                    </td>
                    <td class='report_grid_header' style='width:25%'>
                        Employee
                    </td>
                    <td class='report_grid_header' style='width:20%'>
                        In
                    </td>
                    <td class='report_grid_header' style='width:20%'>
                        Out
                    </td>
                    <td class='report_grid_header' style='width:5%'>
                        D.Hour
                    </td>
                    <td class='report_grid_header' style='width:5%'>
                        O.T (A)
                    </td>
                    <td class='report_grid_header' style='width:5%'>
                        O.T
                    </td>
                    <td class='report_grid_header' style='width:5%'>
                        Status
                    </td>
                 </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
