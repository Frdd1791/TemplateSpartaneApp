using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.ProductosNutricionales
{
    public class CategoriaCategoria
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }

    public class GrupoDeAlimentosGrupoDeAlimentos
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public object Categoria { get; set; }
        public object Caracteristica { get; set; }
        public object Categoria_Categoria { get; set; }
        public int Id { get; set; }
    }

    public class ProductosNutricionaless : ModelBase
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Grupo_de_Alimentos { get; set; }
        public int? Categoria { get; set; }
        public int? Imagen { get; set; }
        public GrupoDeAlimentosGrupoDeAlimentos Grupo_de_Alimentos_Grupo_de_Alimentos { get; set; }
        public CategoriaCategoria Categoria_Categoria { get; set; }
        public object Imagen_Spartane_File { get; set; }
        public int Id { get; set; }
    }

    public class Root : ModelBase
    {
        public List<ProductosNutricionaless> Productos_Nutricionaless { get; set; }
        public int RowCount { get; set; }
    }
}
