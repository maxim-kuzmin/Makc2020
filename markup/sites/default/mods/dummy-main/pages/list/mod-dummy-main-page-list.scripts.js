app['/mods/dummy-main/pages/list/'] = (function () {
    var _layout = (function () {
        var _body = (function () {
            var _grid = (function () {
                function load(funcNext) {
                    app['/mods/dummy-main/pages/list/grid/'].start(funcNext);
                }

                return {
                    load: load
                };
            })();

            var _pager1 = (function () {
                function load(funcNext) {
                    app['/mods/dummy-main/pages/list/pagers/top/'].start(funcNext);
                }

                return {
                    load: load
                };
            })();

            var _pager2 = (function () {
                function load(funcNext) {
                    app['/mods/dummy-main/pages/list/pagers/bottom/'].start(funcNext);
                }

                return {
                    load: load
                };
            })();

            var _query_panel = (function () {
                function load(funcNext) {
                    app['/mods/dummy-main/pages/list/query-panel/'].start(funcNext);
                }

                return {
                  load: load
                };
            })();

            function load(funcNext) {
                app.html.load({
                    'app--id--host--layout--body': [
                        'mods/dummy-main/pages/list/mod-dummy-main-page-list.template.html',
                        _query_panel.load,
                        _pager1.load,
                        _grid.load,
                        _pager2.load,
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
                app['/host/layout/menu1/'].init(app['/'].pages.mods.modDummyMain.list.path);

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
                app['/host/layout/menu2/'].init(app['/'].pages.mods.modDummyMain.list.path);

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
