$(function () {
    $("#sidebar .part li").each(function () {
        $(this).click(function () {
            var link = $(this).find("a");
            if (link != undefined) {
                window.location = link.attr("href");
            }
        });
    });

    $("#main .list tr").each(function () {
        $(this).click(function () {
            var link = $(this).find("a");
            if (link != undefined) {
                window.location = link.attr("href");
            }
        });
    });

    $("#main .list li").each(function () {
        $(this).click(function () {
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
        $(this).click(function () {
            $(this).hide();
            $(this).siblings("select:first").show();
        });
    });
});

