var GBL_EMPLOYEE_LIST_TABLE;
var CLIPBOARD = "";

$(document).ready(function () {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    $('#ddlDepartment').change(function () { DepartmentChangeEvent(); });
    initializeSelect2('ddlDepartment', '', '50%');

    GBL_EMPLOYEE_LIST_TABLE = $('#tblEmployeeList').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "oLanguage": {
            "sEmptyTable": "No Data Available",
            "sZeroRecords": "No Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        "aoColumns": [
            { sTitle: '<b>Image</b>', sWidth: '7%', sClass: 'alignCenter' },
            { sTitle: '<b>Emp. Id</b>', sWidth: '13%', sClass: 'alignCenter' },
            { sTitle: '<b>Name</b>', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: '<b>Desgn.</b>', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: '<b>Salary.</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>J. Date</b>', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: '<b>Action</b>', sWidth: '10%', sClass: 'alignCenter', sType: "html" }
        ]
    });

    $("#switcher").themeswitcher({
        jqueryuiversion: "1",
        imgpath: "~/../../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/images/",
        loadTheme: "Cupertino"
    });

    $(document).contextmenu({
        delegate: ".ctx_mnu",
        preventSelect: true,
        taphold: true,
        show: { effect: "fadeIn", duration: "slow" },
        hide: { effect: "fadeOut", duration: "fast" },
        width: "400px",
        menu: [
            {
                title: "New Leave Application", cmd: "NewLeaveApp", uiIcon: "",
                action: function (event, ui) {
                    var lcl_ui64_EmployeeCode = ui.target.data('empcode');
                    $('#hdrSubForm').text('Leave Application');

                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployee",
                        data: "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewLeaveApplication.ascx') + "}",
                        dataType: "json",
                        success: function (response) {
                            var WSResponse = response.d;
                            if (WSResponse.ResponseCode < 0) {
                                DisplayError(WSResponse.Message);
                                return;
                            }
                            $('#dvSubFormContainer').html(WSResponse.Data);
                            $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        }
                    });
                }
            },
            {
                title: "Salary Addition/Deduction", cmd: "SalaryAdditionORdeduction", uiIcon: "",
                action: function (event, ui) {
                    var lcl_ui64_EmployeeCode = ui.target.data('empcode');
                    $('#hdrSubForm').text('Salary Addition/deduction').addClass('fontSerif');;

                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployee",
                        data: "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/SalaryAdditionDeduction.ascx') + "}",
                        dataType: "json",
                        success: function (response) {
                            var WSResponse = response.d;
                            if (WSResponse.ResponseCode < 0) {
                                DisplayError(WSResponse.Message);
                                return;
                            }
                            $('#dvSubFormContainer').html(WSResponse.Data);
                            $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        }
                    });
                }
            },
            {
                title: "Employee Edit", cmd: "EmployeeEdit", uiIcon: "",
                action: function (event, ui) {
                    var lcl_ui64_EmployeeCode = ui.target.data('empcode');
                    $('#hdrSubForm').text('Employee Edit').addClass('fontSerif');;

                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployeeComp",
                        data: "{ IP_ui64_CompanyCode:" + lcl_ui64_CompanyCode + ",IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmployeeEdit.ascx') + "}",
                        dataType: "json",
                        success: function (response) {
                            var WSResponse = response.d;
                            if (WSResponse.ResponseCode < 0) {
                                DisplayError(WSResponse.Message);
                                return;
                            }
                            $('#dvSubFormContainer').html(WSResponse.Data);
                            $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        }
                    });
                }
            },
            {
                title: "Change Employee Status", cmd: "ChangeEmployeeStatus", uiIcon: "",
                action: function (event, ui) {
                    var lcl_ui64_EmployeeCode = ui.target.data('empcode');
                    $('#hdrSubForm').text('Change Employee Status');

                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployeeComp",
                        data: "{ IP_ui64_CompanyCode:" + lcl_ui64_CompanyCode + ",IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmployeeStatusChange.ascx') + "}",
                        dataType: "json",
                        success: function (response) {
                            var WSResponse = response.d;
                            if (WSResponse.ResponseCode < 0) {
                                DisplayError(WSResponse.Message);
                                return;
                            }
                            $('#dvSubFormContainer').html(WSResponse.Data);
                            $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        }
                    });
                }
            }
        ],
        beforeOpen: function (event, ui) {
            var $menu = ui.menu,
                $target = ui.target;
            $(document)
                .contextmenu("setEntry", "NewLeaveApp", "New Leave Application...")
                .contextmenu("setEntry", "NewAttnEntry", "New Attendance Entry...")
                .contextmenu("enableEntry", "NewAddDed", "New Addition Deduction...");
        }
    });
});


