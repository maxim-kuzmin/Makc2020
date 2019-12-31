app['/host/controls/grid/row/field/nones/'] = (function () {
    function start(containerId, funcRender, funcNext) {
        app.data.load(
            'host/controls/grid/row/field/nones/host-control-grid-row-field-nones.template.html',
            function(data, funcNext) {
                var containers = {};

                containers[containerId] = [
                    data,
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
