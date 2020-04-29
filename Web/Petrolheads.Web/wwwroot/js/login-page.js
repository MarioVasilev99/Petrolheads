$('.input100').each(function () {
    $(this).on('blur', function () {
        if ($(this).val().trim() != "") {
            $(this).addClass('has-val');
        }
        else {
            $(this).removeClass('has-val');
        }
    })
})

$('#fb-login-btn').click(function () {

    // use jQuery's $.post, to send the request
    // the second argument is the request data
    $.post('like.php', { post_id: this.id }, function (data) {
        // data is what your server returns
    });

    // prevent the link's default behavior
    return false;
});