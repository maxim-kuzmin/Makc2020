app['/host/controls/grid/row/'] = (function () {
    var _ID_ELEMENT = 'app--id--host--control--grid--row';
    var _ID_ELEMENT_TITLE = 'app--id--host--control--grid--row--title';
    var _ID_ELEMENT_FIELDS = 'app--id--host--control--grid--row--fields';
    var _ID_ELEMENT_ACTIONS = 'app--id--host--control--grid--row--actions';

    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _control = {
            actionClick: actionClick,
            elementId: _ID_ELEMENT + index,
            elementActionsId: _ID_ELEMENT_ACTIONS + index,
            elementFieldsId: _ID_ELEMENT_FIELDS + index,
            elementTitleId: _ID_ELEMENT_TITLE + index,
            index: index,
            setTitle: setTitle
        };

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
                    index + '--row',
                    _control.elementId,
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

        function actionClick() {
            app.visibility.toggle([
                _notifications.getControlNotificationError().elementId,
                _notifications.getControlNotificationSuccess().elementId
            ]);
        }

        function init(funcNext) {
            funcSetup(_control, funcNext);
        }

        function setTitle(text, href) {
            var values = {};

            values[_control.elementTitleId] = [{
                html: text,
                attr: {
                    'href': href
                }
            }];

            app.html.set(values);
        }

        app.data.load(
            'host/controls/grid/row/host-control-grid-row.template.html',
            function(data, funcNext) {
                var reElement = new RegExp('"' + _ID_ELEMENT + '"', 'g');
                var reElementActions = new RegExp('"' +_ID_ELEMENT_ACTIONS + '"', 'g');
                var reElementFields = new RegExp('"' +_ID_ELEMENT_FIELDS + '"', 'g');
                var reElementTitle = new RegExp('"' +_ID_ELEMENT_TITLE + '"', 'g');

                data = data.replace(
                    reElement,
                    _control.elementId
                ).replace(
                    reElementActions,
                    _control.elementActionsId
                ).replace(
                    reElementFields,
                    _control.elementFieldsId
                ).replace(
                    reElementTitle,
                    _control.elementTitleId
                );

                var containers = {};

                containers[containerId] = [
                    data,
                    init,
                    _notifications.load,
                    funcNext
                ];

                funcRender(containers);
            },
            funcNext
        );
    }

    return {
        start: start
    };
})();
