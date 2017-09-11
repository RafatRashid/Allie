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
                $('#SourceAcc_Amount').attr("value", data);

                $('#DestAcc_Amount').attr("max", data);
                $('#DestAcc_Amount').attr("value", data);
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

    function enableButton()
    {
        var source = $('#SourceAcc_TransactionType').val();
        var dest = $('#DestAcc_TransactionType').val();
        var p = $('#okay');
        
        if ((source == "Credit" && dest == "Debit") || (source == "Debit" && dest == "Credit")) {
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