$(document).ready(function () {
    var descFlag = 0;
    $('#Description').keyup(function () {
        var desc = $(this).val();
        if (desc == '') {
            descFlag = 0;
            $('#descError').prop('hidden', false);
            $('#descError').html('Please enter description');
            $('#submit').prop('disabled', true);
        }
        else if (desc.length < 4) {
            descFlag = 0;
            $('#descError').prop('hidden', false);
            $('#descError').html('Description length must be more than 4 characters');
            $('#submit').prop('disabled', true);
        }
        else {
            descFlag = 1;
            $('#descError').prop('hidden', true);
            enableButton();
        }
    });

    function enableButton() {
        if (descFlag == 1) {
            $('#submit').prop('disabled', false);
            p.hide();
        }
        else {
            $('#submit').prop('disabled', true);
            p.show();
        }
    }
});