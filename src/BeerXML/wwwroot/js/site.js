$(document).ready(function () {

    //=========== MATERIALIZE INITIALIZATIONS ===========

    //slide-out menu service
    $('.button-collapse').sideNav();
    $('.collapsible').collapsible();

    $(document).ready(function () {
        // the "href" attribute of .modal-trigger must specify the modal ID that wants to be triggered
        $('.modal-trigger').leanModal();
    });



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


    //tabs next and previous button service, works with one tabs per page
    $('.tab-next').on('click', function (e) {
        var currentHref = $('ul.tabs > li.tab > a.active').attr('href');
        var nextHref = parseInt(currentHref.substr(4)) + 1;
        $('ul.tabs').tabs('select_tab', 'tab' + nextHref);
        //$('ul.tabs').tabs('select_tab', 'tab2');
    })
    $('.tab-prev').on('click', function (e) {
        var currentHref = $('ul.tabs > li.tab > a.active').attr('href');
        var prevHref = parseInt(currentHref.substr(4)) - 1;
        $('ul.tabs').tabs('select_tab', 'tab' + prevHref);
        //$('ul.tabs').tabs('select_tab', 'tab2');
    })
    


    var nextNumber = 0;
    $('#btn_ajax').click(function () {
        $.ajax({
            url: '/NewItem/MashStepTemplate',//'@Url.Action("MashStepTemplate", "NewItem")',
            contentType: 'application/html; charset=utf-8',
            data: { nameAttributeId: nextNumber++ },
            type: 'GET',
            dataType: 'html'

        })
        .success(function (result) {
            $('#ajax_response_container').html(result);
        })
        .error(function (xhr, status) {
            alert(status);//watch this
        })
    });


});