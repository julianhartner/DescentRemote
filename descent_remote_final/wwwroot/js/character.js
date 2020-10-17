$(document).ready(
    addUsersToNavDropdown()
);

function addUsersToNavDropdown() {
    $.ajax({
        type: "GET",
        url: '/api/GetUsers',
        contentType: "application/json; charset=utf-8",

        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done(function (users) {
        if (users != null){
            var element = document.getElementById("other-heroes-dropdown-menu");

            if (element == null)
                return;
            
                var currUrl = new URL(window.location.href);
                var currUsername = currUrl.searchParams.get("username");
                var index = users.indexOf(currUsername);
                if (index > -1)
                    users.splice(index, 1);

            var link;
            users.forEach(user => {
                link = document.createElement("a");
                link.classList.add("dropdown-item");
                link.setAttribute("href", "/home/character?username=" + user);
                link.innerText = user;

                element.appendChild(link);
            });
        }
    });
}