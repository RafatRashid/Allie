$(document).ready(function () {
    $('#Account_1').on('change', function () {

        if ($(this).val() == 'none' && $('#Account_2').val() == 'none')
        {
            $('#error').html('at least one account must be chosen');
            $('#error').css('color', 'red');
            $('#submit').prop('disabled', true);
        }
        else
        {
            $('#error').html('');
            $('#submit').prop('disabled', false);
        }
        
        $.post("/Transaction/GetTransactionType",
            {
                accID: $(this).val(),
                source: false
            },
            function (data, status) {
                $('#Account_1_TransactionType').val(data);
            }
        );
    });

    $('#Account_2').on('change', function () {
        if ($(this).val() == 'none' && $('#Account_1').val() == 'none') {
            $('#error').html('at least one account must be chosen');
            $('#error').css('color', 'red');
            $('#submit').prop('disabled', true);
        }
        else {
            $('#error').html('');
            $('#submit').prop('disabled', false);
        }
        $.post("/Transaction/GetTransactionType",
            {
                accID: $(this).val(),
                source: false
            },
            function (data, status) {
                $('#Account_2_TransactionType').val(data);
            }
        );

    });
});