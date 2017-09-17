$(document).ready(function () {
    var descFlag = 0;
    $('#desc').keyup(function () {
        var desc = $(this).val();
        if (desc == '') {
            descFlag = 0;
            $('#error').prop('hidden', false);
            $('#error').html('Please enter description');
            $('#submit').prop('disabled', true);
        }
        else if (desc.length < 4) {
            descFlag = 0;
            $('#error').prop('hidden', false);
            $('#error').html('Description length must be more than 4 characters');
            $('#submit').prop('disabled', true);
        }
        else {
            descFlag = 1;
            $('#error').prop('hidden', true);
            $('#submit').prop('disabled', true);
        }
    });
});