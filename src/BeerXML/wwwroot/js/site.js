// Write your Javascript code.

$(document).ready(function () {
    $('.ui.sidebar')
		.sidebar({
		    //context: $('.bottom.segment')
		    context: $('body')
		})
		.sidebar('attach events', '.menu .item')
    ;

    $('.ui.accordion')
		.accordion()
    ;

    $('select.dropdown')
		.dropdown()
    ;

    $('input')
	  .popup()
    ;


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