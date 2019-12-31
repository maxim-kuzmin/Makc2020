app['/root/pages/index/'] = (function () {
    var _layout = (function () {
        var _body = (function () {
            function init(funcNext) {
                if (app['/'].way.isBack) {
                    app.visibility.off([
                        'app--id--root--page--index--item--contacts',
                        'app--id--root--page--index--item--mod--auth',
                        'app--id--root--page--index--item--administration'
                    ]);
                } else {
                    app.visibility.off([
                        'app--id--root--page--index--item--mod--dummy-main',
                        'app--id--root--page--index--item--site'
                    ]);
                }

                if (app['/'].user.isLoggedIn) {
                    app.css.add([
                        'app--id--root--page--index--item--administration'
                    ],[
                        'skin--css--core--list--vertical--center__last-child'
                    ]);
                } else {
                    app.visibility.off([
                        'app--id--root--page--index--item--administration'
                    ]);

                    app.css.add([
                        'app--id--root--page--index--item--mod--auth',
                        'app--id--root--page--index--item--site'
                    ],[
                        'skin--css--core--list--vertical--center__last-child'
                    ]);
                }

                funcNext();
            }

            function load (funcNext) {
                app.html.load({
                    'app--id--host--layout--body': [
                        'root/pages/index/root-page-index.template.html',
                        init,
                        funcNext
                    ]
                });
            }

            return {
                load: load
            };
        })();

        function load(funcNext) {
            app.html.load({
                'app--id': [
                    'host/layout/host-layout.template.html',
                    app['/host/layout/'].start,
                    _body.load,
                    funcNext
                ]
            });
        }

        return {
            load: load
        };
    })();

    function start(funcNext) {
        _layout.load(funcNext);
    }

    return {
        start: start
    };
})();
