$(document).ready(function () {
    var numberOkay = 1;
    $('#AccNumber').keyup(function () {
        var AccNumReg = /^.{7}$/;

        var accNum = $("#AccNumber").val();
        if (accNum == '') {
            $('#AccountNumberError').prop('hidden', false);
            $('#AccountNumberError').html('Enter Account Number');
            $('#submit').prop('disabled', true);
            numberOkay = 0;
        }
        else if (!AccNumReg.test(accNum)) {
            $('#AccountNumberError').prop('hidden', false);
            $('#AccountNumberError').html('Enter a valid number consisting of 7 alph-numeric characters');
            $('#submit').prop('disabled', true);
            numberOkay = 0;
        }
        else {
            $('#AccountNumberError').prop('hidden', true);
            numberOkay = 1;
            check();
        }
    });

    var nameOkay = 1;
    $('#AccName').keyup(function () {
        var AccNameReg = /^.{4,}$/;

        var AccName = $("#AccName").val();
        if (AccName == '') {
            $('#AccountNameError').prop('hidden', false);
            $('#AccountNameError').html('Please enter an account name');
            $('#submit').prop('disabled', true);
            nameOkay = 0;

        }
        else if (AccName.length < 3) {
            $('#AccountNameError').prop('hidden', false);
            $('#AccountNameError').html('Please enter a valid name of more than 3 characters');
            $('#submit').prop('disabled', true);
            nameOkay = 0;
        }
        else {
            $('#AccountNameError').prop('hidden', true);
            nameOkay = 1;
            check();
        }
    });

    var amountOkay = 1;
    var AccAmountReg = /^[\d]+$/;
    $('#AccAmount').keyup(function () {
        var AccAmt = $("#AccAmount").val();
        if (AccAmt == '') {
            $('#AmountError').prop('hidden', false);
            $('#AmountError').html('Amount required');
            $('#submit').prop('disabled', true);
            amountOkay = 0;
        }
        else if (AccAmt < 0 || !$.isNumeric(AccAmt)) {
            $('#AmountError').prop('hidden', false);
            $('#AmountError').html('Please enter a non negative number');
            $('#submit').prop('disabled', true);
            amountOkay = 0;
        }
        else {
            $('#AmountError').prop('hidden', true);
            amountOkay = 1;
            check();
        }
    });

    function check() {
        if (numberOkay == 1 && nameOkay == 1 && amountOkay == 1)
            $('#submit').prop('disabled', false);
    }
});