﻿/* Arquivo .js que contém todas funções necessárias para a página de Artilharia */

$(document).ready(function () {

    $('#cb-jogador').select2();
    $('#cb-categoria').select2();
    $('#cb-ano').select2();

    $('#dtArtilharia').DataTable({
        searching: true,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json",
            "infoEmpty": "No entries to show",
            "sInfo": "Mostrando de _START_ ate _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
        }
    });

});

$("#btnLimparCampos").click(function () {
    $('#cb-jogador').val("").trigger('change');
    $('#cb-categoria').val("").trigger('change');
    $('#cb-ano').val("").trigger('change');
});

function FiltrarConteudo() {
    alert('Entrou aqui');
}