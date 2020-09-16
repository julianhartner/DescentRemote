// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(
    substituteIcons()
);

function substituteIcons() {
    var spans = $('span:contains("++")');
    for (var i = 0; i < spans.length; i++) {
        var currSpan = spans[i]

        // Split the text
        var splitted = currSpan.textContent.split(" ");
        var currString = "";
        var htmlParts = [];

        for (var j = 0; j < splitted.length; j++) {
            var currWord = splitted[j];
            if (currWord.length == 0 || currWord == "/n")
                continue;

            if (currWord.includes("++")) {
                var img = new Image();
                switch (currWord.substring(2, currWord.length-2)) {
                    case "damage":
                        img.src = "/images/icons/damage.png"
                        break;
                    case "action":
                        img.src = "/images/icons/action.png"
                        break;
                    case "fatigue":
                        img.src = "/images/icons/fatigue.png"
                        break;
                    default:
                        break;
                }

                var span = document.createElement("span");
                span.textContent = currString + " ";
                htmlParts.push(span);
                htmlParts.push(img);
                currString = "";
            }
            else {
                currString = currString + " " + splitted[j];
            }
        }

        var span = document.createElement("span");
        span.textContent = currString;
        htmlParts.push(span);

        // Wrap content with a div container
        var container = document.createElement("div");
        for (var j = 0; j < htmlParts.length; j++)
            container.appendChild(htmlParts[j]);
        
        var parent = currSpan.parentElement;
        parent.replaceChild(container, currSpan);
    }
}

function addHealth() {
    editHealth('/api/AddHealth');
}

function removeHealth() {
    editHealth('/api/RemoveHealth');
}

function addStamina() {
    editStamina('/api/AddStamina');
}

function removeStamina() {
    editStamina('/api/RemoveStamina');
}

function exhaustCard(card) {
    var id = card.id.split('_')[0];     // id = {id}_exhaust
    var element = document.getElementById(id).getElementsByTagName('img')[0];

    if (element.classList.contains("exhausted"))
        return;

    $.ajax({
        type: "GET",
        url: '/api/ExhaustCard',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + getCookie("id") + "&cardId=" + id,
        dataType: "json"
    }).done(function (isSuccessful) {
        if (isSuccessful) {
            element.classList.add("exhausted");

            //Hide exhaust button and unhide refresh button
            card.setAttribute("hidden", true);
            document.getElementById(id + "_refresh").removeAttribute("hidden");
        }
    });
}

function refreshCard(card) {
    var id = card.id.split('_')[0];     // id = {id}_refresh
    var element = document.getElementById(id).getElementsByTagName('img')[0];

    if (!element.classList.contains("exhausted"))
        return;

    $.ajax({
        type: "GET",
        url: '/api/RefreshCard',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + getCookie("id") + "&cardId=" + id,
        dataType: "json"
    }).done(function (isSuccessful) {
        if (isSuccessful) {
            element.classList.remove("exhausted");

            //Hide refresh button and unhide exhaust button
            card.setAttribute("hidden", true);
            document.getElementById(id + "_exhaust").removeAttribute("hidden");
        }
    });
}

function equipCard(card) {
    var id = card.id.split('_')[0];     // id = {id}_equip
    var element = document.getElementById(id).getElementsByClassName('equipped-circle')[0];

    $.ajax({
        type: "GET",
        url: '/api/EquipCard',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + getCookie("id") + "&cardId=" + id,
        dataType: "json"
    }).done(function (isSuccessful) {
        if (isSuccessful) {
            element.removeAttribute("hidden");

            //Hide equip button and unhide unequip button
            card.setAttribute("hidden", true);
            document.getElementById(id + "_unequip").removeAttribute("hidden");
        }
    });
}

