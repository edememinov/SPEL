if (!Modernizr.inputtypes.date) {
    $(function () {
        $('.datetimepicker3').datetimepicker({
            format: 'DD/MM/YYYY'
        });
    });
}