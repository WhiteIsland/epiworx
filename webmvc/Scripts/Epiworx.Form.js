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

function deleteRecord(action) {
    if (confirm("Are you sure you want to delete this item?")) {
        location.href = action;
    }
}
