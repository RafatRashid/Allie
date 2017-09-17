$(document).ready(function () {
            var pattern = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            var mailFlag = 0;
            $('#email').keyup(function () {
                var mail = $(this).val();
                if (!pattern.test(mail) || mail.length == 0) {
                    mailFlag = 0;
                    $('#mailError').prop('hidden', false);
                    $('#mailError').html('someone@something.com');
                    $('#submit').prop('disabled', true);
                }
                else {
                    $('#mailError').prop('hidden', true);
                    mailFlag = 1;
                    check();
                }
            });
            var pass = 0;
            $('#Password').keyup(function () {
                var p = $(this).val();
                if (p.length < 6 || p.length == 0) {
                    pass = 0;
                    $('#error').prop('hidden', false);
                    $('#error').html('password must be at least 6 chars long');
                    $('#submit').prop('disabled', true);
                }
                else {
                    $('#error').prop('hidden', true);
                    pass = 1;
                    check();
                }
            });
            function check()
            {
                if (pass == 1 && mailFlag == 1)
                    $('#submit').prop('disabled', false);
                else
                    $('#submit').prop('disabled', true);
            }
        });