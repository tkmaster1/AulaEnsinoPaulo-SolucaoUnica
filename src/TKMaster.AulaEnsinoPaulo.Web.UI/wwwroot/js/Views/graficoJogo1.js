/* Arquivo .js que contém todas funções necessárias para a página de Jogo 1 */

$(function () {
    fnAreaChartDataEmpty();
});

$("#btnLimparCampos").click(function () {
    $('#cb-categoria').val("").trigger('change');

    fnAreaChartDataEmpty();
});

function FiltrarConteudo() {
    var codigoCategoria = $('#cb-categoria option:selected').val() !== '' ? $('#cb-categoria option:selected').val() : 0;

    var filters = {
        'CodigoCategoria': parseInt(codigoCategoria)
    };

    $.ajax({
        type: "Post",
        url: "/Jogo/FiltroJogos",
        data: filters,
        cache: false,
        async: false,
        success: OnSucces_,
        error: OnErrorCall_
    });
}

function OnSucces_(response) {
    $("#canvas-wrapper").html("").html('<canvas id="barChart" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');

    var aData = response;
    var ano = [];
    var golsaFavor = [];
    var golsContra = [];

    for (var i in aData) {
        ano.push(aData[i].ano);
        golsaFavor.push(aData[i].golsaFavor);
        golsContra.push(aData[i].golsContra)
    }

    var areaChartData = {
        labels: ano,
        datasets: [
            {
                label: 'Gols à Favor',
                backgroundColor: 'rgba(60,141,188,0.9)',
                borderColor: 'rgba(60,141,188,0.8)',
                pointRadius: false,
                pointColor: '#3b8bba',
                pointStrokeColor: 'rgba(60,141,188,1)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(60,141,188,1)',
                borderWidth: 1,
                data: golsaFavor,
                barPercentage: 0.4,
                categoryPercentage: 0.5
            },
            {
                label: 'Gols Contra',
                backgroundColor: 'rgba(245, 127, 39, 0.8)',
                borderColor: 'rgba(245, 127, 39, 0.8)',
                pointRadius: false,
                pointColor: 'rgba(245, 127, 39, 0.8)',
                pointStrokeColor: '#c1c7d1',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(255, 99, 71, 0.6)',
                borderWidth: 1,
                data: golsContra,
                barPercentage: 0.4,
                categoryPercentage: 0.5
            },
        ]
    }

    //-------------
    //- BAR CHART -
    //-------------
    var barChartCanvas = $('#barChart').get(0).getContext('2d');
    var barChartData = $.extend(true, {}, areaChartData);
    var temp0 = areaChartData.datasets[0];
    var temp1 = areaChartData.datasets[1];
    barChartData.datasets[0] = temp1;
    barChartData.datasets[1] = temp0;

    var barChartOptions = {
        maintainAspectRatio: false,
        responsive: true,
        interaction: {
            intersect: false,
        },
        title: {
            display: true,
            text: 'Resumo Anual'
        },
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: true,
                    color: "rgba(255,99,164,0.2)"
                }
            }],
            xAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: false
                }
            }]
        }
    };

    myBarChart = new Chart(barChartCanvas, {
        type: 'bar',
        data: barChartData,
        options: barChartOptions
    });

    myBarChart.update();
}

function OnErrorCall_(errormessage) {
    bootbox.alert('O servidor não pôde processar a solicitação!');
}

function fnAreaChartDataEmpty() {
    $("#canvas-wrapper").html("").html('<canvas id="barChart" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');

    var areaChartData = {
        labels: ['Anos'],
        datasets: [
            {
                label: 'Gols à Favor',
                backgroundColor: 'rgba(60,141,188,0.9)',
                borderColor: 'rgba(60,141,188,0.8)',
                pointRadius: false,
                pointColor: '#3b8bba',
                pointStrokeColor: 'rgba(60,141,188,1)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(60,141,188,1)',
                borderWidth: 1,
                data: [0],
                barPercentage: 0.4,
                categoryPercentage: 0.5
            },
            {
                label: 'Gols Contra',
                backgroundColor: 'rgba(245, 127, 39, 0.8)',
                borderColor: 'rgba(245, 127, 39, 0.8)',
                pointRadius: false,
                pointColor: 'rgba(245, 127, 39, 0.8)',
                pointStrokeColor: '#c1c7d1',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(255, 99, 71, 0.6)',
                borderWidth: 1,
                data: [0],
                barPercentage: 0.4,
                categoryPercentage: 0.5
            },
        ]
    }

    //-------------
    //- BAR CHART -
    //-------------
    var barChartCanvas = $('#barChart').get(0).getContext('2d');
    var barChartData = $.extend(true, {}, areaChartData);
    var temp0 = areaChartData.datasets[0];
    var temp1 = areaChartData.datasets[1];
    barChartData.datasets[0] = temp1;
    barChartData.datasets[1] = temp0;

    var barChartOptions = {
        maintainAspectRatio: false,
        responsive: true,
        interaction: {
            intersect: false,
        },
        title: {
            display: true,
            text: 'Resumo Anual'
        },
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: true,
                    color: "rgba(255,99,164,0.2)"
                }
            }],
            xAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: false
                }
            }]
        }
    };

    myBarChart = new Chart(barChartCanvas, {
        type: 'bar',
        data: barChartData,
        options: barChartOptions
    });

    myBarChart.update();
}