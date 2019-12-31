app.html = (function () {
    function appendToHead(paths) {
        var len = paths.length;

        for (var i = 0; i < len; i++) {
            var path = paths[i];

            if (path.indexOf('.css') > 0) {
                var elem = document.createElement("link");

                elem.setAttribute('rel', "stylesheet");
                elem.setAttribute('type', "text/css");
                elem.setAttribute('href', path);

                document.head.appendChild(elem);
            }
        }
    }

    function hasAllValue(elementIds) {
        var len = elementIds.length;

        for (var i = 0; i < len; i++) {
            var elem = document.getElementById(elementIds[i]);

            if (!elem || !elem.value) {
                return false;
            }
        }

        return true;
    }

    function hasAnyValue(elementIds) {
        var len = elementIds.length;

        for (var i = 0; i < len; i++) {
            var elem = document.getElementById(elementIds[i]);

            if (elem && elem.value) {
                return true;
            }
        }

        return false;
    }

    function load(argsKeyedByElementId) {
        loadTo('', argsKeyedByElementId);
    }

    function loadTo(place, argsKeyedByElementId) {
        for (var key in argsKeyedByElementId) {
            if (argsKeyedByElementId.hasOwnProperty(key)) {
                var elem = document.getElementById(key);

                if (elem) {
                    var args = argsKeyedByElementId[key];

                    var len = args.length;

                    if (args && len > 0) {
                        loadToElement(args[0], elem, place, len > 1 ? args.slice(1) : null);
                    }
                }
            }
        }
    }

    function loadToElement(path, elem, place, callbacks) {
        app.data.load(path, function (data) {
            setToElement(data, elem, place, callbacks);
        });
    }

    function loadToEnd(argsKeyedByElementId) {
        loadTo('end', argsKeyedByElementId);
    }

    function loadToStart(argsKeyedByElementId) {
        loadTo('start', argsKeyedByElementId);
    }

    function replace(argsKeyedByElementId) {
        for (var key in argsKeyedByElementId) {
            if (argsKeyedByElementId.hasOwnProperty(key)) {
                var elem = document.getElementById(key);

                if (elem) {
                    var args = argsKeyedByElementId[key];

                    var len = args.length;

                    if (args && len > 0) {
                        for (var i = 0; i < len; i++) {
                            if (i % 2 !== 0) continue;

                            var from = args[i];

                            var j = i + 1;

                            var to = j < len ? args[j] : '';

                            elem.innerHTML = elem.innerHTML.replace(new RegExp(from, 'g'), to);
                        }
                    }
                }
            }
        }
    }

    function set(argsKeyedByElementId) {
        setTo('', argsKeyedByElementId);
    }

    function setAttributes(elementId, valuesKeyedByAttributeName) {
        var elem = document.getElementById(elementId);

        if (elem) {
            setElemAttributes(elem, valuesKeyedByAttributeName);
        }
    }

    function setElemAttributes(elem, valuesKeyedByAttributeName) {
        for (var key in valuesKeyedByAttributeName) {
            if (valuesKeyedByAttributeName.hasOwnProperty(key)) {
                elem.setAttribute(key, valuesKeyedByAttributeName[key]);
            }
        }
    }

    function setTo(place, argsKeyedByElementId) {
        for (var key in argsKeyedByElementId) {
            if (argsKeyedByElementId.hasOwnProperty(key)) {
                var elem = document.getElementById(key);

                if (elem) {
                    var args = argsKeyedByElementId[key];

                    var len = args.length;

                    if (args && len > 0) {
                        setToElement(args[0], elem, place, len > 1 ? args.slice(1) : null);
                    }
                }
            }
        }
    }

    function setToElement(data, elem, place, callbacks) {
        var html;

        var valuesKeyedByAttributeName = data.attr;

        if (!valuesKeyedByAttributeName) {
            html = data;
        } else if (typeof data.html !== 'undefined' && data.html !== null) {
            html = data.html;
        }

        if (typeof html !== 'undefined' && html !== null) {
            if (place) {
                switch (place) {
                    case 'start':
                        if (html) {
                            elem.innerHTML = html + elem.innerHTML;
                        }
                        break;
                    case 'end':
                        if (html) {
                            elem.innerHTML += html;
                        }
                        break;
                    default:
                        elem.innerHTML = elem.innerHTML.replace(new RegExp(place, 'g'), html);
                        break;
                }
            } else {
                elem.innerHTML = html;
            }
        }

        if (valuesKeyedByAttributeName) {
            setElemAttributes(elem, valuesKeyedByAttributeName);
        }

        if (callbacks) {
            app.sync(callbacks);
        }
    }

    function setToEnd(argsKeyedByElementId) {
        setTo('end', argsKeyedByElementId);
    }

    function setToStart(argsKeyedByElementId) {
        setTo('start', argsKeyedByElementId);
    }

    return {
        appendToHead: appendToHead,
        hasAllValue: hasAllValue,
        hasAnyValue: hasAnyValue,
        load: load,
        loadToEnd: loadToEnd,
        loadToStart: loadToStart,
        replace: replace,
        set: set,
        setAttributes: setAttributes,
        setTo: setTo,
        setToEnd: setToEnd,
        setToStart: setToStart
    };
})();
