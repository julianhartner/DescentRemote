window.onclick = function (event) {
    if (event.target == document.getElementById("choose-lieutenants-popup")) {
        this.CloseLieutenantsPopup();
    }
}

function OpenLieutenantsPopup() {
    document.getElementById("choose-lieutenants-popup").style.display = "block";

    $.ajax({
        type: "GET",
        url: '/api/GetLieutenants',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done(function (lieutenants) {
        var htmlArr = new Array;

        $.each(lieutenants, function (key, lieutenant) {
            htmlArr = htmlArr.concat(BuildLieutenantCard(lieutenant, lieutenant.act1, 1, true));
            htmlArr = htmlArr.concat(BuildLieutenantCard(lieutenant, lieutenant.act2, 2, false));
        });

        // Add html to DOM for Act1
        $("#lieutenant-card-list").html(htmlArr.join(""));
    });
}

function CloseLieutenantsPopup() {
    // Remove everything from the popup before closing it.
    const act1 = document.getElementById("lieutenant-card-list");
    while (act1.firstChild) {
        act1.removeChild(act1.lastChild);
    }

    document.getElementById("choose-lieutenants-popup").style.display = "none";
}

function SwitchAct(button) {
    var splitId = button.id.split("_");
    var currActId = "card_" + splitId[1] + "_" + splitId[2];

    if (splitId[2] == "1") {
        document.getElementById(currActId).setAttribute("hidden", true);
        document.getElementById("card_" + splitId[1] + "_2").removeAttribute("hidden");
    }
    else {
        document.getElementById(currActId).setAttribute("hidden", true);
        document.getElementById("card_" + splitId[1] + "_1").removeAttribute("hidden");
    }
}

function SelectCard(card) {
    //TODO:
    var card = document.getElementById(card.id);

    // The card is already selected
    if (card.classList.contains("card-selected")) {
        card.classList.remove("card-selected");
        return;
    }

    document.getElementById(card.id).classList.add("card-selected");
}

function BuildLieutenantCard(lieutenant, act, actNumber, displayed) {
    var htmlArr = new Array();

    // card container
    if (displayed) {
        htmlArr.push("<div id=\"card_" + lieutenant.name.replace(/\s/g, "") + "_" + actNumber + "\" class=\"card\" onclick=\"SelectCard(this)\">");
    }
    else {
        htmlArr.push("<div id=\"card_" + lieutenant.name.replace(/\s/g, "") + "_" + actNumber + "\" class=\"card\" hidden>");
    }
    

    // Image of the Lieutenant
    
    htmlArr.push("<div class=\"card-image-container\">");
    htmlArr.push("<img class=\"card-image\" src=\"" + lieutenant.location + "\">")
    htmlArr.push("</div>")

    // Attributes of the Lieutenant
    htmlArr.push("<div class=\"card-attributes\">");
    htmlArr.push("<span>M: </span>");
    htmlArr.push("<span>" + act.might + "</span>");
    htmlArr.push("<span>K: </span>");
    htmlArr.push("<span>" + act.knowledge + "</span>");
    htmlArr.push("<span>W: </span>");
    htmlArr.push("<span>" + act.willpower + "</span>");
    htmlArr.push("<span>A: </span>");
    htmlArr.push("<span>" + act.awareness + "</span>");
    htmlArr.push("</div>");

    // Name of the Lieutenant
    htmlArr.push("<div class=\"card-name\">");
    htmlArr.push("<h2>" + lieutenant.name + "</h2>")
    htmlArr.push("</div>");

    // Specials of the Lieutenant
    htmlArr.push("<div class=\"card-specials\">");
    $.each(act.specials, function (key, special) {
        htmlArr.push("<span>" + special.cost + ":" + special.name + "</span>");
    });
    htmlArr.push("</div>");

    // Stats Header
    htmlArr.push("<div class=\"card-stats-header card-stats\">");
    htmlArr.push("<span></span>");
    htmlArr.push("<span>Speed</span>");
    htmlArr.push("<span>Health</span>");
    htmlArr.push("<span>Dice</span>");
    htmlArr.push("</div>");

    // 2-Player Stats
    $.each(act.stats, function (key, stat) {
        htmlArr.push("<div class=\"card-stats-" + stat.numberOfHeroes + "player card-stats\">");
        htmlArr.push("<span>" + stat.numberOfHeroes + " Player</span>");
        htmlArr.push("<span>" + stat.speed + "</span>");
        htmlArr.push("<span>" + stat.health + "</span>");
        htmlArr.push("<span>" + stat.defenseDice[0] + "</span>");
        htmlArr.push("</div>");
    });

    // Card Extras
    htmlArr.push("<div class=\"card-extras\">");
    htmlArr.push("<span>" + lieutenant.attackType + "</span>");
    htmlArr.push("<span>" + act.attackDice[0] + "</span>");
    htmlArr.push("<button id=\"button_" + lieutenant.name.replace(/\s/g, "") + "_" + actNumber + "\" onclick=\"SwitchAct(this)\">Act " + actNumber + "</button>");
    htmlArr.push("</div>");

    // Close card container
    htmlArr.push("</div>");

    return htmlArr;
}