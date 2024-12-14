using System.Reflection.Metadata;

namespace CookingAPI.Data;

public class CulinaryItem
{
        public CulinaryItem(int id, string nome, int tempoDeCozimento, int potencia, string imagem, string imagemAlt, string imagemPath )
        {
                Id = id;
                Nome = nome;
                TempoDeCozimento = tempoDeCozimento;
                Potencia = potencia;
                Imagem = imagem;
                ImagemAlt = imagemAlt;
                ImagemPath = imagemPath;
        }
        public int Id { get; }
        public string Nome { get; set; }
        public int TempoDeCozimento { get; set; }
        public int Potencia { get; set; }
        public string Imagem { get; set; }
        public string ImagemPath { get; set; }
        public string ImagemAlt { get; set; }
   
}