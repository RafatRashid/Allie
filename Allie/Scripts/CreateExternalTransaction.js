$(document).ready(function () {
    var ac1Flag = 0;
    $('#Account_1').on('change', function () {

        if ($(this).val() == 'none' && $('#Account_2').val() == 'none')
        {
            $('#error').html('at least one account must be chosen');
            $('#error').css('color', 'red');
            $('#submit').prop('disabled', true);
            ac1Flag = 0;
        }
        else if ($(this).val() == 'none') {
            $('#Account_1_TransactionType').val('');
        }
        else
        {
            $('#error').html('');
            ac1Flag = 1;
        }
        
        $.post("/Transaction/GetTransactionType",
            {
                accID: $(this).val(),
                source: false
            },
            function (data, status) {
                $('#Account_1_TransactionType').val(data);
                enableButton();
            }
        );
    });

    var acc2Flag = 0;
    $('#Account_2').on('change', function () {
        if ($(this).val() == 'none' && $('#Account_1').val() == 'none') {
            $('#error').html('at least one account must be chosen');
            $('#error').css('color', 'red');
            $('#submit').prop('disabled', true);
            acc2Flag = 0;
        }
        else if ($(this).val() == 'none') {
            $('#Account_2_TransactionType').val('');
        }
        else {
            $('#error').html('');
            acc2Flag = 1;
            
        }
        $.post("/Transaction/GetTransactionType",
            {
                accID: $(this).val(),
                source: false
            },
            function (data, status) {
                $('#Account_2_TransactionType').val(data);
                enableButton();
            }
        );

    });

    var dateFlag = 0;
    $('#TransactionDate').on('change', function () {
        var date = $(this).val();
        if (date == '') {
            dateFlag = 0;
            $('#dateError').prop('hidden', false);
            $('#dateError').html('Please select a date');
            $('#submit').prop('disabled', true);
        }
        else {
            dateFlag = 1;
            $('#dateError').prop('hidden', true);
            enableButton();
        }
    });

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

    var amountFlag = 0;
    $('#Amount').keyup(function () {
        var amount = $(this).val();
        if (amount == '') {
            amountFlag = 0;
            $('#amounError').prop('hidden', false);
            $('#amounError').html('Please enter non negative amount');
            $('#submit').prop('disabled', true);
        }
        else if (amount < 0 || !$.isNumeric(amount)) {
            amountFlag = 0;
            $('#amounError').prop('hidden', false);
            $('#amounError').html('Please enter non negative amount');
            $('#submit').prop('disabled', true);
        }
        else {
            amountFlag = 1;
            $('#amounError').prop('hidden', true);
            enableButton();
        }
    });

    function enableButton() {
        if (descFlag == 1 && dateFlag == 1 && (acc2Flag == 1 || ac1Flag == 1) && amountFlag == 1) {
            $('#submit').prop('disabled', false);
            p.hide();
        }
        else {
            $('#submit').prop('disabled', true);
            p.show();
        }
    }
});