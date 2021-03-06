﻿$(function () {
    $("#edit-form").ajaxForm({
        success: function (response) {
            var text = $.trim(response);
            if (text.substring(0, 1) == "/") {
                location.href = text;
            } else {
                $("#edit-form").html($(response).find("#edit-form").html());
            }
        }
    });

    $("#note-edit-form").ajaxForm({
        success: function (response) {
            $(".notes ul").append(response);
        },
        resetForm: true
    });

    $("#attachment-edit-form").ajaxForm({
        success: function (response) {
            $(".attachments ul").append(response);
        },
        resetForm: true
    });

    $(".deleteNote").live("click", function (e) {
        e.preventDefault();
        var $link = $(this);
        if (confirm("Are you sure you want to delete this item?")) {
            $.post($link.attr("href"), function () {
                $link.parent().remove();
            });
        }
    });

    $(".deleteAttachment").live("click", function (e) {
        e.preventDefault();
        var $link = $(this);
        if (confirm("Are you sure you want to delete this item?")) {
            $.post($link.attr("href"), function () {
                $link.parent().remove();
            });
        }
    });

    $(".fileUpload").live("change", function (e) {
        $("#attachment-edit-form").submit();
    });
});

function deleteRecord(action) {
    if (confirm("Are you sure you want to delete this item?")) {
        location.href = action;
    }
}