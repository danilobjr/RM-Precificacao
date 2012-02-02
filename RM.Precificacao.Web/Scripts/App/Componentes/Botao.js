/// <reference path="../Main/Namespace.js" />

RM.Precificacao.Componente.Botao = function (seletor) {

    /// <summary>
    /// Renderiza o plugin jQueryUI.Button em elementos &lt;button&gt;, &lt;input&gt; e &lt;a&gt;.
    /// </summary>
    /// <param name="seletor" type="jQuery">Seletor jQuery.</param>


    $(seletor).button();
};


// USAGE =================================================================================//

//var buttons = new RM.Precificacao.Componente.Botao("input[type=button]");