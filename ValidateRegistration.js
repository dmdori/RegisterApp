function userValidation() {
    //var firstName, lastName, email, emailExp, pass, phone;
    var firstName = document.getElementById("FirstText").value;
    var lastName = document.getElementById("LastText").value;
    var pass = document.getElementById("PasswText").value;
    var phone = document.getElementById("PhoneText").value;
    var phExp = /^([0-9]{10})+$/;   ///^\d{4}$/ /^([0-9]{10})$/"
    var email = document.getElementById("EmailText").value;
    var emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id  
    
    if (firstName == '' && lastName == 0 && pass == '' && phone == '' && email == '') {
        alert("Enter All Fields");
        return false;
    }
    else if (firstName == '') {
        alert("Please Enter FirstName");
        return false;
    }
    else if (lastName == 0) {
        alert("Please Enter LastName");
        return false;
    }
    else if (pass == '') {
        alert("Please Enter Password");
        return false;
    }
    else if (phone == '') {
        alert("Please Enter Phone");
        return false;
    }
    else if (email == '') {
        alert("Email Id Is Required");
        return false;
    }
    else if (firstName != '') {
        if (firstName.length > 20) {
            firstName.style.color = "red";
            alert("Name too long");

            return false;
        }
        else {
            firstName.style.color = "green";
        }
    }
    else if (lastName != '') {
        if (firstName.length > 20) {
            alert("Name too long!");
            return false;
        }
    }
    else if (pass != '') {
        if (firstName.length > 10) {
            alert("Password too long!");
            return false;
        }
    }
    else if (phone != '') {
        if (!phone.match(phExp)    
    {
            alert("Invalid Phone Number");
            return false;
        }
    }
    else if (email != '') {
        if (!EmailId.match(emailExp)    
    {
            alert("Invalid Email Id");
            return false;
        }
    }
    return true; 

}