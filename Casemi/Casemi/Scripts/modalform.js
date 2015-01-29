// modalform.js

$(function () {
    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {
        var replacetarget = $(this).attr("data-id");

        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({/*backdrop: 'static',*/ keyboard: true }, 'show');
            bindForm(this, replacetarget);
        });
        return false;
    });
});

function bindForm(dialog, replacetarget) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#' + replacetarget).load(result.url); //  Load data from the server and place the returned HTML into the matched element
                }
                else {
                    $('#myModalContent').html(result);
                    bindForm(dialog, replacetarget);
                }
            }
        });
        return false;
    });
}