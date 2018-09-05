$(function () {
    var IndiceTelefone = 0;

    $("#btn-add-telefone").click(function (e) {
        e.preventDefault();

        var addTelefone = '<div id="linha">' +
            '<div class="row">' + //linha q estão os campos
            '<div class="col-md-2">' +
            '    <input type="text" name="Telefones[' + IndiceTelefone + '].DDD" class="form-control txt-ddd" placeholder="DDD" />' +
            '</div>' +
            '<div class="col-md-4">' +
            '   <input type="text" name="Telefones[' + IndiceTelefone + '].Numero" class="form-control txt-numero" placeholder="Numero tel" />' +
            '</div>' +
            '<div class="col-md-3">' +
            '    <select name="Telefones[' + IndiceTelefone + '].Tipo" class="form-control sel-tipo">' +
            '        <option value="0">Fixo</option>' +
            '        <option value="1">Celular</option>' +
            '        <option value="2">Empresa</option>' +
            '        <option value="3">Outros</option>' +
            '    </select>' +
            '</div>' +
            '<div class="col-md-2">'+ //div de cima 
            '    <button class="btn btn-danger btn-rem-telefone">' +
            '        <span class="glyphicon glyphicon-trash"></span>' +
            '    </button>' +
            '</div>' +
            '</div>' +
            '</br>' +
        ' </div>'
        
        $("#div-telefones").append(addTelefone);

        IndiceTelefone++;
    });

    $("#div-telefones").on("click", ".btn-rem-telefone", function (e) {
        e.preventDefault();

        //primeiro "parent"  pega a div de cima
        //segundo  "parente" pega a linha toda (row) que estão os campos
        //$(this).parent().parent().remove();

        $(this).parent().parent().parent().remove("#linha");
                       
        IndiceTelefone--;

        $("#div-telefones .row").each(function (indice, elemento) {
            $(elemento).find(".txt-ddd").attr("name", "Telefones[" + indice + "].DDD");
            $(elemento).find(".txt-numero").attr("name", "Telefones[" + indice + "].Numero");
            $(elemento).find(".sel-tipo").attr("name", "Telefones[" + indice + "].Tipo");
        });
    });
});