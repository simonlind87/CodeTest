// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Takes one argument (Id of the html element containing the input value).
// If validation success the lookupCountryAsync function.
function lookupCountryCode(inputElementId) {
    const element = document.getElementById(inputElementId);
    const input = element.value;
    const outputElement = document.getElementById("country-control-for-" + inputElementId);

    if (element.value) {
        if (validateInput(input)) {
            lookupCountryAsync(input, outputElement);
            element.classList.remove("is-invalid");
            document.getElementById(inputElementId + "-error-box").innerHTML = "";
        }
        else {
            outputElement.innerHTML = '<i class="fas fa-question"></i>';
            outputElement.title = "Unknown number";
            element.classList.add("is-invalid");
            document.getElementById(inputElementId + "-error-box").innerHTML = "Format: +4598765432";
        }
    }
    else {
        outputElement.innerHTML = '<i class="fas fa-phone"></i>';
        element.classList.remove("is-invalid");
        document.getElementById(inputElementId + "-error-box").innerHTML = "";
    }
}

// Super simple input validation. 
function validateInput(input) {

    if (input.substring(0, 1) === '+' && input.length > 2) {
        return true;
    }
    else {
        return false;
    }

}

// Ajax function used to call the /Phone/GetCountry/ endpoint and update the UI elements accordingly
// Takes two arguments: phoneNumber (user input) and the Html element to update.
function lookupCountryAsync(phoneNumber, outputElement) {
    $.ajax({
        type: 'GET',
        url: '/Phone/GetCountry/' + phoneNumber.substring(1, phoneNumber.length),
        success: function (response) {

            // If an empty JsonResponse is returned, no country code was found and we insert generic feedback that something went wrong. 
            if (response == "") {
                outputElement.innerHTML = '<i class="fas fa-question"></i>';
                outputElement.title = "Unknown country";
            }
            // If the JsonRespons is not empty, we update the HTML elements with the returned data. 
            else {
                outputElement.innerHTML = response.code;
                outputElement.title = response.name;
            }
        }
    });
}
