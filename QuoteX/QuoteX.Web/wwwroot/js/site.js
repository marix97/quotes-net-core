$(function () {
    $("#send-quote-button").attr("disabled", true);

    $("#create-quote-textarea").keyup(function () {
        $("#count-characters-quote").text("Characters left: " + (256 - $(this).val().replace(/ /g, '').length ));

        if ($(this).val().replace(/ /g, '').length < 10) {
            $("#send-quote-button").attr("disabled", true);
        }
        else {
            $("#send-quote-button").attr("disabled", false);
        }
    });

    $("#send-quote-button").click(function () {
        let textData = $.trim($("#create-quote-textarea").val()).toString();
        let val = JSON.stringify(textData);

        //Set them to true before sending an AJAX request
        $(".alert-success").attr("hidden", true);
        $(".alert-danger").attr("hidden", true);

        //Make the button unclickable
        $("#send-quote-button").attr("disabled", true);

        $.ajax({
            type: 'POST',
            cache: false,
            url: '/Quote/CreateQuote',
            contentType: "application/json; charset=utf-8",
            data: val,
            success: function () {
                {
                    $(".alert-success").attr("hidden", false);
                    $("#send-quote-button").attr("disabled", false);
                }
            },
            error: function () { $(".alert-danger").attr("hidden", false); }
        });
    }
    )

    $("#draw-button").click(function () {
        //Make the button unclickable
        $("#draw-button").attr("disabled", true);

        $.ajax({
            type: 'GET',
            url: '/Quote/DrawQuote',
            success: function (response) {
                {
                    $(".mb-0").empty();
                    $(".mb-0").css("border", "2px solid yellow");
                    $(".mb-0").append(response.text);
                    $("#draw-button").attr("disabled", false);
                }
            },
            error: function () {
                $(".mb-0").empty();
                $("#draw-button").attr("disabled", false);
            }
        });
    }
    )
})

function deleteItem(form) {
    //Hiding it in case a quote has been approved before deleting one
    $(".alert-success").attr("hidden", true);

    $(".alert-info").attr("hidden", false);
    $(form).parent().parent().remove();
}

function approveItem(form) {
    //Hiding it in case a quote has been deleted before approving one
    $(".alert-info").attr("hidden", true);

    $(".alert-success").attr("hidden", false);
    $(form).parent().parent().remove();
}