/// <reference path="../Main/Namespace.js" />

RM.Precificacao.Elemento.FormConsultaMapaDeOfertaDeServicos = function () {

    /// <summary>
    /// Encapsula comportamentos do Form da popup de Consulta Mapa de Oferta de Serviços.
    /// </summary>


    // Propriedades

    this.form = $('#consultaMapaOfertaServico form');
    this.contexto = $('#consultaMapaOfertaServico');
    this.campoEmpresa = $('input[name=Empresa]', this.contexto);
    this.campoTipo = $('input[name=TipoServico]', this.contexto);
    this.campoSegmento = $('select[name=IdSegmento]', this.contexto);
    this.campoDescricaoServico = $('input[name=DescricaoServico]', this.contexto);
};

RM.Precificacao.Elemento.FormConsultaMapaDeOfertaDeServicos.prototype.carregarDropdownListSegmento = function () {

    /// <summary>
    /// Carrega os valores padrões dos DropDownLists.
    /// </summary>

    var that = this;

    RM.Precificacao.Servidor.ajax({
        url: '/Servico/ObterTodosOsSegmentos',
        successCallback: function (resultado, form) {
            if (resultado.Sucesso) {
                form.popularDropdownListSegmento(resultado.Dados);
            }
        },
        context: that
    });
};

RM.Precificacao.Elemento.FormConsultaMapaDeOfertaDeServicos.prototype.popularDropdownListSegmento =
function (segmentos) {

    var _campoSegmento = this.campoSegmento;
    _campoSegmento.children().remove();

    $('<option>Selecione</option>').appendTo(_campoSegmento);

    $.each(segmentos, function (i, segmento) {
        $('<option value=' + segmento.IdSegmento + '>' + segmento.DescricaoSegmento + '</option>').appendTo(_campoSegmento);
    });

};

RM.Precificacao.Elemento.FormConsultaMapaDeOfertaDeServicos.prototype.filtrar = function (callback) {

    /// <summary>
    /// Carrega a tabela com os dados filtrados.
    /// </summary>

    var that = this;

    var parametros = that.form.serialize();

    RM.Precificacao.Servidor.ajax({
        url: '/Servico/ConsultarServicosPopup',
        parametros: parametros,
        successCallback: function (resultado) {
            if (resultado && resultado.Sucesso && resultado.Dados) {
                callback(resultado);
            }
        }
    });
};


// USAGE =================================================================================//

//var popup = new RM.Precificacao.Componente.Dialog('containerTal', 'Formulário Tal', 600, 450, 
//    [
//      { text: 'OK' , click: function () { obj.salvar(); $(this).dialog('close'); } },
//      { text: 'Cancelar' , click: function () { $(this).dialog('close'); } }
//    ]);
//popup.abrir();
//popup.fechar();