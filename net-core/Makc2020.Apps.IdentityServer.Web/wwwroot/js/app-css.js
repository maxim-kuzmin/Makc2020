app.css = (function () {
    function add(elementIds, cssClassNames) {
        var len = elementIds.length;

        for (var i = 0; i < len; i++) {
            var elem = document.getElementById(elementIds[i]);

            if (elem) {
                var jLen = cssClassNames.length;

                for (var j = 0; j < jLen; j++) {
                    var className = cssClassNames[j];

                    if (!elem.classList.contains(className)) {
                        elem.classList.add(className);
                    }
                }
            }
        }
    }

    function remove(elementIds, cssClassNames) {
        var len = elementIds.length;

        for (var i = 0; i < len; i++) {
            var elem = document.getElementById(elementIds[i]);

            if (elem) {
                var jLen = cssClassNames.length;

                for (var j = 0; j < jLen; j++) {
                    var className = cssClassNames[j];

                    if (elem.classList.contains(className)) {
                        elem.classList.remove(className);
                    }
                }
            }
        }
    }

    function toggle(elementIds, cssClassNames) {
        var len = elementIds.length;

        for (var i = 0; i < len; i++) {
            var elem = document.getElementById(elementIds[i]);

            if (elem) {
                var jLen = cssClassNames.length;

                for (var j = 0; j < jLen; j++) {
                    var cssClassName = cssClassNames[j];

                    if (elem.classList.contains(cssClassName)) {
                        elem.classList.remove(cssClassName);
                    } else {
                        elem.classList.add(cssClassName);
                    }
                }
            }
        }
    }

    return {
        add: add,
        remove: remove,
        toggle: toggle
    };
})();
