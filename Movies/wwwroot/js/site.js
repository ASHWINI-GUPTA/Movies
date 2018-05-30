//JS for Bootbox
$(document).ready(function () {
    $("#bootbox-producer").on("click", function (event) {
        var modal = bootbox.dialog({
            message: $(".producer-form-html").html(),
            title: "Add Producer",
            show: false,
            onEscape: function () {
                modal.modal("hide");
            }
        });
        modal.modal("show");
    });

    $("#bootbox-actor").on("click", function (event) {
        var modal = bootbox.dialog({
            message: $(".actor-form-html").html(),
            title: "Add Actor",
            show: false,
            onEscape: function () {
                modal.modal("hide");
            }
        });
        modal.modal("show");
    });
});
