$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})


$("form").on("submit", function (e) {
    e.preventDefault();

    // Show your modal
    $("#myModal").modal("show");
});

// This handled the modal close event.
$("#myModal").on("hidden.bs.modal", function () {

    // Remove the submit function from the form.
    $("form").off("submit");

    // Retrieve value from your input by id
    var firstValue = $("#InputId").val();

    // Retrieve value from your input by name
    var secondValue = $("input[name=InputName]").val();

    // Attach new value to the form
    $("<input type='hidden' name='firt-input' value='" + firstValue + "' />")
        .appendTo($("form"));

    // Attach other value to the form
    $("<input type='hidden' name='second-input' value='" + secondValue + "' />")
        .appendTo($("form"));

    // Finally, submit the form.
    // I'd rather use ajax here, but to make things simple, just submit your form.
    $("form").submit();

});