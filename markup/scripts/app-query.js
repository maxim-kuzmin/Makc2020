app.query = (function () {
    var _parameterNames = {
        path: 'app--par--path'
    };

    var _staticParameterNames = [];

    function create(parameters) {
        if (!parameters) {
            parameters = {};
        }

        var _paramPath = (function () {
            function get() {
                return getParameterFirstValue(_parameterNames.path);
            }

            function set(value) {
                if (value) {
                    parameters[_parameterNames.path] = [value];
                } else {
                    delete parameters[_parameterNames.path];
                }
            }

            return {
                get: get,
                set: set
            };
        })();

        function getParameterFirstValue(key) {
            var paramValues = parameters[key];

            return paramValues && paramValues.length > 0 ? paramValues[0] : '';
        }

        function hasParameter(key) {
            return parameters.hasOwnProperty(key);
        }

        return {
            getParameterFirstValue: getParameterFirstValue,
            hasParameter: hasParameter,
            parameters: parameters,
            paramPath: _paramPath
        };
    }

    function get() {
        var result = create();

        var search = window.location.search;

        if (search) {
            var parameters = result.parameters;

            search.substr(1).split("&").forEach(
                function (item) {
                    var parts = item.split("=");
                    var key = window.decodeURIComponent(parts[0]);
                    var value = '';

                    if (parts.length > 1) {
                        value = parts[1];
                    }

                    if (value) {
                        value = window.decodeURIComponent(value);
                    }

                    if (!parameters[key]) {
                        parameters[key] = [];
                    }

                    parameters[key].push(value)
                }
            );
        }

        return result;
    }

    function set(query) {
        var i, key;

        var parameters = query.parameters;

        var parts = [];

        var len = _staticParameterNames.length;

        if (len > 0) {
            var currentParameters = get().parameters;

            for (i = 0; i < len; i++) {
                for (key in currentParameters) {
                    if (!currentParameters.hasOwnProperty(key)) {
                        continue;
                    }

                    if (key === _staticParameterNames[i] && !query.hasParameter(key)) {
                        parameters[key] = currentParameters[key];
                    }
                }
            }
        }

        for (key in parameters) {
            if (!parameters.hasOwnProperty(key)) {
                continue;
            }

            if (query.hasParameter(key)) {
                var values = parameters[key];

                len = values.length;

                key = window.encodeURIComponent(key);

                for (i = 0; i < len; i++) {
                    var value = values[i];

                    if (value) {
                        value = window.encodeURIComponent(value);

                        parts.push(key + '=' + value);
                    } else {
                        parts.push(key);
                    }
                }
            }
        }

        window.location.search = parts.length > 0 ? parts.join('&') : '';
    }

    function setStaticParameterNames(value) {
        _staticParameterNames = value || [];
    }

    return {
        create: create,
        get: get,
        set: set,
        setStaticParameterNames: setStaticParameterNames
    };
})();
