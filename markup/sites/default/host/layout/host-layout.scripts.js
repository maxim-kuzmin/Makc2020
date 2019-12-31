app['/host/layout/'] = (function () {
    function start(funcNext) {
        app.visibility.off([
            'app--id--host--layout--menu1',
            'app--id--host--layout--menu2'
        ]);

        app.html.load({
            'app--id--host--layout--header': [
                'host/layout/header/host-layout-header.template.html',
                app['/host/layout/header/'].start
            ]
        });

        app.html.load({
            'app--id--host--layout--footer': [
                'host/layout/footer/host-layout-footer.template.html',
                app['/host/layout/footer/'].start
            ]
        });

        funcNext();
    }

    return {
        start: start
    };
})();
