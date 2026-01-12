$(document).ready(function () {

    $("#txt_DegEffectiveFrom").datepicker({ dateFormat: 'dd/MM/yy', minDate: -15, maxDate: 0 });
    $("#txt_DegEffectiveFromModal").datepicker({ dateFormat: 'dd/MM/yy', minDate: -15, maxDate: 0 });

    ////// Gross Declaretion //////
    $('#txt_DegGross').blur(function () { GrossSalaryChangeCommon(false); });
    $('#txt_DegGrossModal').blur(function () { GrossSalaryChangeCommon(true); });

    LoadAllDesignation();
   
    GBL_DESIGNATION_LIST_TABLE = $('#tblDesignationList').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "oLanguage": {
            "sEmptyTable": "No Designation Data Available",
            "sZeroRecords": "No Designation Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        "aoColumns": [
            { sTitle: 'Des. Name', sWidth: '7%', sClass: 'alignCenter' },
            { sTitle: 'Short Name', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: 'Gross', sWidth: '9%', sClass: 'alignCenter' },
            { sTitle: 'Effective From', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: 'Basic', sWidth: '8%', sClass: 'alignCenter' },
            { sTitle: 'Medical', sWidth: '8%', sClass: 'alignCenter' },
            { sTitle: 'Entertaiment', sWidth: '8%', sClass: 'alignCenter' },
            { sTitle: 'Conveyence', sWidth: '8%', sClass: 'alignCenter' },
            { sTitle: 'House Rent', sWidth: '8%', sClass: 'alignCenter' },
            { sTitle: 'Phone Bill', sWidth: '8%', sClass: 'alignCenter' },
            { sTitle: 'Others', sWidth: '10%', sClass: 'alignCenter' },
            {
                sTitle: 'Action',
                sWidth: '10%',
                sClass: 'alignCenter',
                mRender: function (data, type, full) {
                    return `
                    <button type="button" class="btn btn-sm btn-primary edit-btn" data-companycode="${full[0]}">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button type="button" class="btn btn-sm btn-danger delete-btn ms-1" data-companycode="${full[0]}">
                        <i class="fas fa-trash"></i>
                    </button>`;
                }
            },
            { sTitle: 'Designation Id', sWidth: '10%', sClass: 'alignCenter', bVisible: false },

        ]

    });

});

function LoadAllDesignation() {
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax(
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DesignationService.asmx/GetAllDesignation",
            data: "{IP_ui64_companyCode: " + JSON.stringify(lcl_str_CompanyCode) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_DesignationList = WSReturn.Data;
                var lcl_i32_DesignationCode = 0;

                GBL_DESIGNATION_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAllDesignationData = new Array();

                $.each(lcl_obj_DesignationList, function (index, lcl_obj_ExtendedAllDesignationData) {
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode] = new Array();
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][0] = lcl_obj_ExtendedAllDesignationData.DegnName;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][1] = lcl_obj_ExtendedAllDesignationData.ShortName;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][2] = lcl_obj_ExtendedAllDesignationData.Gross;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][3] = FormatDate(lcl_obj_ExtendedAllDesignationData.EffectiveFrom);
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][4] = lcl_obj_ExtendedAllDesignationData.Basic;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][5] = lcl_obj_ExtendedAllDesignationData.Medical;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][6] = lcl_obj_ExtendedAllDesignationData.Entertainment;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][7] = lcl_obj_ExtendedAllDesignationData.Conveyence;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][8] = lcl_obj_ExtendedAllDesignationData.HouseRent;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][9] = lcl_obj_ExtendedAllDesignationData.PhoneBill;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][10] = lcl_obj_ExtendedAllDesignationData.Others;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][11] = '<button class="btn btn-sm btn-primary edit-btn" id="editId_' + lcl_i32_DesignationCode + '">Edit</button>';
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][12] = lcl_obj_ExtendedAllDesignationData.DesignationCode;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][13] = lcl_obj_ExtendedAllDesignationData.CompanyCode;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][14] = lcl_obj_ExtendedAllDesignationData.Status;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][15] = lcl_obj_ExtendedAllDesignationData.IsOtEligible;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][16] = lcl_obj_ExtendedAllDesignationData.Rank;
                    lcl_i32_DesignationCode++;
                });
                GBL_DESIGNATION_LIST_TABLE.fnAddData(lcl_str_ExtendedAllDesignationData);
                GBL_DESIGNATION_LIST_TABLE.fnDraw();
            }
        });
}

