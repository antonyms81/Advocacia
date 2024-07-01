$(document).ready(function () {
    $('#telefone').mask('(00) 00000-0000');

    $('input[name="Tipo"]').change(function () {
        let tipo = $('input[name="Tipo"]:checked').val();
        if (tipo === 'PF') {
            $('#documento').mask('000.000.000-00', { clearIfNotMatch: true });
            $('#documento').attr('placeholder', 'Digite o CPF');
        } else if (tipo === 'PJ') {
            $('#documento').mask('00.000.000/0000-00', { clearIfNotMatch: true });
            $('#documento').attr('placeholder', 'Digite o CNPJ');
        }
    });


    function aplicarMascara() {
        $('#documentoFiltro').unmask(); // Remove qualquer máscara existente
        var tamanho = $('#documentoFiltro').val().replace(/\D/g, '').length;
        if (tamanho <= 11) {
            $('#documentoFiltro').mask('000.000.000-00', { clearIfNotMatch: true });
            $('#documentoFiltro').attr('placeholder', 'Digite o CPF');
        } else {
            $('#documentoFiltro').mask('00.000.000/0000-00', { clearIfNotMatch: true });
            $('#documentoFiltro').attr('placeholder', 'Digite o CNPJ');
        }
    }

    // Aplica a máscara ao carregar a página
    aplicarMascara();

    // Aplica a máscara ao digitar no campo
    $('#documentoFiltro').on('input', aplicarMascara);


});






