$(function () {
    var open = false;
    $('#button').width(30).height(30);

    $('#button').click(function () {
        if (open != true) {
            $('#menu').animate({ left: '0px' }, 'slow', 'linear');
            $('#button').animate({ 'margin-left': '350px' }, 'slow', 'linear');
            open = true;
        }
        else {
            $('#menu').animate({ left: '-350px' }, 'slow', 'linear');
            $('#button').animate({ 'margin-left': '0px' }, 'slow', 'linear');
            open = false;
        }
    })
})