app['/host/layout/menu1/'] = (function () {
    function init(path) {
        var activeMenuItem = '';

        switch (path) {
            case app['/'].pages.mods.modDummyMain.index.path:
            case app['/'].pages.mods.modDummyMain.item.create.path:
            case app['/'].pages.mods.modDummyMain.item.edit.path:
            case app['/'].pages.mods.modDummyMain.item.view.path:
            case app['/'].pages.mods.modDummyMain.list.path:
                activeMenuItem = 'app--id--host--layout--menu1--item--mod--dummy-main';
                break;
            case app['/'].pages.mods.modAuth.index.path:
            case app['/'].pages.mods.modAuth.logon.path:
            case app['/'].pages.mods.modAuth.register.path:
                activeMenuItem = 'app--id--host--layout--menu1--item--mod--auth';
                break;
            case app['/'].pages.root.contacts.path:
                activeMenuItem = 'app--id--host--layout--menu1--item--contacts';
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
            'app--id--host--layout--menu1'
        ]);

        if (app['/'].way.isBack) {
            app.visibility.off([
                'app--id--host--layout--menu1--item--contacts'
            ]);
        } else {
            app.visibility.off([
                'app--id--host--layout--menu1--item--mod--dummy-main'
            ]);
        }

        if (!app['/'].user.isLoggedIn) {
            app.visibility.off([
                'app--id--host--layout--menu1--item--administration',
                'app--id--host--layout--menu1--item--site'
            ]);
        }

        if (app['/'].way.isBack) {
            app.visibility.off([
                'app--id--host--layout--menu1--item--administration',
                'app--id--host--layout--menu1--item--mod--auth'
            ]);
        } else {
            app.visibility.off([
                'app--id--host--layout--menu1--item--site'
            ]);
        }

        funcNext();
    }

    return {
        init: init,
        start: start
    };
})();
