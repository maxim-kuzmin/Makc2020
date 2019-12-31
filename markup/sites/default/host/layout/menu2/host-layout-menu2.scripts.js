app['/host/layout/menu2/'] = (function () {
    function init(path) {
        var activeMenuItem = '';

        switch (path) {
            case app['/'].pages.mods.modDummyMain.item.create.path:
            case app['/'].pages.mods.modDummyMain.item.edit.path:
            case app['/'].pages.mods.modDummyMain.item.view.path:
            case app['/'].pages.mods.modDummyMain.list.path: {
                app.visibility.on([
                    'app--id--host--layout--menu2--item--mod--dummy-main--item--create',
                    'app--id--host--layout--menu2--item--mod--dummy-main--list'
                ]);

                switch (path) {
                    case app['/'].pages.mods.modDummyMain.item.edit.path:
                    case app['/'].pages.mods.modDummyMain.item.view.path:
                        app.visibility.on([
                            'app--id--host--layout--menu2--item--mod--dummy-main--item--edit',
                            'app--id--host--layout--menu2--item--mod--dummy-main--item--view'
                        ]);
                        break;
                }

                switch (path) {
                    case app['/'].pages.mods.modDummyMain.item.create.path:
                        activeMenuItem = 'app--id--host--layout--menu2--item--mod--dummy-main--item--create';
                        break;
                    case app['/'].pages.mods.modDummyMain.item.edit.path:
                        activeMenuItem = 'app--id--host--layout--menu2--item--mod--dummy-main--item--edit';
                        break;
                    case app['/'].pages.mods.modDummyMain.item.view.path:
                        activeMenuItem = 'app--id--host--layout--menu2--item--mod--dummy-main--item--view';
                        break;
                    case app['/'].pages.mods.modDummyMain.list.path:
                        activeMenuItem = 'app--id--host--layout--menu2--item--mod--dummy-main--list';
                        break;
                }
            }
                break;
            case app['/'].pages.mods.modAuth.logon.path:
            case app['/'].pages.mods.modAuth.register.path: {
                app.visibility.on([
                    'app--id--host--layout--menu2--item--mod--auth--register'
                ]);

                if (app['/'].user.isLoggedIn) {
                    app.visibility.on([
                        'app--id--host--layout--menu2--item--mod--auth--logoff'
                    ]);
                } else {
                    app.visibility.on([
                        'app--id--host--layout--menu2--item--mod--auth--logon'
                    ]);
                }

                switch (path) {
                    case app['/'].pages.mods.modAuth.logon.path:
                        activeMenuItem = 'app--id--host--layout--menu2--item--mod--auth--logon';
                        break;
                    case app['/'].pages.mods.modAuth.register.path:
                        activeMenuItem = 'app--id--host--layout--menu2--item--mod--auth--register';
                        break;
                }
            }
                break;
        }

        if (activeMenuItem) {
            app['/'].menu.item.activate([
                activeMenuItem
            ]);
        }
    }

    function start(funcNext) {
        app.visibility.on([
            'app--id--host--layout--menu2'
        ]);

        app.visibility.off([
            'app--id--host--layout--menu2--item--mod--auth--register',
            'app--id--host--layout--menu2--item--mod--auth--logoff',
            'app--id--host--layout--menu2--item--mod--auth--logon',
            'app--id--host--layout--menu2--item--mod--dummy-main--item--create',
            'app--id--host--layout--menu2--item--mod--dummy-main--item--edit',
            'app--id--host--layout--menu2--item--mod--dummy-main--item--view',
            'app--id--host--layout--menu2--item--mod--dummy-main--list'
        ]);

        funcNext();
    }

    return {
        init: init,
        start: start
    };
})();
