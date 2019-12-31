app['/root/pages/contacts/'] = (function () {
    var _layout = (function () {
        var _body = (function () {
            function load (funcNext) {
                var _content =  (function () {
                    function load(funcNext) {
                        app.html.load({
                            'app--id--root--page--contacts--content': [
                                'assets/root/pages/contacts/asset-root-page-contacts.content.html',
                                funcNext
                            ]
                        });
                    }

                    return {
                        load: load
                    };
                })();

                app.html.load({
                    'app--id--host--layout--body': [
                        'root/pages/contacts/root-page-contacts.template.html',
                        _content.load,
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
                app['/host/layout/menu1/'].init(app['/'].pages.root.contacts.path);

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
