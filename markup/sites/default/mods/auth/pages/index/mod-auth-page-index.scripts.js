app['/mods/auth/pages/index/'] = (function () {
    var _layout = (function () {
        var _body = (function () {
            function init(funcNext) {
                if (app['/'].user.isLoggedIn) {
                    app.visibility.off([
                        'app--id--mod--auth--page--index--logon'
                    ]);
                } else {
                    app.visibility.off([
                        'app--id--mod--auth--page--index--logoff'
                    ]);
                }

                funcNext();
            }

            function load (funcNext) {
                app.html.load({
                    'app--id--host--layout--body': [
                        'mods/auth/pages/index/mod-auth-page-index.template.html',
                        init,
                        funcNext
                    ]
                });
            }

            return {
                load: load
            };
        })();

        var _menu1 = (function () {
            function init(funcNext) {
                app['/host/layout/menu1/'].init(app['/'].pages.mods.modAuth.index.path);

                funcNext();
            }

            function load(funcNext) {
                app.html.load({
                    'app--id--host--layout--menu1': [
                        'host/layout/menu1/host-layout-menu1.template.html',
                        app['/host/layout/menu1/'].start,
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
                    _menu1.load,
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
