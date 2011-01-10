$(function () {
    $("#sidebar .part li").each(function () {
        $(this).bind("click", function () {
            var link = $(this).find("a");
            if (link != undefined) {
                window.location = link.attr("href");
            }
        });
    });

    $("#main .list tr").each(function () {
        $(this).bind("click", function () {
            var link = $(this).find("a");
            if (link != undefined) {
                window.location = link.attr("href");
            }
        });
    });

    $("#main .list li").each(function () {
        $(this).bind("click", function () {
            var link = $(this).find("a");
            if (link != undefined) {
                window.location = link.attr("href");
            }
        });
    });
});

$(function () {
    $("ul li:first").css("class", "first");
    $("ul li:last").css("class", "last");
    $("#main .list li a").parent("li").css("cursor", "pointer");
    $("#main .list td a").parent("td").parent("tr").css("cursor", "pointer");
    $("#sidebar .part a").parent("li").css("cursor", "pointer");
});

$(function () {
    $("#filter select").hide();

    $("#filter strong").html(function () {
        return $(this).next().find(":selected").text(); 
    })

    $("#filter strong").each(function () {
        $(this).bind("click", function () {
            $(this).css("display", "none");
            $(this).siblings("select:first").css("display", "");
        });
    });
});