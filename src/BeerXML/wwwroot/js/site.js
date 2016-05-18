$(document).ready(function () {

    //=========== MATERIALIZE INITIALIZATIONS ===========

    //slide-out menu service
    $('.button-collapse').sideNav();
    $('.collapsible').collapsible();

    // the "href" attribute of .modal-trigger must specify the modal ID that wants to be triggered
    $('.modal-trigger').leanModal({
        dismissible: false
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
    });
    $('.tab-prev').on('click', function (e) {
        var currentHref = $('ul.tabs > li.tab > a.active').attr('href');
        var prevHref = parseInt(currentHref.substr(4)) - 1;
        $('ul.tabs').tabs('select_tab', 'tab' + prevHref);
        //$('ul.tabs').tabs('select_tab', 'tab2');
    });

    // ajax mash_step pulling sub-form from server
    var counterNumber = 0;
    $('#mash_step_add_new_btn').click(function () {
        $.ajax({
            url: '/NewItem/MashStepTemplate',//'@Url.Action("MashStepTemplate", "NewItem")',
            contentType: 'application/html; charset=utf-8',
            data: { nameAttributeId: counterNumber },
            type: 'GET',
            dataType: 'html'
        })
        .success(function (result) {
            addMashStepModal(counterNumber);
            $('#mash_step_modal_' + counterNumber + ' .modal-content').html(result);
            $('#mash_step_modal_' + counterNumber).openModal();
            ++counterNumber;

            //$('.modal-trigger').leanModal({
            //    dismissible: false
            //});
        })
        .error(function (xhr, status) {
            alert(status);//watch this
        })
    });


    // mash_step dynamic object creator, with moustache.js
    function addMashStepView(params) {
        var template = $('#mash_step_view_template').html();
        Mustache.parse(template);
        var rendered = Mustache.render(template, params);
        //$('#mash_step_container').append(rendered); 
        $(rendered).insertBefore('#mash_step_add_new');
    };
    function addMashStepModal(orderNumber) {
        var template = $('#mash_step_modal_template').html();
        Mustache.parse(template);
        var rendered = Mustache.render(template, {orderNumber: orderNumber});
        //$('#mash_step_container').append(rendered); 
        $('#mash_step_container').append(rendered);
    };

    function alterMashStepView(target, params) {
        var template = $('#mash_step_view_template').html();
        Mustache.parse(template);
        var rendered = Mustache.render(template, params);

        $(target).find('.card-content').html( $(rendered).find('.card-content').html() );
    };


    function validateMashStepModal(modalOrderNum) {
        var flag = true;
        var validator = $('#mash_form').validate();

        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__Name')) != false
                    ?  true : ($('#MashSteps_' + modalOrderNum + '__Name').addClass('invalid'), false)
               )  && flag;
        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__Version')) != false 
                    ? true : ($('#MashSteps_' + modalOrderNum + '__Version').addClass('invalid'), false)
               )  && flag;
        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__Type')) != false 
                    ? true : ($('#MashSteps_' + modalOrderNum + '__Type').addClass('invalid'), false)
               )  && flag;
        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__InfuseAmount')) != false 
                    ? true : ($('#MashSteps_' + modalOrderNum + '__InfuseAmount').addClass('invalid'), false)
               )  && flag;
        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__StepTemp')) != false 
                    ? true : ($('#MashSteps_' + modalOrderNum + '__StepTemp').addClass('invalid'), false)
               )  && flag;
        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__StepTime')) != false 
                    ? true : ($('#MashSteps_' + modalOrderNum + '__StepTime').addClass('invalid'), false)
               )  && flag;
        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__RampTime')) != false 
                    ? true : ($('#MashSteps_' + modalOrderNum + '__RampTime').addClass('invalid'), false)
               )  && flag;
        flag = (validator.check($('#MashSteps_' + modalOrderNum + '__EndTemp')) != false
                    ? true : ($('#MashSteps_' + modalOrderNum + '__EndTemp').addClass('invalid'), false)
               ) && flag;

        validator.submitted = {};
        console.log("validator submitted, modal order num: " + modalOrderNum);
        return flag;
    }

    function readValuesFromMashStepModal( modalOrderNum ) {
        var mashStepModal = $('#mash_step_modal_' + modalOrderNum);

        return {
            orderNumber: modalOrderNum,
            name: $('#MashSteps_'+ modalOrderNum +'__Name').val(),
            version: $('#MashSteps_' + modalOrderNum + '__Version').val(),
            type: $('#MashSteps_' + modalOrderNum + '__Type').val(),
            infuseAmount: $('#MashSteps_' + modalOrderNum + '__InfuseAmount').val(),
            stepTemp: $('#MashSteps_' + modalOrderNum + '__StepTemp').val(),
            stepTime: $('#MashSteps_' + modalOrderNum + '__StepTime').val(),
            rampTime: $('#MashSteps_' + modalOrderNum + '__RampTime').val(),
            endTemp: $('#MashSteps_' + modalOrderNum + '__EndTemp').val(),
            modalReference: "#mash_step_modal_" + modalOrderNum
        }
    };

    $("#mash_step_container").on('click', '.mash-step-modal-btn-save', function (e) {
        var orderNum = $(this).attr('order-number');
        if (validateMashStepModal( orderNum ) == true) {
            var params = readValuesFromMashStepModal(orderNum);
            if ($("#mash_step_view_" + orderNum).length == 0) {
                addMashStepView(params);

                $('.modal-trigger').leanModal({
                    dismissible: false
                });
            } else {
                alterMashStepView($("#mash_step_view_" + orderNum), params);
            }
            $('#mash_step_modal_' + orderNum).closeModal();
        } else {

        }
    });
});