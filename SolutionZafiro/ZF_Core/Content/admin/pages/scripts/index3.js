var Index = function() {

    var dashboardMainChart = null;

    return {

        //main function
        init: function() {
            Backbones.addResizeHandler(function() {
                jQuery('.vmaps').each(function() {
                    var map = jQuery(this);
                    map.width(map.parent().width());
                });
            });

            Index.initCharts();
            Index.initMiniCharts();
            Index.initJQVMAP();
            Index.initPlotCharts();
        },

        initJQVMAP: function() {
            if (!jQuery().vectorMap) {
                return;
            }

            var showMap = function(name) {
                jQuery('.vmaps').hide();
                jQuery('#vmap_' + name).show();
            }

            var setMap = function(name) {
                var data = {
                    map: 'world_en',
                    backgroundColor: null,
                    borderColor: '#333333',
                    borderOpacity: 0.5,
                    borderWidth: 1,
                    color: '#c6c6c6',
                    enableZoom: true,
                    hoverColor: '#c9dfaf',
                    hoverOpacity: null,
                    values: sample_data,
                    normalizeFunction: 'linear',
                    scaleColors: ['#b6da93', '#909cae'],
                    selectedColor: '#c9dfaf',
                    selectedRegion: null,
                    showTooltip: true,
                    onLabelShow: function(event, label, code) {

                    },
                    onRegionOver: function(event, code) {
                        if (code == 'ca') {
                            event.preventDefault();
                        }
                    },
                    onRegionClick: function(element, code, region) {
                        var message = 'You clicked "' + region + '" which has the code: ' + code.toUpperCase();
                        alert(message);
                    }
                };

                data.map = name + '_en';
                var map = jQuery('#vmap_' + name);
                if (!map) {
                    return;
                }
                map.width(map.parent().parent().width());
                map.show();
                map.vectorMap(data);
                map.hide();
            }

            setMap("world");
            showMap("world");

            jQuery('#regional_stat_world').click(function() {
                showMap("world");
            });

            $('#region_statistics_loading').hide();
            $('#region_statistics_content').show();
        },

        initCharts: function() {
            if (Morris.EventEmitter) {
                // Use Morris.Area instead of Morris.Line
                dashboardMainChart = Morris.Area({
                    element: 'sales_statistics',
                    padding: 0,
                    behaveLikeLine: false,
                    gridEnabled: false,
                    gridLineColor: false,
                    axes: false,
                    fillOpacity: 3,
                    data: [{
                        year: '2015 Q1',
                        sales: 1400,
                        profit: 550
                    }, {
                        year: '2015 Q2',
                        sales: 1100,
                        profit: 600
                    }, {
                        year: '2015 Q3',
                        sales: 1500,
                        profit: 600
                    }, {
                        year: '2015 Q4',
                        sales: 1200,
                        profit: 400
                    }, {
                        year: '2015 Q5',
                        sales: 1600,
                        profit: 700
                    }, {
                        year: '2015 Q6',
                        sales: 1300,
                        profit: 500
                    }, {
                        year: '2015 Q7',
                        sales: 1550,
                        profit: 650
                    }, {
                        year: '2015 Q8',
                        sales: 1250,
                        profit: 500
                    }, {
                        year: '2015 Q9',
                        sales: 1500,
                        profit: 600
                    }],
                    lineColors: ['#9B26AF', '#00BBD3'],
                    xkey: 'year',
                    ykeys: ['sales', 'profit'],
                    labels: ['Sales', 'Profit'],
                    pointSize: 0,
                    lineWidth: 0,
                    hideHover: 'auto',
                    resize: true
                });

            }
        },

        redrawCharts: function() {
            dashboardMainChart.resizeHandler();
        },

        initMiniCharts: function() {

            // IE8 Fix: function.bind polyfill
            if (Backbones.isIE8() && !Function.prototype.bind) {
                Function.prototype.bind = function(oThis) {
                    if (typeof this !== "function") {
                        // closest thing possible to the ECMAScript 5 internal IsCallable function
                        throw new TypeError("Function.prototype.bind - what is trying to be bound is not callable");
                    }

                    var aArgs = Array.prototype.slice.call(arguments, 1),
                        fToBind = this,
                        fNOP = function() {},
                        fBound = function() {
                            return fToBind.apply(this instanceof fNOP && oThis ? this : oThis,
                                aArgs.concat(Array.prototype.slice.call(arguments)));
                        };

                    fNOP.prototype = this.prototype;
                    fBound.prototype = new fNOP();

                    return fBound;
                };
            }

            $("#sparkline_bar").sparkline([9, 8, 10, 11, 10, 10, 12, 10, 10, 11, 9, 12, 11], {
                type: 'bar',
                width: '100',
                barWidth: 6,
                height: '45',
                barColor: '#00A9BE',
                negBarColor: '#e02222'
            });

            $("#sparkline_bar2").sparkline([11, 9, 13, 12, 12, 13, 10, 14, 13, 10, 11, 12, 11], {
                type: 'bar',
                width: '100',
                barWidth: 6,
                height: '45',
                barColor: '#7DAF42',
                negBarColor: '#e02222'
            });
            
            $("#sparkline_bar3").sparkline([9, 4, 6, 5, 6, 4, 5, 7, 9, 3, 6, 5, 7], {
                type: 'line',
                width: '100',
                barWidth: 6,
                height: '45',
                lineColor: '#E58900',
                negLineColor: '#e02222',
                fillColor: '#fff'
            });
            
            $("#sparkline_bar4").sparkline([5, 6, 3, 9, 7, 5, 4, 6, 5, 6, 4, 9, 7], {
                type: 'line',
                width: '100',
                barWidth: 6,
                height: '45',
                lineColor: '#56707D',
                negLineColor: '#e02222',
                fillColor: '#fff'
            });
            
            $("#sparkline_bar5").sparkline([6, 4, 8, 6, 5, 6, 7, 8, 3, 5, 9, 5, 8, 4, 3, 6, 8], {
                type: 'bar',
                width: '83',
                barWidth: 4,
                height: '45',
                barColor: '#FFF',
                negBarColor: '#e02222'
            });

            $("#sparkline_bar6").sparkline([4, 7, 6, 2, 5, 3, 8, 6, 6, 4, 8, 6, 5, 8, 2, 4, 6], {
                type: 'bar',
                width: '83',
                barWidth: 4,
                height: '45',
                barColor: '#FFF',
                negBarColor: '#e02222'
            });
            
            $("#sparkline_bar7").sparkline([9, 4, 6, 5, 6, 4, 5, 7, 9, 3, 6, 5], {
                type: 'line',
                width: '85',
                lineWidth: 1,
                height: '45',
                lineColor: '#FFF',
                negLineColor: '#FFF',
                fillColor: ''
            });
            
            $("#sparkline_bar8").sparkline([5, 6, 3, 9, 7, 5, 4, 6, 5, 6, 4, 9, 6, 4, 7, 9, 6 ], {
                type: 'discrete',
                width: '85',
                lineWidth: 2,
                height: '45',
                lineColor: '#FFF',
                negLineColor: '#FFF'
            });
        },
        
        initPlotCharts: function() {

            if (!jQuery.plot) {
                return;
            }

            var data = [];
            var totalPoints = 300;

            // random data generator for plot charts

            function getRandomData() {
                if (data.length > 0) data = data.slice(1);
                // do a random walk
                while (data.length < totalPoints) {
                    var prev = data.length > 0 ? data[data.length - 1] : 50;
                    var y = prev + Math.random() * 10 - 5;
                    if (y < 0) y = 0;
                    if (y > 100) y = 100;
                    data.push(y);
                }
                // zip the generated y values with the x values
                var res = [];
                for (var i = 0; i < data.length; ++i) {
                    res.push([i, data[i]]);
                }

                return res;
            }

            //Dynamic Chart

            function chart4() {
                if ($('#chart_4').size() != 1) {
                    return;
                }
                //server load
                var options = {
                    series: {
                        shadowSize: 1
                    },
                    lines: {
                        show: true,
                        lineWidth: 0.5,
                        fill: true,
                        fillColor: {
                            colors: [{
                                opacity: 1
                            }, {
                                opacity: 1
                            }]
                        }
                    },
                    yaxis: {
                        min: 0,
                        max: 100,
                        tickColor: "#eee",
                        tickFormatter: function(v) {
                            return v + "";
                        }
                    },
                    xaxis: {
                        show: true,
                    },
                    colors: ["#00BBD3"],
                    grid: {
                        tickColor: "#eee",
                        borderWidth:0,
                    }
                };

                var updateInterval = 60;
                var plot = $.plot($("#chart_4"), [getRandomData()], options);

                function update() {
                    plot.setData([getRandomData()]);
                    plot.draw();
                    setTimeout(update, updateInterval);
                }
                update();
            }
            //graph
            chart4();
        }

    };

}();