$(function() {
    $('.point').mouseover(function() {
        var prevCount = parseInt($(this).prev().find('a').html());
        var nextCount = parseInt($(this).next().find('a').html());

        var tooltiPages = "<ul>";
        for (var i = prevCount + 1; i < nextCount; i++) {
            tooltiPages += "<li><a href='?page=" + i + "'>" + i + "</a></li>";
        }
        tooltiPages += "</ul>";
        $(this).append("<div class='paging-tooltip'>" + tooltiPages + "</div>");
    });

    $('.point').mouseout(function() {
        $(this).find('.paging-tooltip').remove();
    });
});