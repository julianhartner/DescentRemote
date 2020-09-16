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
        $("#popup-lieutenant-card-list").html(htmlArr.join(""));
    });
}

function CloseLieutenantsPopup() {
    var cards = document.getElementsByClassName("card-selected");
    var idArr = Array();

    for (var i = 0; i < cards.length; i++) {
        var splitted = cards[i].id.split("_");

        // Only add the card id if it isn't already in the array
        if (!idArr.includes(splitted[1]))
            idArr.push(splitted[1]);
    };

    for (var i = 0; i < idArr.length; i++) {
        $.ajax({
            type: "GET",
            url: '/api/AddLieutenant',
            contentType: "application/json; charset=utf-8",

            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: "userId=" + getCookie("id") + "&lieutenantId=" + idArr[i],
            dataType: "json"
        }).done(function (lieutenant) {
            if (lieutenant == null)
                return;

            var htmlArr = new Array;
            htmlArr = htmlArr.concat(BuildLieutenantCard(lieutenant, lieutenant.act1, 1, true));
            htmlArr = htmlArr.concat(BuildLieutenantCard(lieutenant, lieutenant.act2, 2, false));

            // Add html to DOM for Act1
            document.getElementById("lieutenant-card-list").innerHTML += htmlArr.join('');
        });
    };

    // Remove everything from the popup before closing it.
    const act1 = document.getElementById("popup-lieutenant-card-list");
    while (act1.firstChild) {
        act1.removeChild(act1.lastChild);
    }

    document.getElementById("choose-lieutenants-popup").style.display = "none";
}

