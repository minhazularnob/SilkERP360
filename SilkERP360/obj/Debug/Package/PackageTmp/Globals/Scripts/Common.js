/*---------------------------- Removes leading whitespaces ----------------------------*/
function LTrim(value) {

    var re = /\s*((\S+\s*)*)/;
    return value.replace(re, "$1");

}


/*---------------------------- Removes ending whitespaces ----------------------------*/
function RTrim(value) {

    var re = /((\s*\S+)*)\s*/;
    return value.replace(re, "$1");

}

/*---------------------------- Removes leading and ending whitespaces ----------------------------*/
function trim(value) {

    return LTrim(RTrim(value));

}

/*---------------------------- Numeric Integer Validation ----------------------------*/
function IsInteger(evt) {
    evt = (evt) ? evt : window.event
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        //status = "This field accepts numbers only."
        return false
    }
    status = ""
    return true
}

/*---------------------------- Numeric Double Validation ----------------------------*/
function IsDouble(evt) {
    evt = (evt) ? evt : window.event
    var charCode = (evt.which) ? evt.which : evt.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
        //status = "This field accepts numbers only."
        return false
    }
    status = ""
    return true
}

/*---------------------------- Check text/textarear blank , before submit data ----------------------------*/
function IsBlank(that_object, message) {
    var that_object_value;
    that_object_value = trim(that_object.value);
    if (that_object_value == "") {
        alert(message);
        that_object.focus();
        return true; 	/*----- Input is blank . --*/
    }
    return false; 		/*----- Input is not blank . --*/
}
function IsBlank(that_object, message) {
    var that_object_value;
    that_object_value = trim(that_object.value);
    if (that_object_value == "") {
        alert(message);
        that_object.focus();
        return true; 	/*----- Input is blank . --*/
    }
    return false; 		/*----- Input is not blank . --*/
}
/*---------------------------- Check select box blank, before submit data ----------------------------*/
function IsSelectBlank(that_object, message) {
    if (that_object.selectedIndex <= 0) {
        alert(message);
        that_object.focus();
        return true;
    }
    return false;
}

/*---------------------------- Numeric Validation with , ----------------------------*/
function Is_Integer(evt) {
    evt = (evt) ? evt : window.event
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode != 44) {
        //status = "This field accepts numbers only."
        return false
    }
    status = ""
    return true
}

/*---------------------------- Check email format validation ----------------------------*/
function EmailValidation(entered, alertbox) {
    //alert("dd");
    if (trim(entered.value) == "") {
        return true;
    }
    with (entered) {
        apos = trim(value).indexOf("@");
        dotpos = trim(value).lastIndexOf(".");
        lastpos = trim(value).length - 1;
        if (apos < 1 || dotpos - apos < 2 || lastpos - dotpos > 3 || lastpos - dotpos < 2)
        { if (alertbox) { alert(alertbox); } return false; }
        else { return true; }
    }
}

/*---------------------------- Check date validation ----------------------------*/
function isDate(txtDate) {
    var currVal = txtDate;
    if (currVal == '')
        return false;

    //Declare Regex  
    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern); // is format OK?

    if (dtArray == null)
        return false;

    //Checks for mm/dd/yyyy format.
    /*dtMonth = dtArray[1];
    dtDay = dtArray[3];
    dtYear = dtArray[5];*/

    //Checks for dd/mm/yyyy format.
    dtDay = dtArray[1];
    dtMonth= dtArray[3];
    dtYear = dtArray[5]; 

    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap))
            return false;
    }
    return true;
}