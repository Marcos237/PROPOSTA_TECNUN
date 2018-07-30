$(function () {
    $.ajax({
        type: "Get",
        url: "/Turma/BuscaTodosProfessores",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var result = data.retorno;

            if (result.length > 0) {
                $.each(result, function () {

                    $("#_professor").append("<option value='" + this.ProfessorId + "'>" + this.Nome + "</option>");
                    $('.selectpicker').selectpicker('refresh');
                });
            }
        }
    });
});

// Verifica se a ViewBag.Professor está carregada
$(function () {
    var _professor = $('#Nome').val();
    if (_professor !== "") {

        $('#_professor').prop('title', _professor);
    }
});

$('#_turmaid').click(function () {
    var nome = $("#_professor option:selected").text();
    var professorid = $("#_professor option:selected").attr('value');
    $('#Nome').val(nome);
    $('#_professorid').val(professorid);
});
