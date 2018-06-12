// Write your Javascript code.
$(function () {
    var organisaties = $("#list"),
        searchField = $("#search"),
        options = organisaties.find("option").clone(); // clone into memory

    // generic function to clean text
    function sanitize(string) {
        return $.trim(string).replace(/\s+/g, ' ').toLowerCase();
    }

    // prepare the options by storing the
    // "searchable" name as data on the element
    options.each(function () {
        var option = $(this);
        option.data("sanitized", sanitize(option.text()));
    });

    // handle keyup
    searchField.on("keyup", function (event) {
        var term = sanitize($(this).val()),
            matches;

        // just show all options, if there's no search term
        if (!term) {
            organisaties.empty().append(options.clone());
            return;
        }

        // otherwise, show the options that match
        matches = options.filter(function () {
            return $(this).data("sanitized").indexOf(term) !== -1;
        }).clone();
        organisaties.empty().append(matches);
    });
});
$(document)
    .ready(function() {
        $('[data-toggle="popover"]').popover();

        function testAnim(x) {
            $('.modal .modal-dialog').attr('class', 'modal-dialog  ' + x + '  animated');
        };
    });
$(function () {
    $('#datetimepicker1')
        .datetimepicker({
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-arrow-up",
                down: "fa fa-arrow-down",
              
                
            }
        });
    $('#datetimepicker2').datetimepicker({  
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down"
        }
    });
});