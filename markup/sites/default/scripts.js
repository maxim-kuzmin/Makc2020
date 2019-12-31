app['/'] = (function () {
    var _menu = (function () {
        function menuItemActivate(elementIds) {
            var len = elementIds.length;

            for (var i = 0; i < len; i++) {
                var args = {};

                args[elementIds[i]] = [
                    '<a',
                    '<h2><a',
                    '</a>',
                    '</h2></a>'
                ];

                app.html.replace(args);
            }
        }

        return {
            item: {
                activate: menuItemActivate
            }
        };
    })();

    var _pages = (function () {
        return {
            mods: {
                modAuth: {
                    index: app.page.create('mods/auth/index'),
                    logon: app.page.create('mods/auth/logon'),
                    register: app.page.create('mods/auth/register')
                },
                modDummyMain: {
                    index: app.page.create('mods/dummy-main/index'),
                    item: {
                        create: app.page.create('mods/dummy-main/item/create'),
                        edit: app.page.create('mods/dummy-main/item/edit'),
                        view: app.page.create('mods/dummy-main/item/view')
                    },
                    list: app.page.create('mods/dummy-main/list')
                }
            },
            root: {
                contacts: app.page.create('contacts'),
                error: app.page.create('error'),
                index: app.page.create('index')
            }
        };
    })();

    var _query = (function () {
        var _current = null;

        var _paramIsUserLoggedIn = (function () {
            var _name = 'is-user-logged-in';
            var _value = false;

            function getName() {
                return _name;
            }

            function getValue() {
                return _value;
            }

            function init(query) {
                _value = query.hasParameter(_name) && query.getParameterFirstValue(_name) === 'true';
            }

            return {
                getName: getName,
                getValue: getValue,
                init: init
            };
        })();

        var _paramIsWayBack = (function () {
            var _name = 'is-way-back';
            var _value = false;

            function getName() {
                return _name;
            }

            function getValue() {
                return _value;
            }

            function init(query) {
                _value = query.hasParameter(_name) && query.getParameterFirstValue(_name) === 'true';
            }

            return {
                getName: getName,
                getValue: getValue,
                init: init
            };
        })();

        function getCurrent() {
            return _current;
        }

        function init() {
            _current = app.query.get();

            _paramIsUserLoggedIn.init(_current);
            _paramIsWayBack.init(_current);
        }

        return {
            getCurrent: getCurrent,
            init: init,
            paramIsUserLoggedIn: _paramIsUserLoggedIn,
            paramIsWayBack: _paramIsWayBack
        };
    })();

    var _user = (function () {
        function logOff() {
            var parameters = {};

            parameters[_query.paramIsUserLoggedIn.getName()] = ['false'];

            _pages.mods.modAuth.logon.load(parameters);
        }

        function logOn() {
            var parameters = {};

            parameters[_query.paramIsUserLoggedIn.getName()] = ['true'];

            _pages.root.index.load(parameters);
        }

        return {
            isLoggedIn: false,
            logOff: logOff,
            logOn: logOn
        };
    })();

    var _way = (function () {
        function changeBackTo(paramIsWayBackValue) {
            var parameters = {};

            parameters[_query.paramIsWayBack.getName()] = [paramIsWayBackValue];

            _pages.root.index.load(parameters);
        }

        function changeToBack() {
            changeBackTo('true');
        }

        function changeToFront() {
            changeBackTo('false');
        }

        return {
            changeToBack: changeToBack,
            changeToFront: changeToFront,
            isBack: false
        };
    })();

    function start() {
        var routes = {};

        routes[_pages.mods.modAuth.index.path] = '/mods/auth/pages/index/';
        routes[_pages.mods.modAuth.logon.path] = '/mods/auth/pages/logon/';
        routes[_pages.mods.modAuth.register.path] = '/mods/auth/pages/register/';

        routes[_pages.mods.modDummyMain.index.path] = '/mods/dummy-main/pages/index/';
        routes[_pages.mods.modDummyMain.item.create.path] = '/mods/dummy-main/pages/item/create/';
        routes[_pages.mods.modDummyMain.item.edit.path] = '/mods/dummy-main/pages/item/edit/';
        routes[_pages.mods.modDummyMain.item.view.path] = '/mods/dummy-main/pages/item/view/';
        routes[_pages.mods.modDummyMain.list.path] = '/mods/dummy-main/pages/list/';

        routes[_pages.root.contacts.path] = '/root/pages/contacts/';
        routes[_pages.root.error.path] = '/root/pages/error/';
        routes[_pages.root.index.path] = '/root/pages/index/';

        app.query.setStaticParameterNames([
            _query.paramIsUserLoggedIn.getName(),
            _query.paramIsWayBack.getName()
        ]);

        _query.init();

        var path = _query.getCurrent().paramPath.get() || _pages.root.index.path;

        _user.isLoggedIn = _query.paramIsUserLoggedIn.getValue();

        _way.isBack = _query.paramIsWayBack.getValue();

        if (_way.isBack) {
            app.css.add(['app--id'], ['skin--css--way--back']);
            app.css.remove(['app--id'], ['skin--css--way--front']);
        } else {
            app.css.add(['app--id'], ['skin--css--way--front']);
            app.css.remove(['app--id'], ['skin--css--way--back']);
        }

        app.start(routes[path]);
    }

    return {
        menu: _menu,
        pages: _pages,
        start: start,
        user: _user,
        way: _way
    };
})();
