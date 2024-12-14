using System.Text;

namespace CookingAPI.Data;

using System.Collections.Generic;

public class InMemoryDatabase
{
    private List<CulinaryItem> culinaryItems;

    public InMemoryDatabase()
    {
        culinaryItems = new List<CulinaryItem>();

        var imagePath = ConstruirCaminhoArquivo( "arroz.jpg" );
        Byte[] imageBytes = new Byte[0];
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        CulinaryItem item =
            new CulinaryItem(1, "Arroz", 90, 90, imageBytes.ToString(), "Arroz cozinhando", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("carne_moida.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(2, "Carne Moída", 120, 85, imageBytes.ToString(),
            "Carne moída cozinhando", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("legumes.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(3, "Legumes", 65, 75, imageBytes.ToString(), "Legumes cozinhando", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("carnes.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(4, "Carnes", 300, 100, imageBytes.ToString(), "Carnes cozinhando", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("peixes.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(5, "Peixes", 90, 90, imageBytes.ToString(), "Peixe cozinhando", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("descongelar.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(6, "Descongelar", 90, 90, imageBytes.ToString(), "Descongelando", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("pipoca.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(7, "Pipoca", 90, 90, imageBytes.ToString(), "Pipoca estourando", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("brigadeiro.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(8, "Brigadeiro", 90, 90, imageBytes.ToString(), "Brigadeiro sendo feito", imagePath);
        culinaryItems.Add(item);

        imageBytes = new Byte[0];
        imagePath = ConstruirCaminhoArquivo("generica.jpg");
        if (System.IO.File.Exists(imagePath))
        {
            imageBytes = System.IO.File.ReadAllBytes(imagePath);
        }

        item = new CulinaryItem(9, "Meu Jeito", 0, 100, imageBytes.ToString(), "Imagem genérica", imagePath);
        culinaryItems.Add(item);
    }

    public List<CulinaryItem> GetCulinaryItems()
    {
        return culinaryItems;
    }

    public CulinaryItem GetCulinaryItemById(int id)
    {
        return culinaryItems.FirstOrDefault(item => item.Id == id);
    }

    public CulinaryItem AlterCulinaryItem(MyCulinaryItemDTO item)
    {
        int index = culinaryItems.FindIndex(item => item.Id == 9);

        var myItem = GetCulinaryItemById(9);
        if (myItem != null)
        {
            myItem.TempoDeCozimento = item.TempoDeCozimento ?? myItem.TempoDeCozimento;
            myItem.Potencia = item.Potencia ?? myItem.Potencia;
        }

        if (index != -1)
            culinaryItems[index] = myItem;

        return myItem;
    }

    public string ConstruirCaminhoArquivo(string nomeArquivo)
    {
        StringBuilder caminho = new StringBuilder();
        caminho.Append("./assets/imagem/");
        caminho.Append(nomeArquivo);
        return caminho.ToString();
    }
    
}