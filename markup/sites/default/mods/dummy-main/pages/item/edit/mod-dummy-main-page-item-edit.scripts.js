app['/mods/dummy-main/pages/item/edit/'] = (function () {
    var _layout = (function () {
        var _body = (function () {
            var _notifications = (function () {
                var _controlNotificationError;
                var _controlNotificationSuccess;

                function getControlNotificationError() {
                    return _controlNotificationError;
                }

                function getControlNotificationSuccess() {
                    return _controlNotificationSuccess;
                }

                function setup(controlNotificationError, controlNotificationSuccess, funcNext) {
                    _controlNotificationError = controlNotificationError;
                    _controlNotificationSuccess = controlNotificationSuccess;

                    funcNext();
                }

                function load(funcNext) {
                    app['/host/controls/notifications/'].start(
                        '--form',
                        'app--id--mod--dummy-main--page--item--edit--form',
                        setup,
                        app.html.setToEnd,
                        funcNext
                    );
                }

                return {
                    getControlNotificationError: getControlNotificationError,
                    getControlNotificationSuccess: getControlNotificationSuccess,
                    load: load
                };
            })();

            var _summaryErrors = (function () {
                var _controlSummaryErrors;

                function getControlSummaryErrors() {
                    return _controlSummaryErrors;
                }

                function setup(controlSummaryErrors, funcNext) {
                    _controlSummaryErrors = controlSummaryErrors;

                    app.visibility.off([
                        controlSummaryErrors.elementId
                    ]);

                    funcNext();
                }

                function load(funcNext) {
                    app['/host/controls/summary-errors/'].start(
                        '--form',
                        'app--id--mod--dummy-main--page--item--edit--form',
                        setup,
                        app.html.setToEnd,
                        funcNext
                    );
                }

                return {
                    getControlSummaryErrors: getControlSummaryErrors,
                    load: load
                };
            })();

            function init(funcNext) {
                app.visibility.off([
                    'app--id--mod--dummy-main--page--item--edit--form--name--error',
                    'app--id--mod--dummy-main--page--item--edit--form--one-to-many--error'
                ]);

                app.html.set({
                    'app--id--mod--dummy-main--page--item--edit--form': [{
                     attr: {
                         onclick: "return app['/mods/dummy-main/pages/item/edit/'].view.form.submit()"
                     }
                    }]
                });

                funcNext();
            }

            function load (funcNext) {
                app.html.load({
                    'app--id--host--layout--body': [
                        'mods/dummy-main/pages/item/edit/mod-dummy-main-page-item-edit.template.html',
                        init,
                        _summaryErrors.load,
                        _notifications.load,
                        funcNext
                    ]
                });
            }

            return {
                load: load,
                notifications: _notifications,
                summaryErrors: _summaryErrors
            };
        })();

        var _menu1 = (function () {
            function init(funcNext) {
                app['/host/layout/menu1/'].init(app['/'].pages.mods.modDummyMain.item.edit.path);

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
                app['/host/layout/menu2/'].init(app['/'].pages.mods.modDummyMain.item.edit.path);

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

    var _view = (function () {
        var _form = (function () {
            function submit() {
                app.visibility.toggle([
                    'app--id--mod--dummy-main--page--item--edit--form--name--error',
                    'app--id--mod--dummy-main--page--item--edit--form--one-to-many--error',
                    _layout.body.notifications.getControlNotificationError().elementId,
                    _layout.body.notifications.getControlNotificationSuccess().elementId,
                    _layout.body.summaryErrors.getControlSummaryErrors().elementId
                ]);

                app.css.toggle([
                    'app--id--mod--dummy-main--page--item--edit--form--name',
                    'app--id--mod--dummy-main--page--item--edit--form--one-to-many'
                ],[
                    'skin--css--core--form--error--control'
                ]);

                return false;
            }

            return {
                submit: submit
            }
        })();

        return {
            form: _form
        };
    })();

    function start(funcNext) {
        _layout.load(funcNext);
    }

    return {
        start: start,
        view: _view
    };
})();
