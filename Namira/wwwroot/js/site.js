$(document).ready(function () {
    var selected_size = [];
    var key_name = "item-";
    var image_selected = false; 
    var crop_object = [];
    var main_object = [];

    $('.selectpicker').selectpicker();
/*--size--*/
    $('.product-color-container').on('click', '.add-size', function () {
        var index = $(this).closest('.color-product').index();
        var data_count = $(this).closest('.size-container').attr('data-count');
        var count_item = $(this).closest('.size-container ').children('.size-item').length;

        console.log(data_count + " > " + count_item);

        if (data_count > count_item) {
            var el = $(this).closest('.size-item').clone(true).appendTo($('.size-container').get(index));
            el.find('select').val("");
            el.find('.quantity').val(0);
            var parent = $(this).parent();
            $(this).detach();
            parent.html('<a class="btn btn-danger delete-size" style="display: block;">Delete size</a>');

            updateNameSize(index);
        } else {
            $('.toast-body').text("Maximum allowed number of items: " + data_count);
            $('.toast').toast('show');
        }
    });

    $('.product-color-container').on("click", ".delete-size", function () {
        if ($('.size-item').length != 1) {
            $('.select-size option[value=' + selected_size[key_name + $(this).closest('.size-item').index()] + ']').removeAttr("disabled");
            $(this).closest('.size-item').detach();

            updateName();
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
                el.find('.img-input').attr("value", response);

                updateNameImage(index);
            }
        });
    });
    
    $('.product-color-container').on("click", ".delete-image", function () {
        $(this).closest('.image-product').detach();
        updateName();
    });

    function updateName() {
        for (var i = 0; i < $('.color-product').length; i++) {
            $('.color-product').eq(i).attr("data-name", "productColors["+ (i-1) +"]");
            updateNameSize(i);
            updateNameImage(i);
        }
    }

    function updateNameImage(index) {
        var element = $(".color-product").eq(index);
        console.log(index);

        for (var i = 0; i < element.find(".image-product").length; i++) {
            console.log(element.find(".image-product").eq(i));
            element.find(".image-product").eq(i).find(".img-input").attr("name", element.attr("data-name") + ".Images[" + (i - 1) + "]");
        }
    }

    function cropInitializer(el, classElement, w, h) {
        $crop = el.find(classElement).croppie({
            enableExif: true,
            viewport: {
                width: w,
                height: h,
                type: 'square'
            },
            boundary: {
                width: w + 100,
                height: h + 100
            }
        });

        return $crop;
    }
/*--end image--*/
/*--color--*/
    $(".add-color").click(function () {
        var el = $('.color-product:first').clone(false, false).appendTo('.product-color-container');

        updateAttrForColor(el, $(".color-product").length);

        crop_object.push(cropInitializer(el, '.crop-image', 400, 400));
    });

    $('.product-color-container').on('click', '.color-delete', function () {
        $(this).closest('.color-product').detach();

        $('.color-product').each(function (i, element) {
            var el = $('.color-product').eq(i);

            updateName();
        });
    });

    function updateAttrForColor(el, index) {
        el.find('.nav-link-size').attr("href", "#seze-" + index);
        el.find('.nav-link-images').attr("href", "#images-" + index);

        el.find('.tab-pane-size').attr("id", "seze-" + index);
        el.find('.tab-pane-images').attr("id", "images-" + index);

        el.attr("data-name", "productColors[" + (index - 2) + "]");
        el.find('.color-input').attr("name", "productColors[" + (index - 2) + "].Color");

        updateNameSize(index-1);
    }

    function updateNameSize(index) {
        var element = $(".color-product").eq(index);
        console.log("Method: " + index);

        for (var i = 0; i < element.find(".size-item").length; i++) {
            element.find(".size-item").eq(i).find(".select-size").attr("name", element.attr("data-name") + ".ColorSizes[" + i + "].SizeId");
            element.find(".size-item").eq(i).find(".quantity").attr("name", element.attr("data-name") + ".ColorSizes[" + i + "].Quantity");
        }
    }
/*--end color--*/

/*--main image--*/
    main_object.push(cropInitializer($('.main-image'), '.crop-front-image', 205, 283));
    main_object.push(cropInitializer($('.main-image'), '.crop-back-image', 205, 283));

    $('.upload-main').on('change', function () {
        var index = $(this).closest('.tab-pane-main').index();
        var reader = new FileReader();
        reader.onload = function (event) {
            main_object[index].croppie('bind', {
                url: event.target.result
            }).then(function () {
                console.log('jQuery bind complete');
            });
        }
        reader.readAsDataURL(this.files[0]);
        image_selected = true;
    });

    $('.crop-main-but').on('click', function (event) {
        var main_element = $(this).closest('.tab-pane-main');
        var index = main_element.index();
        main_object[index].croppie('result', {
            type: 'canvas',
            size: 'viewport'
        }).then(function (response) {
            if (image_selected == true) {
                main_element.find('.crop-main-image').attr("src", response);
                main_element.find('.crop-main-input').attr("value", response);
                main_element.find('.model-image').modal('toggle');
            }
        });
    });
/*--end main image--*/
});