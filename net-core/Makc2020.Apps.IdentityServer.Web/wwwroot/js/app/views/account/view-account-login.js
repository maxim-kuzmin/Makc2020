app['/views/account/login/'] = (function ($) {
    function start() {
        var panelId = 'id--view--account--login--panel';

        if (!app.visibility.isHidden(panelId)) {
            return;
        }

        var $ctrlLoginMethodSelect = $('#id--view--account--login--form--login-method--select');

        var loginMethodWindows = 'Windows';

        $ctrlLoginMethodSelect.val(loginMethodWindows);

        function refreshVisibilityByLoginMethod(loginMethod) {
            var $ctrlUserNameGroup = $('#id--view--account--login--form--user-name--group');
            var $ctrlPasswordGroup = $('#id--view--account--login--form--password--group');
            var $ctrlRememberLoginGroup = $('#id--view--account--login--form--remember-login--group');
            var $ctrlButtonWindows = $('#id--view--account--login--form--button--windows');
            var $ctrlButtonSubmit = $('#id--view--account--login--form--button--submit');

            if (loginMethod === loginMethodWindows) {
                $ctrlUserNameGroup.hide();
                $ctrlPasswordGroup.hide();
                $ctrlRememberLoginGroup.hide();
                $ctrlButtonSubmit.hide();
                $ctrlButtonWindows.show();                
            } else {
                $ctrlUserNameGroup.show();
                $ctrlPasswordGroup.show();
                $ctrlRememberLoginGroup.show();
                $ctrlButtonSubmit.show();
                $ctrlButtonWindows.hide();
            }
        }

        function onLoginMethodSelectChange(e) {
            refreshVisibilityByLoginMethod(e.target.value);
        }

        $ctrlLoginMethodSelect.bind('change', onLoginMethodSelectChange);
        
        refreshVisibilityByLoginMethod($ctrlLoginMethodSelect.val());

        app.visibility.on([panelId]);
    }

    return {
        start: start
    };
})(jQuery);

app['/views/account/login/'].start();