$(document).ready(function () {
    LoadAllCompany();

    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
        GBL_EMPLOYEE_LIST_TABLE = $('#tblCompanyList').dataTable({
            "bJQueryUI": false,
            "bFilter": true,
            "bPaginate": true,
            "bLengthChange": false,
            "bSearch": true,
            "oLanguage": {
                "sEmptyTable": "No Company Data Available",
                "sZeroRecords": "No Company Record Found For Your Specified Criteria"
            },
            "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            },
            "aoColumns": [
                { sTitle: 'CompanyCode', sWidth: '9%', sClass: 'alignCenter' },
                { sTitle: 'Name', sWidth: '10%', sClass: 'alignCenter' },
                { sTitle: 'Short Name', sWidth: '5%', sClass: 'alignCenter' },
                { sTitle: 'Address', sWidth: '19%', sClass: 'alignCenter' },
                { sTitle: 'Phone No.', sWidth: '10%', sClass: 'alignCenter' },
                { sTitle: 'Fax No', sWidth: '10%', sClass: 'alignCenter' },
                { sTitle: 'Email', sWidth: '14%', sClass: 'alignCenter' },
                { sTitle: 'Website', sWidth: '14%', sClass: 'alignCenter' },
                {
                    sTitle: 'Action',
                    sWidth: '9%',
                    sClass: 'alignCenter',
                    mRender: function (data, type, full) {
                        return `
                            <button type="button" class="btn btn-sm btn-primary edit-btn" data-companycode="${full[0]}">Edit</button>
                            <button type="button" class="btn btn-sm btn-danger delete-btn ms-1" data-companycode="${full[0]}">Delete</button>`;
                    }
                }
            ]
        });
});


////******************************** SAVE Company  ********************************************////////////

function Save() {
    if (confirm("Are you sure you want to submit this application?") == true) {
        var lcl_b_InputValidated = true;
        $('.input-required').each(function (i, obj) {
            //test
            if ($.trim($(this).val().toString()) == '') {
                $(this).css('background-color', 'red');
                lcl_b_InputValidated = false;
                alert("Fields with red background are mandatory fields.Please input Value!!!");
                return false;
            }
        });
        if (lcl_b_InputValidated == true) {
            var lcl_obj_Company = new Object();
            // debugger;
            if ($('#companyCode').val() !== '') {
                lcl_obj_Company.CompanyCode = parseInt($('#companyCode').val());
                lcl_obj_Company.Name = $("#name").val();
                lcl_obj_Company.CompanyShortName = $("#shortName").val();
                lcl_obj_Company.Address = $("#address").val();
                lcl_obj_Company.PhoneNo = $("#phoneNo").val();
                lcl_obj_Company.FaxNo = $("#faxNo").val();
                lcl_obj_Company.Email = $("#email").val();
                lcl_obj_Company.WebSite = $("#website").val();
            }
            else {
                lcl_obj_Company.Name = $("#txt_CompanyName").val();
                lcl_obj_Company.CompanyShortName = $("#txt_CompShortName").val();
                lcl_obj_Company.Address = $("#txt_CompAddress").val();
                lcl_obj_Company.PhoneNo = $("#txt_CompPhoneNo").val();
                lcl_obj_Company.FaxNo = $("#txt_CompFaxNo").val();
                lcl_obj_Company.Email = $("#txt_Email").val();
                lcl_obj_Company.WebSite = $("#txt_CompWebSite").val();
            }
            $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/CompanyService.asmx/SaveCompany",

                        data: "{IP_Obj_Company:" + JSON.stringify(lcl_obj_Company) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());

                                /// to call the Load Company Data /////////
                                LoadAllCompany();
                                clearFields();
                                return false;
                            }
                            else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function (data) {
                            alert(data);
                            // $.unblockUI();
                        }
                });
            if ($('#companyCode').val() !== '') {
                closeModal();
                clearModalFields('companyModal');
            }
        }
    }
    return false;
}