function unequipCard(card) {
    var id = card.id.split('_')[0];     // id = {id}_unequip
    var element = document.getElementById(id).getElementsByClassName('equipped-circle')[0];

    $.ajax({
        type: "GET",
        url: '/api/UnequipCard',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + getCookie("id") + "&cardId=" + id,
        dataType: "json"
    }).done(function (isSuccessful) {
        if (isSuccessful) {
            element.setAttribute("hidden", true);

            //Hide equip button and unhide unequip button
            card.setAttribute("hidden", true);
            document.getElementById(id + "_equip").removeAttribute("hidden");
        }
    });
}

function addFamiliarHealth(card) {
    var id = card.id.split('_')[0];

    $.ajax({
        type: "GET",
        url: '/api/AddFamiliarHealth',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + getCookie("id") + "&familiarId=" + id,
        dataType: "json"
    }).done(function (data) {
        document.getElementById(id + '_currenthealth').innerHTML = data;
    });
}

function removeFamiliarHealth(card) {
    var id = card.id.split('_')[0];

    $.ajax({
        type: "GET",
        url: '/api/RemoveFamiliarHealth',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + getCookie("id") + "&familiarId=" + id,
        dataType: "json"
    }).done(function (data) {
        document.getElementById(id + '_currenthealth').innerHTML = data;

        if (data <= 0) {
            document.getElementById(id + '_revive').removeAttribute("hidden");
            document.getElementById(id + '_addhealth').setAttribute("hidden", true);
            document.getElementById(id + '_removehealth').setAttribute("hidden", true);
            document.getElementById(id).getElementsByTagName('img')[0].classList.add("exhausted");
        }
    });
}

function reviveFamiliar(card) {
    var id = card.id.split('_')[0];

    $.ajax({
        type: "GET",
        url: '/api/ReviveFamiliar',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + getCookie("id") + "&familiarId=" + id,
        dataType: "json"
    }).done(function (data) {
        document.getElementById(id + '_currenthealth').innerHTML = data;
        document.getElementById(id + '_addhealth').removeAttribute("hidden");
        document.getElementById(id + '_removehealth').removeAttribute("hidden");
        document.getElementById(id + '_revive').setAttribute("hidden", true);
        document.getElementById(id).getElementsByTagName('img')[0].classList.remove("exhausted");
    });
}

function editHealth(ajaxUrl) {
    $.ajax({
        type: "GET",
        url: ajaxUrl,
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "id=" + getCookie("id"),
        dataType: "json"
    }).done(function (data) {
        document.getElementById("currentHealth").innerHTML = data;
    });
}

function editStamina(ajaxUrl) {
    $.ajax({
        type: "GET",
        url: ajaxUrl,
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "id=" + getCookie("id"),
        dataType: "json"
    }).done(function (data) {
        document.getElementById("currentStamina").innerHTML = data;
    });
}

function exhaustHeroicFeat() {
    var id = getCookie("id");
    $.ajax({
        type: "GET",
        url: "/api/ExhaustHeroicFeat",
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + id,
        dataType: "json"
    }).done(function (data) {
        document.getElementById("heroic-feat-container").setAttribute("hidden", true);
    });
}

function reset() {
    var id = document.getElementById("user-id").innerHTML;
    $.ajax({
        type: "GET",
        url: "/api/Reset",
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: "userId=" + id,
        dataType: "json"
    }).done();
}

function resetGame() {
    $.ajax({
        type: "GET",
        url: "/api/ResetGame",
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done();
}

function getCookie(name) {
    // Split cookie string and get all individual name=value pairs in an array
    var cookieArr = document.cookie.split(";");

    // Loop through the array elements
    for (var i = 0; i < cookieArr.length; i++) {
        var cookiePair = cookieArr[i].split("=");

        /* Removing whitespace at the beginning of the cookie name
        and compare it with the given string */
        if (name == cookiePair[0].trim()) {
            // Decode the cookie value and return
            return decodeURIComponent(cookiePair[1]);
        }
    }

    // Return null if not found
    return null;
}

function setCookie(id, currHealth, currStamina) {
    document.cookie = "";
    var cookie = "id=" + id + "; current_health=" + currHealth + "; current_stamina=" + currStamina;
    document.cookie = cookie;
}