function SaveDesignation() {
    var lcl_obj_Designation = new Object();

    lcl_obj_Designation.CompanyCode = $('#ddlCompany option:selected').val();
    lcl_obj_Designation.DegnName = $("#txt_DesName").val();
    lcl_obj_Designation.ShortName = $("#txt_DesShortName").val();
    lcl_obj_Designation.Conveyence = $("#txt_DegConveyence").val();
    lcl_obj_Designation.Basic = $("#txt_DegBasic").val();
    lcl_obj_Designation.HouseRent = $("#txt_houseRent").val();
    lcl_obj_Designation.Medical = $("#txt_DegMedical").val();
    lcl_obj_Designation.Entertainment = $("#txt_DegEntertaiment").val();
    lcl_obj_Designation.PhoneBill = $("#txt_DegPhoneBill").val();
    lcl_obj_Designation.Others = $("#txt_DegOthers").val();
    lcl_obj_Designation.Gross = $("#txt_DegGross").val();
    lcl_obj_Designation.EffectiveFrom = $("#txt_DegEffectiveFrom").val();
    lcl_obj_Designation.Rank = $("#txt_degRank").val();

    var validateObj = {
        CompanyCode: lcl_obj_Designation.CompanyCode,
        DegnName: lcl_obj_Designation.DegnName,
        Conveyence: lcl_obj_Designation.Conveyence,
        Basic: lcl_obj_Designation.Basic,
        HouseRent: lcl_obj_Designation.HouseRent,
        Medical: lcl_obj_Designation.Medical,
        Entertainment: lcl_obj_Designation.Entertainment,
        PhoneBill: lcl_obj_Designation.PhoneBill,
        Others: lcl_obj_Designation.Others,
        Gross: lcl_obj_Designation.Gross,
        EffectiveFrom: lcl_obj_Designation.EffectiveFrom,
        Rank: lcl_obj_Designation.Rank
    };

    var validationMessage = validateFields(validateObj);
    if (validationMessage !== 'OK') {
        DisplayError(validationMessage.toString());
        return false;
    }

    if (confirm("Are you sure you want to submit this application?") == true) {
        $.ajax(
            {

                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: gbl_URL_Root + "WebServices/HRIS/DesignationService.asmx/SaveDesignation",
                data: "{IP_Obj_Designation:" + JSON.stringify(lcl_obj_Designation) + "}",
                dataType: "json", /// <reference path= />
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode == 0) {

                        DisplayInformation(WSReturn.Message.toString());
                        LoadAllDesignation()
                        return false;
                    }
                    else {
                        DisplayError(WSReturn.Message.toString());
                    }
                },
                error: function (data) {
                    alert(data);
                }
            });
    }
    return false;
}

