 $('.email-btn').on('click', function () {
        $parent_box = $(this).closest('#btn-option');
        $parent_box.siblings().find('#email-update').hide();
        $parent_box.find('#email-form').toggle();
    });


 