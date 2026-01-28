$(document).ready(function () {

});

function LoadAttandanceBySection() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    if (lcl_str_CompanyCode != '110000000002') {
        DisplayInformation("THIS MODULE IS APPLICABLE ONLY FOR WELLPAC POLYMERS LTD!!!");
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/AttendanceBySection.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadViewAmmendWeekend() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/ViewAmmendWeekend.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadWeekendAllotment() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/WeekendAllotment.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadAttendanceByDesignation() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/AttendanceByDesignation.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


function LoadAttendanceByWorkGroup() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/AttendanceByWorkGroup.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadPFAccountDetails() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/PFAccountDetails.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


function LoadBonusMaster() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/BonusMaster.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}




function LoadIncrementSummery() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/IncrementSummery.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}
function LoadIncrementIOHistory() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/IncrementIOHistory.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadPromotionHistory() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/PromotionHistory.ascx') + "}",
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadTax() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmployeeTax.ascx') + "}",
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadIncrementAndPromotionHistory() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/IncrementAndPromotionList.ascx') + "}",
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadEmployeeIdCardInfo() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmployeeIDCardInfo.ascx') + "}",
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
            }
        });
}

function LoadPFAccountSummery() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/PFAccountSummery.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadSalaryReportPrint() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/SalaryReportPrint.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadSalaryGenerator() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/SalaryGenerator.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadWorkGroupSchedule() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/WorkGroupScheduleProfile.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadAttendanceSummery() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/AttendanceSummery.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


function LoadEmployeeWorkGroupSchedule() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmpWorkGroupSchedule.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadQueryEngine() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/QueryEngine.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadReports() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Reports.ascx') + "}",
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadLeaveManagement() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmpLeaveApp.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

//THIS FILE WILL CONTAIN THE MENU FUNCTIONS FOR THE HRIS SYSTEMS.
function LoadAttendanceReport() {
    alert("a.rep");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Attendance.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/HRReport.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


function LoadLeaveRecommendedList() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            // url: "~/../../../Services/UILoaderService.asmx/GetUI",

            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/LeaveApplicationRecList.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadLeaveApprovedList() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            // url: "~/../../../Services/UILoaderService.asmx/GetUI",

            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/LeaveApplicationList.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}




function LoadPersonnelwiseManagement() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //debugger;
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,


            url: "~/../../../WebServices/UILoaderService.asmx/GetUI",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/PersonnelwiseManagement.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadPersonnelwiseAdministration() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            //url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            url: "~/../../../ebServices/UILoaderService.asmx/GetUI",

            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/PersonnelwiseAdministration.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}
function LoadDepartmentwiseManagement() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,


            //url:  "../WebServices/UILoaderService.asmx/GetUI",
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/DepartmentwiseManagement.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                //debugger;
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadDepartmentwiseAdministration() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/DepartmentwiseAdministration.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                //debugger;
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //alert(lcl_str_ControlHTML);
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }

    
function LoadWorkGroupIP() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/WorkGroupIP.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadWorkGroupScheduleByDateRange() {
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/WorkGroupIPByRange.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadNewLeaveApplication() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewLeaveApplication.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadNewEmployee() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewEmployee.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;
                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

//  javascript: LoadHoliday();


function LoadHoliday() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Holiday.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}



// javascript:LoadDataProcess();


function LoadDataProcess() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Attendance.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

// javascript: LoadAttendanceProcess();

function LoadAttendanceProcess() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }

    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/AttendanceProcess.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

// javascript: LoadAttendanceReport();

function LoadAttendanceReport() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Attendance.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


//  javascript: LoadSalaryReport();

function LoadSalaryReport() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/SalaryReport.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


//  javascript: LoadHRReport();


function LoadHRReport() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/HRReport.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


// javascript:LoadInOut();

function LoadInOut() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/InOut.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {

                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}




//javascript: LoadDepartment();


function LoadDepartment() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Department.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html("");
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

// javascript: LoadDesignation();

function LoadDesignation() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Designation.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {

                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}



// javascript: LoadCompany();

function LoadCompany() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Company.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {

                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


//  javascript: LoadShift();

function LoadShift() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Shift.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {

                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


function LoadModulePermission() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/ModulePermission.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {

                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


//javascript: LoadMenuPermission();


function LoadMenuPermission() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/MenuPermission.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {

                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


function LoadBuyer() {
    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/Buyer.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {

                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}


function LoadRawMaterial() {

    //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    //    if (lcl_ui32_CompanySelectedIndex <= 0) {
    //        //No Company Selected
    //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
    //        return;
    //    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/RawMaterial.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path="~/UI/WPMS/Buyer.ascx" />

            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });

}

function LoadFixed() {

    //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    //    if (lcl_ui32_CompanySelectedIndex <= 0) {
    //        //No Company Selected
    //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
    //        return;
    //    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/Fixed.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });

}

function LoadAttendanceByWorkGroup() {

    //alert("Loading New Leave App");
    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Before Launching the Attendance Process!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    //alert("getting control");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/AttendanceByWorkGroup.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }

    //  javascript: LoadLoadMedicalInfo();

    function LoadMedicalInfo() {

        //alert("Loading New Leave App");
        var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        if (lcl_ui32_CompanySelectedIndex <= 0) {
            //No Company Selected
            DisplayError("A Company Must Be Selected Before Before Launching the Attendance Process!!!");
            return;
        }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        //alert("getting control");
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/MedicalInfo.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",

            success: function (response) {
                var WSResponse = response.d;
                var lcl_i32ResponseCode = WSResponse.ResponseCode;

                if (lcl_i32ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                //$('#dvUIContainer').css('visible', '');
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }

    