function UpdateDesignation() {
    var lcl_obj_Designation = new Object();


    lcl_obj_Designation.EffectiveFrom = $("#txt_DegEffectiveFromModal").val();
    lcl_obj_Designation.DesignationCode = $('#txt_DesIdModal').val();
    lcl_obj_Designation.CompanyCode = $('#comIdModal').val();
    lcl_obj_Designation.DegnName = $("#txt_DesNameModal").val();
    lcl_obj_Designation.ShortName = $("#txt_DesShortNameModal").val();
    lcl_obj_Designation.Gross = $("#txt_DegGrossModal").val();
    lcl_obj_Designation.EffectiveFrom = formatDateToLongMonth($("#txt_DegEffectiveFromModal").val());
    lcl_obj_Designation.Basic = $("#txt_DegBasicModal").val();
    lcl_obj_Designation.Medical = $("#txt_DegMedicalModal").val();
    lcl_obj_Designation.Entertainment = $("#txt_DegEntertaimentModal").val();
    lcl_obj_Designation.Conveyence = $("#txt_DegConveyenceModal").val();
    lcl_obj_Designation.HouseRent = $("#txt_houseRentModal").val();
    lcl_obj_Designation.PhoneBill = $("#txt_DegPhoneBillModal").val();
    lcl_obj_Designation.Others = $("#txt_DegOthersModal").val();
    lcl_obj_Designation.Status = $("#degStatusModal").val();
    lcl_obj_Designation.IsOtEligible = $("#isOtEligibleModal").val();
    lcl_obj_Designation.Rank = $("#degRankModal").val();



    var validateObj = {
        DesignationCode: lcl_obj_Designation.DesignationCode,
        CompanyCode: lcl_obj_Designation.CompanyCode,
        DegnName: lcl_obj_Designation.DegnName,
        Gross: lcl_obj_Designation.Gross,
        EffectiveFrom: lcl_obj_Designation.EffectiveFrom,
        Basic: lcl_obj_Designation.Basic,
        Medical: lcl_obj_Designation.Medical,
        Entertainment: lcl_obj_Designation.Entertainment,
        Conveyence: lcl_obj_Designation.Conveyence,
        HouseRent: lcl_obj_Designation.HouseRent,
        PhoneBill: lcl_obj_Designation.PhoneBill,
        Others: lcl_obj_Designation.Others,
        Status: lcl_obj_Designation.Status,
        IsOtEligible: lcl_obj_Designation.IsOtEligible,
        Rank: lcl_obj_Designation.Rank
    };

    var validationMessage = validateFields(validateObj);
    if (validationMessage !== 'OK') {
        DisplayError(validationMessage.toString());
        return false;
    }

    debugger;
    if (confirm("Are you sure you want to update this designation?") === true) {
        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DesignationService.asmx/UpdateDesignation",
            data: "{IP_Obj_Designation:" + JSON.stringify(lcl_obj_Designation) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode === 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoadAllDesignation();
                    closeModal();
                    clearModalFields('designationModal');
                    return false;
                } else {
                    DisplayError(WSReturn.Message.toString());
                }
            },
            error: function (data) {
                alert(data);
            }
        });
    }


    return false;
}

function deleteDesignation(designationCode) {
    if (confirm("Are you sure you want to Delete this data?") == true) {
        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DesignationService.asmx/DeleteDesignation",
            data: "{IP_Ui64_designationCode: " + JSON.stringify(designationCode) + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode == 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoadAllDesignation();
                    return false;
                } else {
                    DisplayError(WSReturn.Message.toString());
                }
            },
            error: function (data) {
                alert(data);
            }
        });
        return false;
    }
}

$('#tblDesignationList').on('click', '.edit-btn', function () {
    var row = $(this).closest('tr')[0]; // raw DOM element
    var rowData = GBL_DESIGNATION_LIST_TABLE.fnGetData(row);

    initializeSelect2('comIdModal', '', '20%', '#designationModal');
    initializeSelect2('degStatusModal', '', '20%', '#designationModal');
    initializeSelect2('isOtEligibleModal', '', '20%', '#designationModal');


    var companies = [];
    companies = getAllCompany();

    $('#txt_DesIdModal').val(rowData[12]);
    $('#txt_DesNameModal').val(rowData[0]);
    $('#txt_DesShortNameModal').val(rowData[1]);
    $('#txt_DegGrossModal').val(rowData[2]);
    $('#txt_DegEffectiveFromModal').val(rowData[3]);
    $('#txt_DegBasicModal').val(rowData[4]);
    $('#txt_DegMedicalModal').val(rowData[5]);
    $('#txt_DegEntertaimentModal').val(rowData[6]);
    $('#txt_DegConveyenceModal').val(rowData[7]);
    $('#txt_houseRentModal').val(rowData[8]);
    $('#txt_DegPhoneBillModal').val(rowData[9]);
    $('#txt_DegOthersModal').val(rowData[10]);
    $('#degRankModal').val(rowData[16]);

    $.each(companies, function (index, company) {
        var $option = $('<option></option>').val(company.CompanyCode).text(company.Name);

        if (company.CompanyCode === rowData[13]) {
            $option.prop('selected', true);
        }
        $('#comIdModal').append($option);
    });


    if (rowData[15] == 1) {
        $('#isOtEligibleModal').val('1'); // Select "Yes"
    } else if (value == 0) {
        $('#isOtEligibleModal').val('0'); // Select "No"
    }
    $('#designationModal').modal('show');
});

