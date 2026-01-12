$(document).ready(function () {
    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    //    var GBL_EMPLOYEE_LIST_TABLE = $('#tblDepartmentList').dataTable({
    //        "bJQueryUI": true,
    //        "sScrollY": "400px",
    //        "bFilter": true,
    //        "bPaginate": false,
    //        "bLengthChange": false,
    //        "aoColumns": [
    //                    { sTitle: 'Department', sWidth: '60%', sClass: 'alignCenter' },
    //                    { sTitle: 'Strength', sWidth: '35%', sClass: 'alignCenter' },
    //                    { sTitle: 'Action', sWidth: '5%', sClass: 'alignCenter' }
    //                  ]

    //    });

    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    //    //Context Menu Setup
    $("#switcher").themeswitcher({
        jqueryuiversion: "1",        
        imgpath: "~/../../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/images/",
        loadTheme: "Cupertino"
    });

    /* Menu 1: init by passing an array of entries. */

    $(document).contextmenu({
        delegate: ".ctx_mnu",
        preventSelect: true,
        taphold: true,
        show: { effect: "fadeIn", duration: "slow" },
        hide: { effect: "fadeOut", duration: "fast" },
        width: "400px",
        menu: [
			{ title: "New Rooster", cmd: "NewRooster", uiIcon: "", action: function (event, ui) {
			    var lcl_ui64_DepartmentCode = ui.target.attr('id');
			    alert(lcl_ui64_DepartmentCode);
			}
			}
			],
        // Implement the beforeOpen callback to dynamically change the entries
        beforeOpen: function (event, ui) {
            var $menu = ui.menu,

				$target = ui.target;
            $(document)
            //				.contextmenu("replaceMenu", [{title: "aaa"}, {title: "bbb"}])
            //				.contextmenu("replaceMenu", "#options2")
            //				.contextmenu("setEntry", "cut", {title: "Cuty", uiIcon: "ui-icon-heart", disabled: true})
                .contextmenu("setEntry", "NewLeaveApp", "New Leave Application...")
				.contextmenu("setEntry", "NewAttnEntry", "New Attendance Entry...")
				.contextmenu("enableEntry", "NewAddDed", "New Addition Deduction...");

            // Optionally return false, to prevent opening the menu now
        }
    });

    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
});