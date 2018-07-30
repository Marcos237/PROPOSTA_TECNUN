/*Carregar DropDownlis Período*/
$(function () {
    $.ajax({
        type: "Get",
        url: "/Turma/BuscarPeriodoTurma",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var result = data.retorno;

            if (result.length > 0) {

                for (var i = 0; i < result.length; i++) {
                    $("#_periodo").append("<option value='" + i + "'>" + result[i] + "</option>");
                }

                $('.selectpicker').selectpicker('refresh');
            }
        }
    });
});

// Verifica se a ViewBag.Periodo está carregada
$(function () {
    var _periodo = $('#_periodoturma').val();
    if (_periodo !== "") {

        $('#_periodo').prop('title', _periodo);
    }
});

/* Carrega a ViewBag Periodo*/
$('#_turmaid').click(function () {
    var result = $("#_periodo option:selected").text();
    $('#_periodoturma').val(result);
});

$('#_atualizarturma').click(function () {
    var result = $("#_periodo option:selected").text();
    $('#_periodoturma').val(result);
});