function Delete(companyCode) {
    if (confirm("Are you sure you want to Delete this data?") == true) {
        var lcl_obj_Company = new Object();
        lcl_obj_Company.CompanyCode = parseInt(companyCode);

        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/CompanyService.asmx/DeleteCompany",
            data: "{IP_Obj_Company:" + JSON.stringify(lcl_obj_Company) + "}", // provide input
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode == 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoadAllCompany(); // reload the table
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


    /*********************************** Load Company Data*******************************/
    function LoadAllCompany() {
        $.ajax(
            {
                async: true,
                type: "POST",
                global: true,
                contentType: "application/json; charset=utf-8",
                url: gbl_URL_Root + "WebServices/HRIS/CompanyService.asmx/GetAllCompany",
                dataType: "json",
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode < 0) {
                        DisplayError(WSReturn.Message);
                        return;
                    }
                    var lcl_obj_CompanyList = WSReturn.Data;
                    var lcl_i32_CompanyCode = 0;

                    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                    var lcl_str_ExtendedAllCompanyData = new Array();

                    $.each(lcl_obj_CompanyList, function (index, lcl_obj_ExtendedAllCompanyData) {
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode] = new Array();
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][0] = lcl_obj_ExtendedAllCompanyData.CompanyCode;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][1] = lcl_obj_ExtendedAllCompanyData.Name;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][2] = lcl_obj_ExtendedAllCompanyData.CompanyShortName;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][3] = lcl_obj_ExtendedAllCompanyData.Address;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][4] = lcl_obj_ExtendedAllCompanyData.PhoneNo;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][5] = lcl_obj_ExtendedAllCompanyData.FaxNo;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][6] = lcl_obj_ExtendedAllCompanyData.Email;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][7] = lcl_obj_ExtendedAllCompanyData.WebSite;
                        lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][8] = '<button class="btn btn-sm btn-primary edit-btn" id="editId_' + lcl_i32_CompanyCode + '">Edit</button>';

                        lcl_i32_CompanyCode++;
                    });
                    GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllCompanyData);
                    GBL_EMPLOYEE_LIST_TABLE.fnDraw();
                }
            });
    }

    $('#tblCompanyList').on('click', '.edit-btn', function () {
        var row = $(this).closest('tr')[0]; // raw DOM element
        var rowData = GBL_EMPLOYEE_LIST_TABLE.fnGetData(row);

        $('#companyCode').val(rowData[0]);
        $('#name').val(rowData[1]);
        $('#shortName').val(rowData[2]);
        $('#address').val(rowData[3]);
        $('#phoneNo').val(rowData[4]);
        $('#faxNo').val(rowData[5]);
        $('#email').val(rowData[6]);
        $('#website').val(rowData[7]);

        $('#companyModal').modal('show');
    });

    $('#tblCompanyList').on('click', '.delete-btn', function () {
        var row = $(this).closest('tr')[0]; // raw DOM element
        var rowData = GBL_EMPLOYEE_LIST_TABLE.fnGetData(row);

        let companyCode = rowData[0];
        Delete(companyCode);
    });

    function clearModalFields(modalId) {
        const modal = document.getElementById(modalId);
        if (!modal) return;

        // Find all input, textarea, select inside the modal
        const fields = modal.querySelectorAll('input, textarea, select');

        fields.forEach(field => {
            const type = field.type;

            switch (type) {
                case 'text':
                case 'email':
                case 'tel':
                case 'url':
                case 'number':
                case 'password':
                case 'hidden':
                case 'search':
                case 'date':
                case 'datetime-local':
                case 'month':
                case 'week':
                case 'time':
                case 'color':
                    field.value = '';
                    break;

                case 'checkbox':
                case 'radio':
                    field.checked = false;
                    break;

                default:
                    if (field.tagName.toLowerCase() === 'textarea') {
                        field.value = '';
                    } else if (field.tagName.toLowerCase() === 'select') {
                        field.selectedIndex = 0;
                    }
                    break;
            }
        });
    }

    function closeModal() {
        $('#companyModal').modal('hide');
}   

function clearFields() {
    $('#dCompany').find('input[type="text"], textarea').val('');
}