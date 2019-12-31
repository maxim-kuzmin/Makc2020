app['/mods/dummy-main/pages/index/'] = (function () {
    var _layout = (function () {
        var _body = (function () {
            function load (funcNext) {
                app.html.load({
                    'app--id--host--layout--body': [
                        'mods/dummy-main/pages/index/mod-dummy-main-page-index.template.html',
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
                app['/host/layout/menu1/'].init(app['/'].pages.mods.modDummyMain.index.path);

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