$('#tblDesignationList').on('click', '.delete-btn', function () {
    var row = $(this).closest('tr')[0];
    var rowData = GBL_DESIGNATION_LIST_TABLE.fnGetData(row);

    let designationCode = rowData[12];
    deleteDesignation(designationCode);
});

function GrossSalaryChangeCommon(isModal = false) {
    // Determine the suffix for modal vs normal
    var suffix = isModal ? "Modal" : "";

    // Get Gross Salary field ID dynamically
    var grossInput = $("#txt_DegGross" + suffix);
    var lcl_str_GrossSalary = $.trim(grossInput.val().toString());

    if (lcl_str_GrossSalary === '') {
        $(".salary_field").val('0.00');
        $(".gross_salary").val('0.00');
        return false;
    }

    $(".salary_field").val('0.00');
    lcl_str_GrossSalary = lcl_str_GrossSalary.replace(',', '');
    var lcl_flt_GrossSalary = parseFloat(lcl_str_GrossSalary);

    if (isNaN(lcl_flt_GrossSalary) || lcl_flt_GrossSalary === 0) {
        $(".salary_field").val('0.00');
        $(".gross_salary").val('0.00');
        return false;
    }

    // Calculate salary components
    var lcl_flt_Basic = (lcl_flt_GrossSalary * 60) / 100;
    var lcl_flt_HouseRent = (lcl_flt_GrossSalary * 30) / 100;
    var lcl_flt_Medical = (lcl_flt_GrossSalary * 5) / 100;
    var lcl_flt_Conveyence = (lcl_flt_GrossSalary * 5) / 100;

    // Set calculated values
    $("#txt_DegBasic" + suffix).val(lcl_flt_Basic.toFixed(2));
    $("#txt_houseRent" + suffix).val(lcl_flt_HouseRent.toFixed(2));
    $("#txt_DegMedical" + suffix).val(lcl_flt_Medical.toFixed(2));
    $("#txt_DegConveyence" + suffix).val(lcl_flt_Conveyence.toFixed(2));

    // Optional fixed fields
    $('#txt_DegEntertaiment' + suffix).val(0);
    $('#txt_DegPhoneBill' + suffix).val(0);
    $('#txt_DegOthers' + suffix).val(0);
}

function clearFields() {
    $('#designationWrapper').find('input[type="text"], textarea').val('');
    $('#designationWrapper').find('input[type="number"], textarea').val(null);
}

function closeModal() {
    $('#designationModal').modal('hide');
}

function FormatDate(jsonDate) {
    var date = new Date(parseInt(jsonDate.substr(6)))
    var d = date.getDate(), m = date.getMonth() + 1, y;
    if (date.getFullYear) { y = date.getFullYear(); }
    else { y = 2000 + (date.getYear() % 100); }
    return (10 > d ? '0' : '') + d + (10 > m ? '-0' : '-') + m + '-' + y;
}

function formatDateToLongMonth(dateStr) {
    if (!dateStr || !/^\d{2}-\d{2}-\d{4}$/.test(dateStr)) {
        console.warn("Invalid date format:", dateStr);
        return dateStr; // return original if not valid
    }

    const [day, month, year] = dateStr.split("-");
    const monthNames = [
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];

    const monthIndex = parseInt(month, 10) - 1;
    const monthName = monthNames[monthIndex] || "";

    return `${day}/${monthName}/${year}`;
}

$(document).ready(function () {
    $('#designationModal').on('shown.bs.modal', function () {
        $('#comIdModal, #degStatusModal, #isOtEligibleModal').select2({
            dropdownParent: $('#designationModal')
        });
    });
});