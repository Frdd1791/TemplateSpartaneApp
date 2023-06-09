﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.ConfiguraPreguntas
{
    //public partial class ListConfigPreguntaModel : ModelBase
    //{
    //    [JsonProperty("ConfigPregunta")]
    //    public List<ConfigPregunta> listPreguntas { get; set; }

    //    [JsonProperty("RowCount")]
    //    public int RowCount { get; set; }
    //}
    //public partial class ConfigPregunta : ModelBase
    //{
    //    public int Clave { get; set; }
    //    public int Formulario { get; set; }
    //    public int? Titulo_Seccion_de_Formulario { get; set; }
    //    public string subtitulo { get; set; }
    //    public int No_Paso { get; set; }
    //    public int Tipo { get; set; }
    //    public string Tipo_Tipo_Pregunta_Resultado { get; set; }
    //    public bool Campo_Formula { get; set; }
    //    public int? Tipo_Campo_Tipo_de_Campo { get; set; }
    //    public int Tipo_Respuesta { get; set; }
    //    public int? Requerido_Mandatorio { get; set; }
    //    public int? Mostrar_Globos_Mostrar_Globo { get; set; }
    //    public string Mensaje_del_Globo { get; set; }
    //    public bool Desactivar_Pregunta { get; set; }
    //}
    public partial class ConfiguraPregunta : ModelBase
    {
        public int Clave { get; set; }
        public int Formulario { get; set; }
        public int Titulo { get; set; }
        public string SubTitulo { get; set; }
        public int? No_Paso { get; set; }
        public int Tipo { get; set; }
        public string Pregunta { get; set; }
        public bool Campo_Formula { get; set; }
        public int? Tipo_Campo { get; set; }
        public int Requerido { get; set; }
        public int Mostrar_Globos { get; set; }
        public string Mensaje_del_Globo { get; set; }
        public bool Desactivar_Pregunta { get; set; }
        public FormularioFomulario Formulario_Fomulario { get; set; }
        public TituloSeccionDeFormulario Titulo_Seccion_de_Formulario { get; set; }
        public TipoTipoPreguntaResultado Tipo_Tipo_Pregunta_Resultado { get; set; }
        public TipoCampoTipoDeCampo Tipo_Campo_Tipo_de_Campo { get; set; }
        public RequeridoMandatorio Requerido_Mandatorio { get; set; }
        public MostrarGlobosMostrarGlobo Mostrar_Globos_Mostrar_Globo { get; set; }
        public int Id { get; set; }
    }

    public class FormularioFomulario
    {
        public int clave { get; set; }
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }

    public class MostrarGlobosMostrarGlobo
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }

    public class RequeridoMandatorio
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }

    public partial class ListConfiguracionPreguntaModel : ModelBase
    {
        public List<ConfiguraPregunta> Configura_Preguntas { get; set; }
        public int RowCount { get; set; }
    }

    public class TipoCampoTipoDeCampo
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }

    public class TipoTipoPreguntaResultado
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }

    public class TituloSeccionDeFormulario
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public object Formulario { get; set; }
        public object Formulario_Fomulario { get; set; }
        public int Id { get; set; }
    }
}
