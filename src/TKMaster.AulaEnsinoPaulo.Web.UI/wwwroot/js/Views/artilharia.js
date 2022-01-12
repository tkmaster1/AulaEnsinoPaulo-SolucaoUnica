/* Arquivo .js que contém todas funções necessárias para a página de Artilharia */

$(function () {
    FiltrarConteudo();
});

$("#btnLimparCampos").click(function () {
    $('#cb-jogador').val("").trigger('change');
    $('#cb-categoria').val("").trigger('change');
    $('#cb-ano').val("").trigger('change');

    $('#dtArtilharia').dataTable().fnClearTable();
});

function FiltrarConteudo() {
    // debugger;
    var codigoJogador = $('#cb-jogador option:selected').val() !== '' ? $('#cb-jogador option:selected').val() : 0;
    var codigoCategoria = $('#cb-categoria option:selected').val() !== '' ? $('#cb-categoria option:selected').val() : 0;
    var codigoAno = $('#cb-ano option:selected').val() !== '' ? $('#cb-ano option:selected').val() : 0;

    var filters = {
        'CodigoJogador': parseInt(codigoJogador),
        'CodigoCategoria': parseInt(codigoCategoria),
        'Ano': parseInt(codigoAno)
    };

    $.ajax({
        url: "/Artilharia/PesquisarArtilharia",
        type: 'POST',
        cache: false,
        async: true,
        dataType: "html",
        data: JSON.stringify(filters),
        contentType: 'application/json; charset=utf8',
    }).done(function (result) {
        $('#divListarArtilharia').html(result);
    }).fail(function (xhr) {
        console.log('error : ' + xhr.status + ' - '
            + xhr.statusText + ' - ' + xhr.responseText);
    });
}