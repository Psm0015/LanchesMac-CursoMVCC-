﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }
        [Required(ErrorMessage = "O {0} do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength =10,ErrorMessage ="O {0} deve ter no minimo {1} e no máximo {2} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A Descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "A Descrição deve ter no minimo {1} e no máximo {2} caracteres")]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "A Descrição detalhada do lanche deve ser informado")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "A Descrição detalhada deve ter no minimo {1} e no máximo {2} caracteres")]
        public string DescricaoLonga { get; set; }
        [Required(ErrorMessage ="Informe o preço do lanche")]
        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage ="O Preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho da Imagem Principal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho da Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
