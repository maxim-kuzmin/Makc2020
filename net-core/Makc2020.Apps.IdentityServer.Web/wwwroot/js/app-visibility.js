app.visibility = (function () {
    var _classNames = {
        hide: 'app--css--hide'
    };

    function isHidden(elementId) {
        return document.getElementById(elementId).classList.contains(_classNames.hide);
    }

    function off(elementIds) {
        app.css.add(elementIds, [_classNames.hide]);
    }

    function on(elementIds) {
        app.css.remove(elementIds, [_classNames.hide]);
    }

    function toggle(elementIds) {
        app.css.toggle(elementIds, [_classNames.hide]);
    }

    return {
        isHidden: isHidden,
        off: off,
        on: on,
        toggle: toggle
    };
})();
