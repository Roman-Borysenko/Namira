$(document).ready(function () {
    var selected_size = [];
    var key_name = "item-";
    var image_selected = false; 
    var crop_object = [];

    $('.selectpicker').selectpicker();
/*--size--*/
    $('.product-color-container').on('click', '.add-size', function () {
        var index = $(this).closest('.color-product').index();
        var data_count = $(this).closest('.size-container').attr('data-count');
        var count_item = $(this).closest('.size-container ').children('.size-item').length;

        console.log(data_count + " > " + count_item);

        if (data_count > count_item) {
            var el = $(this).closest('.size-item').clone(true).appendTo($('.size-container').get(index));
            console.log(el);
            el.find('select').val("");
            el.find('.quantity').val(0);
            var parent = $(this).parent();
            $(this).detach();
            parent.html('<a class="btn btn-danger delete-size" style="display: block;">Delete size</a>');
        } else {
            $('.toast-body').text("Maximum allowed number of items: " + data_count);
            $('.toast').toast('show');
        }
    });

    $('.product-color-container').on("click", ".delete-size", function () {
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
/*--end size--*/

/*--crop image--*/
    $('.product-color-container').on('change', '.upload-image', function () {
        var index = $(this).closest('.color-product').index();
        var reader = new FileReader();
        reader.onload = function (event) {
            crop_object[index - 1].croppie('bind', {
                url: event.target.result
            }).then(function () {
                console.log('jQuery bind complete');
            });
        }
        reader.readAsDataURL(this.files[0]);
        image_selected = true;
    });

    $('.product-color-container').on('click', '.crop-but', function (event) {
        var index = $(this).closest('.color-product').index();
        crop_object[index - 1].croppie('result', {
            type: 'canvas',
            size: 'viewport'
        }).then(function (response) {
            if (image_selected == true) {
                var el = $('.image-product:first').clone(true).appendTo($('.image-container').get(index));
                el.find('.crop-result').attr("src", response);
            }
        });
    });
    
    $('.product-color-container').on("click", ".delete-image", function () {
        $(this).closest('.image-product').detach();
    });

    function cropInitializer(el) {
        $crop = el.find('.crop-image').croppie({
            enableExif: true,
            viewport: {
                width: 400,
                height: 400,
                type: 'square'
            },
            boundary: {
                width: 450,
                height: 450
            }
        });

        crop_object.push($crop);
        return $crop;
    }
    /*--end image--*/

    $(".add-color").click(function () {
        var el = $('.color-product:first').clone(false, false).appendTo('.product-color-container');

        updateAttrForColor(el, $(".color-product").length);

        cropInitializer(el);
    });

    $('.product-color-container').on('click', '.color-delete', function () {
        $(this).closest('.color-product').detach();

        $('.color-product').each(function (i, element) {
            var el = $('.color-product').eq(i);
            console.log(el);

            updateAttrForColor(el, i);
        });
    });

    function updateAttrForColor(el, index) {
        el.find('.nav-link-size').attr("href", "#seze-" + index);
        el.find('.nav-link-images').attr("href", "#images-" + index);

        el.find('.tab-pane-size').attr("id", "seze-" + index);
        el.find('.tab-pane-images').attr("id", "images-" + index);
    }
});