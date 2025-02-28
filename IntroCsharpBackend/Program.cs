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

/*var sale = new Sale();
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
}*/

// generics

/*var numbers = new MyList<int>(5);
var names = new MyList<string>(5);
var beers = new MyList<Beer>(3);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);

beers.Add(new Beer()
{
    Name = "Heineken",
    Price = 2000
});

beers.Add(new Beer()
{
    Name = "Brahma",
    Price = 1800
});

beers.Add(new Beer()
{
    Name = "Quilmes",
    Price = 1500
});

beers.Add(new Beer()
{
    Name = "Patagonia",
    Price = 2500
});

beers.Add(new Beer()
{
    Name = "Andes",
    Price = 2300
});


Console.WriteLine(numbers.GetContent());
Console.WriteLine(beers.GetContent());

public class MyList<T>
{
    private List<T> _list;
    private int _limit;

    public MyList(int limit)
    {
        _limit = limit;
        _list = new List<T>();

    }

    public void Add(T element)
    {
        if (_list.Count < _limit)
        {
            _list.Add(element);
        }
    }

    public string GetContent()
    {
        string content = "";
        foreach (var element in _list)
        {
            content += element + ", "; 
        }
        return content;
    }
}

public class Beer
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return "Nombre: " + Name + " Precio: " + Price;
    }

}*/

// serializacion y deserializacion de objetos (JSON)

/*using System.Text.Json;

var marisol = new People()
{
    Name = "Marisol",
    Age = 25
};

string json = JsonSerializer.Serialize(marisol);

Console.WriteLine(json);

string myJson = @"{
    ""Name"":""Liza"",
    ""Age"":25
}";

People? liza = JsonSerializer.Deserialize<People>(myJson);
Console.WriteLine(liza?.Name);
Console.WriteLine(liza?.Age);
public class People
{
    public string Name { get; set; }
    public int Age { get; set; }
}*/

// programación funcional, funciones puras (siempre devuelven el mismo valor,
// no alteran un valor externo dado)

/*Console.Write(Sub(2, 1));

int Sub(int a, int b)
{
    return a - b;
}*/

// se modifica el objeto beer externo, no es una funcion pura, para que sea una pura, creamos otro objeto beer2(clonacion)

/*var beer = new Beer()
{
    Name = "quilmes"
};

Console.WriteLine(ToUpper(beer).Name);
Console.WriteLine(beer.Name);

Beer ToUpper(Beer beer)
{
    var beer2 = new Beer()
    {
        Name = beer.Name.ToUpper()
    };

    return beer2;
}

public class Beer
{
    public string Name { get; set; }
}*/

// funcion de primera clase, guardado de funciones en variables, funciones de orden superior (recibe funcion como parametro)

/*var show = Show;

Some(show, "Hola como estas?");

void Show(string message)
{
    Console.WriteLine(message);
}

// Action es una palabra reservada para funciones que reciben un valor o varios pero no devuelven nada
// Func es una palabra reservada para funciones que reciben un valor o varios y devuleven algo
void Some(Action<string> fn, string message)
{
    Console.WriteLine("Hace algo al inicio");
    fn(message);
    Console.WriteLine("Hace algo al final");
}*/

// expresiones lambda - funciones anonimas

/*Func<int, int, int> sub = (a, b) => a - b;

// con un solo parametro puedo no poner los parentesis

Func<int, int> some = a => a + 2;

Func<int, int> some2 = a =>
{
    return a * 2;
};*/

// expresion lambda + funcion de orden superior

/*Some((a, b) => a + b, 5);

void Some(Func<int, int, int> fn, int number)
{
    var result = fn(number, number);
}*/



