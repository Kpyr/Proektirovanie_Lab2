using System;

// Интерфейс, предоставляющий доступ к интернет-магазину
public interface IInternetShop
{
    void ViewProducts();
    void Authenticate(string username, string password);
    void PlaceOrder();
}

// Класс реального пользователя интернет-магазина
public class RealCustomer : IInternetShop
{
    public void ViewProducts()
    {
        Console.WriteLine("Просмотр товаров в интернет-магазине.");
    }

    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Пользователь {username} авторизован.");
    }

    public void PlaceOrder()
    {
        Console.WriteLine("Оформление заказа в интернет-магазине.");
    }
}

// Класс прокси для доступа к интернет-магазину
public class ProxyCustomer : IInternetShop
{
    private RealCustomer realCustomer;

    public void ViewProducts()
    {
        Console.WriteLine("Просмотр товаров в интернет-магазине.");
    }

    public void Authenticate(string username, string password)
    {
        // Проверка авторизации
        if (CheckCredentials(username, password))
        {
            // Если авторизация успешна, создаем объект RealCustomer
            realCustomer = new RealCustomer();
            realCustomer.Authenticate(username, password);
        }
        else
        {
            Console.WriteLine("Неверные учетные данные. Авторизация не выполнена.");
        }
    }

    public void PlaceOrder()
    {
        // Проверяем, авторизован ли пользователь
        if (realCustomer != null)
        {
            realCustomer.PlaceOrder();
        }
        else
        {
            Console.WriteLine("Необходимо авторизоваться для оформления заказа.");
        }
    }

    // Метод для проверки учетных данных пользователя
    private bool CheckCredentials(string username, string password)
    {
        // Здесь могут быть проверки учетных данных в базе данных или другом хранилище
        // Для простоты примера всегда возвращаем true
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем прокси для доступа к интернет-магазину
        ProxyCustomer proxy = new ProxyCustomer();

        // Неавторизованный пользователь просматривает товары
        proxy.ViewProducts();

        // Авторизуем пользователя
        proxy.Authenticate("username", "password");

        // Пользователь оформляет заказ
        proxy.PlaceOrder();
    }
}
