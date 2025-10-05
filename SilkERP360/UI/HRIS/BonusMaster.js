var GBL_TBL_BONUS_LIST;
$(document).ready(function () {

    $("#lnkGetBonusMaster").bind("click", function () { GetBonusMaster(); });

    GBL_TBL_BONUS_LIST = $('#tblBonusList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "auto",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "bSearch": false,
        "aoColumns": [
                    { sTitle: '<b>Employee</b>', sWidth: '28%', sClass: 'alignCenter' },
                    { sTitle: '<b>Designation</b>', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: '<b>Joining Date</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Basic </b>', sWidth: '7%', sClass: 'alignRight' },
                    { sTitle: '<b>H.Rent</b>', sWidth: '7%', sClass: 'alignRight' },
                    { sTitle: '<b>Conveyence</b>', sWidth: '7%', sClass: 'alignRight' },
                    { sTitle: '<b>Medical</b>', sWidth: '7%', sClass: 'alignRight' },
                    { sTitle: '<b>Gross</b>', sWidth: '7%', sClass: 'alignRight' },
                    { sTitle: '<b>Bonus Payable</b>', sWidth: '7%', sClass: 'alignRight' },
                  ]

    });

});

function GetBonusMaster() {
    GBL_TBL_BONUS_LIST.fnClearTable();
    var lcl_ui64_BonusMasterCode = $('#ddlBonusMaster option:selected').val();
    if (lcl_ui64_BonusMasterCode == 0) {
        DisplayInformation("Please Select A Bonus To View The details!!!");
        return;
    }

    // alert("1");
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/BonusService.asmx/GetBonusMasterDetailsByBonusMasterCode";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_BonusMasterCode: " + lcl_ui64_BonusMasterCode + "}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 1) {
            //AtendanceMaster Not Found
            //GBLAttendanceMaster = null;
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            
            var lcl_obj_BonusMaster = lcl_obj_WSResponse.Data;
            var lcl_objLst_BonusList = lcl_obj_BonusMaster.BonusList;
            var lcl_i32_Counter = 0;
            var lcl_objArr_Bonus = new Array();

            $.each(lcl_objLst_BonusList, function (index, lcl_obj_Bonus) {
                lcl_objArr_Bonus[lcl_i32_Counter] = new Array();
                lcl_objArr_Bonus[lcl_i32_Counter][0] = lcl_obj_Bonus.EmployeeName + "(" + lcl_obj_Bonus.EmployeeId + ")";
                lcl_objArr_Bonus[lcl_i32_Counter][1] = lcl_obj_Bonus.Designation;

                var parsedDate = new Date(parseInt(lcl_obj_Bonus.JoiningDate.substr(6)));
                var lcl_obj_JoiningDate = new Date(parsedDate);
                var lcl_str_JoiningDate = $.datepicker.formatDate("dd/MM/yy", lcl_obj_JoiningDate);

                lcl_objArr_Bonus[lcl_i32_Counter][2] = lcl_str_JoiningDate;
                lcl_objArr_Bonus[lcl_i32_Counter][3] = lcl_obj_Bonus.Basic;
                lcl_objArr_Bonus[lcl_i32_Counter][4] = lcl_obj_Bonus.HouseRent;
                lcl_objArr_Bonus[lcl_i32_Counter][5] = lcl_obj_Bonus.Conveyence;
                lcl_objArr_Bonus[lcl_i32_Counter][6] = lcl_obj_Bonus.Medical;
                lcl_objArr_Bonus[lcl_i32_Counter][7] = lcl_obj_Bonus.Gross;
                lcl_objArr_Bonus[lcl_i32_Counter][8] = lcl_obj_Bonus.BonusAmount;
                lcl_i32_Counter++;
            });
            //DisplayLeaveProfile();
            GBL_TBL_BONUS_LIST.fnAddData(lcl_objArr_Bonus);
            GBL_TBL_BONUS_LIST.fnDraw();
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
}