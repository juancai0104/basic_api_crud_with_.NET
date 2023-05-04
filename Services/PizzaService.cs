using API.Models;

namespace API.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;

    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Hawaina", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Pizza> GetAll()
        => Pizzas;

    public static Pizza? Get(int pId)
        => Pizzas.FirstOrDefault(p => p.Id == pId);

    public static void Add(Pizza pPizza)
    {
        pPizza.Id = nextId++;
        Pizzas.Add(pPizza);
    }

    public static void Delete(int pId)
    {
        var pizza = Get(pId);
        
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pPizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pPizza.Id);

        if(index == -1)
            return;

        Pizzas[index] = pPizza;

    }
}