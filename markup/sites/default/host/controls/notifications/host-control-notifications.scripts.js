app['/host/controls/notifications/'] = (function () {
    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _notificationError = (function () {
            var _controlNotificationError;

            function getControlNotificationError() {
                return _controlNotificationError;
            }

            function setup(controlNotificationError, funcNext) {
                _controlNotificationError = controlNotificationError;

                app.visibility.off([
                    _controlNotificationError.elementId
                ]);

                funcNext();
            }

            function load(funcNext) {
                app['/host/controls/notifications/error/'].start(
                    index,
                    containerId,
                    setup,
                    funcRender,
                    funcNext
                );
            }

            return {
                getControlNotificationError: getControlNotificationError,
                load: load
            };
        })();

        var _notificationSuccess = (function () {
            var _controlNotificationSuccess;

            function getControlNotificationSuccess() {
                return _controlNotificationSuccess;
            }

            function setup(controlNotificationSuccess, funcNext) {
                _controlNotificationSuccess = controlNotificationSuccess;

                app.visibility.off([
                    _controlNotificationSuccess.elementId
                ]);

                funcNext();
            }

            function load(funcNext) {
                app['/host/controls/notifications/success/'].start(
                    index,
                    containerId,
                    setup,
                    funcRender,
                    funcNext
                );
            }

            return {
                getControlNotificationSuccess: getControlNotificationSuccess,
                load: load
            };
        })();

        function init(funcNext) {
            funcSetup(
                _notificationError.getControlNotificationError(),
                _notificationSuccess.getControlNotificationSuccess(),
                funcNext
            )
        }

        return app.sync([
            _notificationError.load,
            _notificationSuccess.load,
            init,
            funcNext
        ]);
    }

    return {
        start: start
    };
})();
