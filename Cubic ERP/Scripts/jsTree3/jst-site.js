$(document).ready(
    function () {
        $('#js-tree').jstree({
            'core': {
                "themes": {
                    "name": "default",
                    "dots": false,
                    "icons": true
                }
            },

            "types": {
                "default": {
                    "icon": "glyphicon glyphicon-folder-open"
                },
                "leaf": {
                    "icon": "glyphicon glyphicon-file"
                }
            },

            "search": {

                "case_insensitive": true,
                "show_only_matches": true
                
            },

            "plugins": ["types", "search"]
        });

        $('#js-tree').jstree("open_all");

        var to = false;
        $('#search-input').keyup(function () {
            if (to) { clearTimeout(to); }
            to = setTimeout(function () {
                var v = $('#search-input').val();
                $('#js-tree').jstree('search', v);
            }, 250);
        });

        $('#js-tree').on("click",
            ".jstree-anchor",
            function() {
                document.location = $(this).attr("href");
            }
        );
    }
);