function DepartmentChangeEvent() {
    var lcl_str_DepartmentCode = $.trim($('#ddlDepartment option:selected').val());
    if (lcl_str_DepartmentCode == "0") return;

    var lcl_str_CompanyCode = $("#ddlCompany option:selected").val();
    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();

    $.ajax({
        async: true,
        type: "POST",
        global: true,
        contentType: "application/json; charset=utf-8",
        url: "~/../../../WebServices/HRIS/EmployeeService.asmx/GetAvailableEmployeeProfileListByDepartment",
        data: "{IP_ui64_DepartmentCode:" + JSON.stringify(lcl_str_DepartmentCode) + "}",
        dataType: "json",
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) { DisplayError(WSReturn.Message); return; }

            var lcl_obj_EmployeeProfileList = WSReturn.Data;
            var lcl_i32_EmployeeNumber = 0;
            var lcl_str_EmployeeData = new Array();

            $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfile) {
                var lcl_str_EmployeeImage = "data:" + lcl_obj_EmployeeProfile.Image.ImageType + ";base64," + lcl_obj_EmployeeProfile.Image.ImageData;
                lcl_str_EmployeeData[lcl_i32_EmployeeNumber] = new Array();

                lcl_str_EmployeeData[lcl_i32_EmployeeNumber][0] = "<img id='imgEmployee-" + lcl_i32_EmployeeNumber.toString() + "' src='" + lcl_str_EmployeeImage + "' width='30px' height='30px'/>";
                lcl_str_EmployeeData[lcl_i32_EmployeeNumber][1] = lcl_obj_EmployeeProfile.EmployeeID;
                lcl_str_EmployeeData[lcl_i32_EmployeeNumber][2] = lcl_obj_EmployeeProfile.EmployeeName;
                lcl_str_EmployeeData[lcl_i32_EmployeeNumber][3] = lcl_obj_EmployeeProfile.Designation.Name;
                lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = lcl_obj_EmployeeProfile.Salary + ".00";

                var parsedDate = new Date(parseInt(lcl_obj_EmployeeProfile.JoiningDate.substr(6)));
                var lcl_obj_JoiningDate = new Date(parsedDate);
                lcl_str_EmployeeData[lcl_i32_EmployeeNumber][5] = $.datepicker.formatDate("dd/MM/yy", lcl_obj_JoiningDate);

                lcl_str_EmployeeData[lcl_i32_EmployeeNumber][6] =   
                    "<a id='hlnkContextMenu-" + lcl_i32_EmployeeNumber.toString() + "' " +
                    "rel='hlnkContextMenu" + lcl_i32_EmployeeNumber.toString() + "' " +
                    "class='btn btn-light btn-sm ctx_mnu' " +
                    "data-empcode='" + lcl_obj_EmployeeProfile.EmployeeCode.toString() + "' " +
                    "href='#'>⋮</a>";

                lcl_i32_EmployeeNumber++;
            });

            GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_EmployeeData);
        }
    });
}

$(document).on('click', '.ctx_mnu', function (e) {
    e.preventDefault();
    var evt = $.Event('contextmenu', {
        pageX: e.pageX,
        pageY: e.pageY,
        target: this
    });
    $(document).trigger(evt);
});
