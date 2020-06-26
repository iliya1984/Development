// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('.search-component #searchForm button[type="submit"]').click(function (e) {

        e.preventDefault();

        var $input = $('#SearchWord');
        var searchWord = $input.val();
        var url = "https://localhost:44316/search?queryWord=" + searchWord;

        if (typeof searchWord === 'undefined' || searchWord === '') {
            alert('Error - search word required');
        }

        $.ajax({
            url: url ,
            type: 'GET',
            contentType: 'application-json',
            error: function (e) {
                alert('Error occured');
            },
            success: function (res) {

                $('.search-results').html('');

                var $list = $('<ul class="list-group"></ul>');

                for (var i = 0; i < res.items.length; i++) {

                    var item = res.items[i];
                    $list.append('<li class="list-group-item">' + item.text + '</li>');
                }

                $('.search-results').append($list);
            }
        });

    });
})