$(function () {
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
});