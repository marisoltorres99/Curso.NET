/*Sale sale = new Sale(3000);
// var message = sale.GetInfo();
// Console.WriteLine(message);

SaleWithTax saleWithTax = new SaleWithTax(300, 1.1m);
var message = saleWithTax.GetInfo();
Console.WriteLine(message);

class SaleWithTax : Sale
{
    public decimal Tax { get; set; }
    public SaleWithTax(decimal total, decimal tax) : base(total)
    {
        Tax = tax;
    }

    public override string GetInfo()
    {
        return "El total es " + Total + " el impuesto es " + Tax;
    }

    // sobrecarga
    public string GetInfo(string message)
    {
        return message;
    }

    public string GetInfo(int a)
    {
        return a.ToString();
    }
}

class Sale
{
    public decimal Total { get; set; }
    private decimal _some;

    public Sale(decimal total)
    {
        Total = total;
        _some = 8;
    }

    public virtual string GetInfo()
    {
        return "El total es " + Total;
    }
}*/

// interfaces (contrato)

var sale = new Sale();
var beer = new Beer();

Some(sale);
Some(beer);
void Some(ISave save)
{
    save.Save();
}

interface ISale
{
    decimal Total { get; set; }
}

interface ISave
{
    public void Save();
}

public class Sale : ISale, ISave
{
    public decimal Total { get; set; }

    public void Save()
    {
        Console.WriteLine("Guardado en BD.");
    }
}

public class Beer : ISave
{
    public void Save()
    {
        Console.WriteLine("Guardado en Servicio.");
    }
}