$(document).ready(function ()
{
    $('#SourceAcc_Account').on('change', function ()
    {
        $.post("/Transaction/GetTransactionType",
            {
                accID: $(this).val(),
                source: true
            },
            function (data, status)
            {
                $('#SourceAcc_TransactionType').val(data);
                enableButton();
            }
        );

        $.post("/Account/GetAccountBalance",
            {
                accID: $(this).val()
            },
            function (data, status) {
                $('#SourceAcc_Amount').attr("max", data);
                
                $('#SourceAcc_Amount').val(data);

                $('#DestAcc_Amount').attr("max", data);
                
                $('#DestAcc_Amount').val(data);
            }
        );
        
    });

    $('#DestAcc_Account').on('change', function () {
        
        $.post("/Transaction/GetTransactionType",
            {
                accID: $(this).val(),
                source: false
            },
            function (data, status)
            {    
                $('#DestAcc_TransactionType').val(data);
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


    function enableButton()
    {
        var source = $('#SourceAcc_TransactionType').val();
        var dest = $('#DestAcc_TransactionType').val();
        var p = $('#okay');
        
        if (((source == "Credit" && dest == "Debit") || (source == "Debit" && dest == "Credit")) && (descFlag == 1 && dateFlag == 1)) {
            $('#submit').prop('disabled', false);
            p.hide();
        }
        else {
            $('#submit').prop('disabled', true);
            p.show();
        }
    }

    $('#SourceAcc_Amount').bind('input', function () {
        $('#DestAcc_Amount').val($(this).val());
    });
    
});