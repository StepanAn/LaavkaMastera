'use strict';

$(function () {
    $('.nline').mouseenter(function () {
        var line = $(this).children('hr');
        $(line[0]).animate({ width: '0%' }, 'slow', 'linear').animate({ width: '100%' }, 'slow', 'linear');
    });
});