function OpenMonstersPopup() {
    document.getElementById("choose-monsters-popup").style.display = "block";

    $.ajax({
        type: "GET",
        url: '/api/GetMonsters',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done(function (monsters) {
        var htmlArr = new Array;

        $.each(monsters, function (key, monster) {
            htmlArr = htmlArr.concat(BuildMonsterCard(monster, monster.act1, 1, true));
            htmlArr = htmlArr.concat(BuildMonsterCard(monster, monster.act2, 2, false));
        });

        // Add html to DOM for Act1
        $("#popup-monster-card-list").html(htmlArr.join(""));
    });
}

function CloseMonstersPopup() {
    var cards = document.getElementsByClassName("card-selected");
    var idArr = Array();

    for (var i = 0; i < cards.length; i++) {
        var splitted = cards[i].id.split("_");

        // Only add the card id if it isn't already in the array
        if (!idArr.includes(splitted[1]))
            idArr.push(splitted[1]);
    };

    for (var i = 0; i < idArr.length; i++) {
        $.ajax({
            type: "GET",
            url: '/api/AddMonster',
            contentType: "application/json; charset=utf-8",

            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: "userId=" + getCookie("id") + "&monsterId=" + idArr[i],
            dataType: "json"
        }).done(function (monster) {
            if (monster == null)
                return;

            var htmlArr = new Array;
            htmlArr = htmlArr.concat(BuildMonsterCard(monster, monster.act1, 1, true));
            htmlArr = htmlArr.concat(BuildMonsterCard(monster, monster.act2, 2, false));

            // Add html to DOM for Act1
            document.getElementById("monster-card-list").innerHTML += htmlArr.join('');
        });
    };

    // Remove everything from the popup before closing it.
    const act1 = document.getElementById("popup-monster-card-list");
    while (act1.firstChild) {
        act1.removeChild(act1.lastChild);
    }

    document.getElementById("choose-monsters-popup").style.display = "none";
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
    //var card = document.getElementById(card.id);

    var otherActId = CalcOtherActCardId(card.id);

    // The card is already selected
    if (card.classList.contains("card-selected")) {
        card.classList.remove("card-selected");

        // Remove class from other act hidden card
        document.getElementById(otherActId).classList.remove("card-selected");
        
        return;
    }

    document.getElementById(otherActId).classList.add("card-selected");
    document.getElementById(card.id).classList.add("card-selected");
}

function BuildLieutenantCard(lieutenant, act, actNumber, displayed) {
    var htmlArr = new Array();

    // card container
    if (displayed) {
        htmlArr.push("<div id=\"card_" + lieutenant.id + "_" + actNumber + "\" class=\"lieutenant-card\" onclick=\"SelectCard(this)\">");
    }
    else {
        htmlArr.push("<div id=\"card_" + lieutenant.id + "_" + actNumber + "\" class=\"lieutenant-card\" onclick=\"SelectCard(this)\" hidden>");
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
    htmlArr.push("<button class=\"button-switch-act\" id=\"button_" + lieutenant.id + "_" + actNumber + "\" onclick=\"SwitchAct(this)\">Act " + actNumber + "</button>");
    htmlArr.push("</div>");

    // Close card container
    htmlArr.push("</div>");

    return htmlArr;
}

function BuildMonsterCard(monster, act, actNumber, displayed) {
    var htmlArr = new Array();

    // card container
    if (displayed) {
        htmlArr.push("<div id=\"card_" + monster.id + "_" + actNumber + "\" class=\"monster-card\" onclick=\"SelectCard(this)\">");
    }
    else {
        htmlArr.push("<div id=\"card_" + monster.id + "_" + actNumber + "\" class=\"monster-card\" onclick=\"SelectCard(this)\" hidden>");
    }

    // Stats of the minion Monster
    htmlArr.push("<div class=\"card-monster-stats\">");
    htmlArr.push("<span>Speed</span>");
    htmlArr.push("<span>" + act.speedMinion + "</span>");
    htmlArr.push("<span>Health</span>");
    htmlArr.push("<span>" + act.healthMinion + "</span>");
    htmlArr.push("<span>Defense</span>");
    htmlArr.push("<span>" + act.defenseDiceMinion[0] + "</span>");
    htmlArr.push("</div>");

    // Specials of the minion Monster
    htmlArr.push("<div class=\"card-specials\">");
    $.each(act.specialsMinion, function (key, special) {
        htmlArr.push("<span>" + special.cost + ":" + special.name + "</span>");
    });
    htmlArr.push("</div>");

    // Minion attack dice
    htmlArr.push("<div class=\"card-monster-dice\">");
    htmlArr.push("<span>" + act.attackDiceMinion[0] + "</span>");
    htmlArr.push("</div>")

    // Image of the Monster
    htmlArr.push("<div class=\"card-image-container\">");
    htmlArr.push("<img class=\"card-image\" src=\"" + monster.location + "\">")
    htmlArr.push("</div>")

    // Card Extras
    htmlArr.push("<div class=\"card-monster-extras\">");
    htmlArr.push("<span>" + monster.attackType + "</span>");
    htmlArr.push("<button class=\"button-switch-act\" id=\"button_" + monster.id + "_" + actNumber + "\" onclick=\"SwitchAct(this)\">Act " + actNumber + "</button>");
    htmlArr.push("</div>");

    // Name of the Monster
    htmlArr.push("<div class=\"card-name\">");
    htmlArr.push("<h2>" + monster.name + "</h2>")
    htmlArr.push("</div>");

    // Master attack dice
    htmlArr.push("<div class=\"card-monster-dice\">");
    htmlArr.push("<span>" + act.attackDiceMaster[0] + "</span>");
    htmlArr.push("</div>");

    // Specials of the master Monster
    htmlArr.push("<div class=\"card-specials\">");
    $.each(act.specialsMaster, function (key, special) {
        htmlArr.push("<span>" + special.cost + ":" + special.name + "</span>");
    });
    htmlArr.push("</div>");

    // Stats of the master Monster
    htmlArr.push("<div class=\"card-monster-stats\">");
    htmlArr.push("<span>Speed</span>");
    htmlArr.push("<span>" + act.speedMaster + "</span>");
    htmlArr.push("<span>Health</span>");
    htmlArr.push("<span>" + act.healthMaster + "</span>");
    htmlArr.push("<span>Defense</span>");
    htmlArr.push("<span>" + act.defenseDiceMaster[0] + "</span>");
    htmlArr.push("</div>");

    // Close card container
    htmlArr.push("</div>");

    return htmlArr;
}

function CalcOtherActCardId(id) {
    var splittedId = id.split("_");
    var otherActId;

    if (splittedId[2] == "1")
        otherActId = splittedId[0] + "_" + splittedId[1] + "_" + "2"
    else
        otherActId = splittedId[0] + "_" + splittedId[1] + "_" + "1"

    return otherActId;
}