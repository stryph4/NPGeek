function createCookie(name, value) {
    document.cookie = name + "=" + value;
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}

function getPreference() {

    var preference = readCookie("temp");
    if (preference == "ce") {
        document.getElementById("preferencebutton").innerHTML = "Change to Fahrenheit";

        var elements = document.getElementsByClassName("temperature");

        for (var i = 0; i < elements.length; i++) {
            var tempstring = elements[i].innerHTML;
            var temperature = (parseInt(tempstring) - 32) * (5 / 9);
            elements[i].innerHTML = Math.round(temperature) + 'ºC';
        }
    }
    if (preference == "fa") {
        document.getElementById("preferencebutton").innerHTML = "Change to Celcius";

        var elements = document.getElementsByClassName("temperature");

        for (var i = 0; i < elements.length; i++) {
            var tempstring = elements[i].innerHTML;
            var temperature = parseInt(tempstring);
            elements[i].innerHTML = Math.round(temperature) + 'ºF';
        }
    }
}

function setPreference() {
    var preference = readCookie("temp");
    if (preference == "fa") {
        eraseCookie("temp");
        createCookie("temp", "ce");

        document.getElementById("preferencebutton").innerHTML = "Change to Fahrenheit";
        var elements = document.getElementsByClassName("temperature");

        for (var i = 0; i < elements.length; i++) {
            var tempstring = elements[i].innerHTML;
            tempstring = tempstring.substring(0, tempstring.length - 2);
            var temperature = (parseInt(tempstring) - 32) * (5 / 9);
            elements[i].innerHTML = Math.round(temperature) + 'ºC';
        }
    }
    if (preference == "ce") {
        eraseCookie("temp");
        createCookie("temp", "fa");


        document.getElementById("preferencebutton").innerHTML = "Change to Celcius";
        var elements = document.getElementsByClassName("temperature");

        for (var i = 0; i < elements.length; i++) {
            var tempstring = elements[i].innerHTML;
            tempstring = tempstring.substring(0, tempstring.length - 2);
            var temperature = parseInt(tempstring) * (9 / 5) + 32;
            elements[i].innerHTML = Math.round(temperature) + 'ºF';
        }
    }
}
