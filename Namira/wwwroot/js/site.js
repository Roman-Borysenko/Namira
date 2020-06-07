$(document).ready(function () {
    var selected_size = [];
    var key_name = "item-";

    $('.selectpicker').selectpicker();

    $('.add-size').on('click', function () {
        if ($('.size-container').attr('data-count') > $('.size-item').length) {
            var el = $(this).closest('.size-item').clone(true).appendTo('.size-container');
            el.find('select').val("");
            el.find('.quantity').val(0);
            var parent = $(this).parent();
            $(this).detach();
            parent.html('<a class="btn btn-danger delete-size" style="display: block;">Delete size</a>');
        } else {
            $('.toast-body').text("Maximum allowed number of items: " + $('.size-item').length);
            $('.toast').toast('show');
        }
    });

    $('.delegate').on("click", ".delete-size", function () {
        if ($('.size-item').length != 1) {
            $('.select-size option[value=' + selected_size[key_name + $(this).closest('.size-item').index()] + ']').removeAttr("disabled");
            $(this).closest('.size-item').detach();
        }
    });

    $('.select-size').change(function () {
        if (typeof selected_size[$(this).closest('.size-item').index()] === "undefined") {
            selected_size[key_name + $(this).closest('.size-item').index()] = $(this).val();
        }

        $('.select-size option').removeAttr("disabled");

        for (key in selected_size) {
            $('.select-size option[value=' + selected_size[key] + ']').attr("disabled", "disabled");
        }
    });
});