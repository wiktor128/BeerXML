// Write your Javascript code.

$(document).ready(function () {
    $('.button-collapse').sideNav();
    $('.collapsible').collapsible();

    //if (typeof DialogText !== 'undefined') {
    //    Materialize.toast(DialogText, 14000);
    //}
    

    //=========== MY CODE ===========

    // enables-conditional | depend-on, depend-type, depend-val
    $('select[enables-conditional="true"]').on('change', function (e) {

        var optionSelected = $('option:selected', this).val();
        var dependant = $('.field[depend-on="' + this.id + '"]');

        if (dependant.attr('depend-type') == 'whitelist') {
            if (dependant.attr('depend-val').indexOf(optionSelected) !== -1) {
                dependant.removeClass('disabled');
            } else {
                dependant.addClass('disabled');
            }
        } else if (dependant.attr('depend-type') == 'blacklist') {
            if (dependant.attr('depend-val').indexOf(optionSelected) !== -1) {
                dependant.addClass('disabled');
            } else {
                dependant.removeClass('disabled');
            }
        }
    });

});