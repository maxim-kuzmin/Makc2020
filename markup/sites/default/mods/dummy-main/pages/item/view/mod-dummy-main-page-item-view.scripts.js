app['/mods/dummy-main/pages/item/view/'] = (function () {
    var _layout = (function () {
        var _body = (function () {
            function load (funcNext) {
                app.html.load({
                    'app--id--host--layout--body': [
                        'mods/dummy-main/pages/item/view/mod-dummy-main-page-item-view.template.html',
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
                app['/host/layout/menu1/'].init(app['/'].pages.mods.modDummyMain.item.view.path);

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

        var _menu2 = (function () {
            function init(funcNext) {
                app['/host/layout/menu2/'].init(app['/'].pages.mods.modDummyMain.item.view.path);

                funcNext();
            }

            function load(funcNext) {
                app.html.load({
                    'app--id--host--layout--menu2': [
                        'host/layout/menu2/host-layout-menu2.template.html',
                        app['/host/layout/menu2/'].start,
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
                    _menu2.load,
                    _body.load,
                    funcNext
                ]
            });
        }

        return {
            body: _body,
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
