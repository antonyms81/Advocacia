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


    var options = {
        onKeyPress: function (cpfcnpj, e, field, options) {
            var masks = ['000.000.000-000', '00.000.000/0000-00'];
            var mask = (cpfcnpj.length > 14) ? masks[1] : masks[0];
            $('#documentoFiltro').mask(mask, options);
        }
    };
    $('#documentoFiltro').mask('000.000.000-00', options);


});






